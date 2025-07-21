using APILXYSoftCommunication;
using CommControlLib;
using Getech.GS.RobotController;
using GetechSorter.Scanner;
using MachineNewGUI.Entity;
using MachineNewGUI.Product;
using MachineNewGUI.Service;
using MachineNewGUI.UserManagement;
using Microsoft.Win32;
using RobotController;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using static MachineNewGUI.Controls.ProductHierarchyView;
using RobotCommandConst = MachineNewGUI.Entity.RobotCommandConst;

namespace MachineNewGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool bBatchStarted = false;
        EpsonRobotController robotController;
        private string FirstMessage = string.Empty;
        ProductParameters productParameters = null;
        MachineConfiguration machineParameters = null;
        InternalMemoryStateManagement Internalmachinestatemanagent;
        private string MachineGUIDirectroy = ConfigurationManager.AppSettings["Directory"].ToString();
        private StringBuilder logBuilder = new StringBuilder();
        private Thread logThread;
        private bool keepRunning = true;
        private BatchParameter batchParameter = null;
        TcpIpCom tcpRobotCommDevice_Loader;
        System.Object lockRobot1 = new System.Object();

        bool bHomeDone = false;
        bool bVerifyDone = false;

        // FOR MODBUS COMMUNICATION \\      

        public ModbusMotionControl ModbusMotionControl;
        ModbusRtuComm ModbusComm = new ModbusRtuComm();
        AxisData[] AxesData;
        bool bModbusCommConnected = false;
        DeltaServoAxisData deltaServoAxisData;

        //SECS/GEM interface   
        XYSoftConn xySoftConn = new XYSoftConn();
        MachineStateWindow machineStateWindow = new MachineStateWindow();

        //SCANNER
        KeyenceScanner[] Keyscanners = new KeyenceScanner[4]; // Index Zero Not Used
        SICK_Scanner[] Sickscanners = new SICK_Scanner[4];// Index Zero Not Used
        HIKScannerTCP hikscannerTCP = new HIKScannerTCP();
        SystemParameter SystemParameterData;
        //Error list
        Dictionary<int, string> dictErrorList = new Dictionary<int, string>();


        //batch control flags
        DispatcherTimer dispatcherTimerRobotStatusRead = new DispatcherTimer();

        public static bool bHoming = false;

        bool InitSecsBatchParaDone = false;
   
        //user
        int iCurrentUserLevel = 0;

        // Progress Window Thread
        Thread ProgressWindowThread;
        Thread HomeProgressWindowThread;
        Thread HomeProgressWindowUnloaderThread;

        string strVerionInfo = "";
        string strVerionInfoHelpPage = "";
        int CountFail = 0;
        MachineState machineState = new MachineState();
        public ObservableCollection<string> LogEntries { get; set; } = new ObservableCollection<string>();
        public MainWindow()
        {
            InitializeComponent();
            DeleteJsonFilesOnStartup();
            machineParameters = MachineConfigStream.Load();
            Thread EpsonSoftThread = new Thread(new ThreadStart(InitEpsonSoftware));
            EpsonSoftThread.Start();

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            textboxLog.Height = GroupBox3.ActualHeight;
            textboxLog.Width = GroupBox3.ActualWidth;
            textboxLog.TextWrapping = TextWrapping.Wrap;
            Internalmachinestatemanagent = InternalMemoryStateManagementConfigStream.Load();
            UpdateLogMessage("Application started");
            FileVersionInfo info = FileVersionInfo.GetVersionInfo(@".\MachineNewGUI.exe");
            strVerionInfo = String.Format("Version: {0}    {1}", info.FileVersion, "");

            strVerionInfoHelpPage = String.Format("{0}    {1}", info.FileVersion, "");

            this.Title = "New Machine -  " + strVerionInfo;
            UpdateLogMessage(this.Title.ToString());
            //Robot initialization

            try
            {
                robotController = new EpsonRobotController();
                robotController.Is6Axes = false;
                string strIP1 = machineParameters.RobotControllerIP_Loader;//ConfigurationManager.AppSettings["Robot Controller IP"];
                string strPort1 = machineParameters.RobotControllerPort_Loader;//ConfigurationManager.AppSettings["Robot Controller Port"];
                int port = Convert.ToInt32(strPort1);

                tcpRobotCommDevice_Loader = new TcpIpCom(strIP1, port, true); //save parameters in app.config
                robotController.DeviceCommControl.CommDevice = tcpRobotCommDevice_Loader;

                robotController.OnCommDeviceConnected += robotController_OnCommDeviceConnected;
                robotController.OnRobotError += robotController_OnRobotError_Loader;
                robotController.OnRobotErrorResume += robotController_OnRobotErrorResume_Loader;
                robotController.OnUpdateRobotStatus += robotController_UpdateRobotStatus_Loader;
                robotController.OnEpsonRobotCmd += robotController_OnRobotCmd_Loader;

                robotController.ConnectController();


            }
            catch (Exception ex)
            {
                UpdateLogMessage("Exception in Form_Loaded(): connecting to robot controller" + ex.Message);
            }

            //read status of robot repeatedly
            dispatcherTimerRobotStatusRead.Tick += new EventHandler(dispatcherTimerRobotStatusRead_Tick);
            dispatcherTimerRobotStatusRead.Interval = new TimeSpan(0, 0, 2);
            dispatcherTimerRobotStatusRead.Start();

            //parameters loading

            productParameters = ProductStream.Load(Internalmachinestatemanagent.LastProduct);
            string strp = MachineGUIDirectroy + @"/Product Files/" + Internalmachinestatemanagent.LastProduct + ".json";
            txtProductName.Content = "_" + strp;

            InternalMemoryStateManagementConfigStream.Save(Internalmachinestatemanagent); //save Last Product

            MachineConfigStream.Save(machineParameters);//save Last Product
            deltaServoAxisData = DeltaServoAxisDataStream.Load(machineParameters.MachineType, machineParameters.NoOfDeltaAxis);
            //scanners initialization
            InititializeScanners();

            //load error list
            Getech.GS.RobotController.ErrorListStream errorListStream = new ErrorListStream();
            errorListStream.LoadFromFile(out dictErrorList);
            machineStateWindow.Visibility = System.Windows.Visibility.Hidden;
            machineStateWindow.Show();
            ConfigureControls();
            if (machineParameters.IsModBusTrue)
            {
                if (ModbusCommConnect())
                {
                    bModbusCommConnected = true;
                    UpdateLogMessage("Modbus Comm Connected");
                }
                else
                {
                    UpdateLogMessage("Modbus Comm Not Connected");
                }
            }

            LoadSystemParameters();
            RefreshBatchParameter();
        }
        private void InitEpsonSoftware()
        {
            try
            {
                Process[] erc = Process.GetProcessesByName("erc70");
                if (erc.Length == 0)
                {
                    Process Prc = new Process();
                    Prc.StartInfo = new ProcessStartInfo("C:\\EpsonRC70\\exe\\erc70.exe");
                    Prc.Start();
                }
            }
            catch (Exception ex)
            {
                UpdateLogMessage("InitEpsonSoftware ex" + ex.Message);
            }
        }
        private void RefreshBatchParameter()
        {
            batchParameter = new BatchParameter();
            batchParameter.ReservationNo = "107005074";
            batchParameter.BatchNo = "CBNGF2Q001";
            batchParameter.ModuleFromFactor = productParameters.Name;
            batchParameter.ProductName = productParameters.ProductName;
            batchParameter.ProductHeight = productParameters.Height;
            batchParameter.ProductWidth = productParameters.Width;
            batchParameter.ProductLength = productParameters.Length;
            this.DataContext = batchParameter;
        }
        private void ConstructBatchParameterObject()
        {
            batchParameter = new BatchParameter();
            batchParameter.ReservationNo = "107005074";
            batchParameter.BatchNo = "CBNGF2Q001";
            batchParameter.ModuleFromFactor = "New Product";
            batchParameter.ProductName = "M5";
            batchParameter.ProductHeight = 2.15;
            batchParameter.ProductWidth = 2;
            batchParameter.ProductLength = 2;
            this.DataContext = batchParameter;
        }

        private void buttonLoadBatch_Click(object sender, RoutedEventArgs e)
        {

            InitSecsBatchParaDone = true;
            LoadBatchParameters();
        }
        async void LoadBatchParameters()
        {
            try
            {
                if (InitSecsBatchParaDone)
                {
                    CountFail = 0;
                    iCurrentUserLevel = 0;
                    this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate ()
                    {
                        ConfigureControls();
                    });

                    string strProductFile = Internalmachinestatemanagent.LastProduct;

                    UpdateLogMessage("Loading product file " + strProductFile);

                    string str =MachineGUIDirectroy+ @"\Product Files\" + strProductFile + ".json";
                    UpdateLogMessage("Loading product file " + str);

                    if (!File.Exists(str))
                    {
                        UpdateLogMessage(String.Format("{0} file does not exist. Please create product file", str));
                        MessageBox.Show(String.Format("{0} file does not exist. Please create product file", str));
                        return;
                    }

                    productParameters = ProductStream.Load(strProductFile);
                    if (productParameters == null)
                    {
                        UpdateLogMessage("Error: productParameter is null");
                        return;
                    }

                    UpdateLogMessage("Sending Product data to robot");
                    await SendProdNCalData();


                    //sending batch parameters
                    if ((robotController.IsConnected))
                    {
                        UpdateLogMessage("Sending VBatchParameter to robot");
                        UpdateLogMessage(string.Join(" ", productParameters.Options));
                        Thread.Sleep(100);
                        robotController.SendCmd2Robot(0, 0, RobotCommandConst.VBatchParameter, string.Join(" ", productParameters.Options));
                    }


                    UpdateLogMessage("Initializing batch control flags");

                    bBatchStarted = false;
                    bVerifyDone = false;
                    ConfigureControls();

                    UpdateLogMessage("Sending LoadBatchParameter() done");

                }
                else
                {
                    UpdateLogMessage("LoadBatchParameters exception.");
                }

                RefreshBatchParameter();
            }
            catch (Exception ex)
            {
                UpdateLogMessage("Exception in LoadBatchParameters(): " + ex.Message);
            }
        }
        private async Task SendProdNCalData()
        {
            try
            {
               // ShowProgress();

                await Task.Run(() =>
                {
                    //Sends datum points
                    CalibrationData calData = CalibDataStream.Load(machineParameters.MachineType);
                    productParameters.ProgressInfo = "Downloading System and Product Parameters";
                    Thread.Sleep(200);



                    RobotStream.SendSysParameter(calData, robotController, productParameters, machineParameters);

                    Thread.Sleep(200);
                    //Sends pallet columns and rows
                    RobotStream.SendPanelInfo(productParameters, robotController);

                    Thread.Sleep(200);

                    RobotStream.SendProductDataGAL(productParameters, robotController, machineParameters);
                    Thread.Sleep(200);
                    if (machineParameters.IsModBusTrue)
                    {
                        //Download Servo points
                        if (bModbusCommConnected)
                            SetDeltaPosGAL();
                    }

                    Thread.Sleep(200);

                });

                //CloseProgress();

                Thread.Sleep(1000);
            }
            catch (Exception ex)
            {
                UpdateLogMessage("Exception in SendProdNCalData(): " + ex.Message);
                MessageBox.Show("Exception in SendProdNCalData(): " + ex.Message);
            }
        }
        private void SetDeltaPosGAL()
        {
            try
            {
                double PosWrite = 0.0;
                double PosRead = 0.0;

                //Set Axis 2(With Adjust) PR 1 (Loose)
                PosWrite = 0.0;
                PosWrite = machineParameters.ConveyorWidth - productParameters.PalletWidth;
                if (ModbusMotionControl.SetPosition(2, 1, PosWrite))
                    UpdateLogMessage(String.Format("Axis 2 ,Pos 1 Write Success. Unclamped Conveyor Move Value is = {0} ", PosWrite));
                else
                    UpdateLogMessage(String.Format("Axis 2 ,Pos 1 Write Fail. Unclamped Conveyor Move Value is = {0} ", PosWrite));

                //Set Axis 2(With Adjust) PR 2 (Tight)
                PosWrite = 0.0;
                PosWrite = (machineParameters.ConveyorWidth - productParameters.PalletWidth) + productParameters.PalletConveyorAxisClampStrokeGAL;
                if (ModbusMotionControl.SetPosition(2, 2, PosWrite))
                    UpdateLogMessage(String.Format("Axis 2 ,Pos 2 Write Success. Clamped Conveyor Move Value is = {0} ", PosWrite));
                else
                    UpdateLogMessage(String.Format("Axis 2 ,Pos 2 Write Fail. Clamped Conveyor Move Value is = {0} ", PosWrite));

                //Set Axis 3(Lifter) PR 2 
                PosRead = 0.0;
                PosWrite = 0.0;
                if (ModbusMotionControl.GetPosition(3, 3, ref PosRead))
                {
                    UpdateLogMessage(String.Format("Axis 3 ,Pos 3 Read Success :" + PosRead.ToString()));

                    UpdateLogMessage(String.Format("Product File Tray Singulate Pitch Value is = {0} ", productParameters.Axis3ServoTraySingulatePos2GAL));

                    PosWrite = (PosRead - productParameters.Axis3ServoTraySingulatePos2GAL);

                    if (ModbusMotionControl.SetPosition(3, 2, PosWrite))
                        UpdateLogMessage(String.Format("Axis 3 ,Pos 2 Write Success .Tray Singulate Pos Value is = {0} ", PosWrite));
                    else
                        UpdateLogMessage(String.Format("Axis 3 ,Pos 2 Write Fail .Tray Singulate Pos Value is = {0} ", PosWrite));
                }
                else
                {
                    UpdateLogMessage(String.Format("Axis 3 ,Pos 3 Read Fail :" + PosRead.ToString()));
                }
            }
            catch (Exception ex)
            {
                UpdateLogMessage("SetDeltaPos" + machineParameters.MachineType + " :" + ex.Message);
            }
        }
        #region "SCANNER"

        private void InititializeScanners()
        {
            ScannersDispose();
            // DataBits 7, Parity Even , Stop bit 1  // 1 D Code
            try
            {
                if (machineParameters.ComSetting.Com1ScannerModel == 0) // END EFFECTOR SCANNER
                {
                    Keyscanners[1] = new KeyenceScanner(machineParameters.ComSetting.Comport1, machineParameters.ComSetting.Baudrate1);
                }
                else
                {
                    Sickscanners[1] = new SICK_Scanner(machineParameters.ComSetting.Comport1, machineParameters.ComSetting.Baudrate1);
                }



                if (machineParameters.ComSetting.Com2ScannerModel == 0) // FLIPPER SIDE FIXED SCANNER
                {
                    Keyscanners[2] = new KeyenceScanner(machineParameters.ComSetting.Comport2, machineParameters.ComSetting.Baudrate2);
                }
                else
                {
                    Sickscanners[2] = new SICK_Scanner(machineParameters.ComSetting.Comport2, machineParameters.ComSetting.Baudrate2);
                }

            }
            catch (Exception ex)
            {
                UpdateLogMessage("Exception in COM open: " + ex.Message);
                MessageBox.Show("Exception in COM open: " + ex.Message);
            }
        }

        private void ScannersDispose()
        {
            try
            {
                for (int i = 1; i < 4; i++)
                {
                    if (Keyscanners[i] != null)
                        Keyscanners[i].Dispose();

                    if (Sickscanners[i] != null)
                        Sickscanners[i].Dispose();
                }
                if ((machineParameters.ComSetting.Com1ScannerModel == 2) || (machineParameters.ComSetting.Com2ScannerModel == 2))
                {
                    hikscannerTCP.SocketDisconnect();
                }

            }
            catch (Exception ex)
            {
                UpdateLogMessage("Exception in COM Dispose: " + ex.Message);
                MessageBox.Show("Exception in COM Dispose: " + ex.Message);
            }
        }

        private void ScanBarcode(CommEventCmd cmd)
        {
            try
            {
                UpdateLogMessage("ScanBarcode Position = " + cmd.CmdList[5]);

                int pos = Convert.ToInt32(cmd.CmdList[5]);

                switch (pos)
                {
                    case 1://LEFT GRIPPER (Finger 1) DURABLE VALIDATION
                        {
                            #region "DURABLE VALIDATION"

                            string strResult;
                            string strBarcode;

                            if (machineParameters.ComSetting.Com1ScannerModel == 0)
                            {
                                strBarcode = Keyscanners[1].Decode();
                            }
                            else if (machineParameters.ComSetting.Com1ScannerModel == 1)
                            {
                                strBarcode = Sickscanners[1].Decode();
                            }
                            else
                            {
                                strBarcode = hikscannerTCP.TCPIntialize(1, machineParameters);
                            }
                            UpdateLogMessage(String.Format("Gripper Left Finger barcode value is {0} ", strBarcode));

                            if ((strBarcode.Equals("Error Time Out")) || (strBarcode.Length < 1) || (strBarcode.ToUpper().Contains("ERROR")))
                            {
                                strResult = "0"; //Fail
                                UpdateLogMessage(String.Format("Gripper Left Finger barcode read Fail. Reply Value = {0},Sending Fail to robot", strResult));

                                lock (lockRobot1)
                                {
                                    robotController.SendCmd2Robot(0, 0, RobotCommandConst.VReplyBarcode, strResult);//0=fail; 1= pass
                                }
                            }
                            else
                            {
                                if (strBarcode.Trim().ToUpper() != productParameters.Finger1Barcode.Trim().ToUpper()) //Same as what we have defined in Product Parameter
                                {
                                    strResult = "0"; //Fail
                                    UpdateLogMessage(String.Format("Gripper Left Finger barcode validation Fail. Reply Value = {0},Sending Fail to robot", strResult));

                                    lock (lockRobot1)
                                    {
                                        robotController.SendCmd2Robot(0, 0, RobotCommandConst.VReplyBarcode, strResult);//0=fail; 1= pass
                                    }
                                }
                                else
                                {
                                    strResult = "1"; //Pass
                                    UpdateLogMessage(String.Format("Gripper Left Finger barcode validation Pass. Reply Value = {0},Sending Pass to robot", strResult));

                                    lock (lockRobot1)
                                    {
                                        robotController.SendCmd2Robot(0, 0, RobotCommandConst.VReplyBarcode, strResult);//0=fail; 1= pass
                                    }
                                }
                            }
                            break;
                            #endregion
                        }
                    case 2://RIGHT GRIPPER (Finger 2) DURABLE VALIDATION
                        {
                            #region "DURABLE VALIDATION"

                            string strResult;
                            string strBarcode;

                            if (machineParameters.ComSetting.Com1ScannerModel == 0)
                            {
                                strBarcode = Keyscanners[1].Decode();
                            }
                            else if (machineParameters.ComSetting.Com1ScannerModel == 1)
                            {
                                strBarcode = Sickscanners[1].Decode();
                            }
                            else
                            {
                                strBarcode = hikscannerTCP.TCPIntialize(1, machineParameters);
                            }
                            UpdateLogMessage(String.Format("Gripper Right Finger barcode value is {0} ", strBarcode));

                            if ((strBarcode.Equals("Error Time Out")) || (strBarcode.Length < 1) || (strBarcode.ToUpper().Contains("ERROR")))
                            {
                                strResult = "0"; //Fail
                                UpdateLogMessage(String.Format("Gripper Right Finger barcode read Fail. Reply Value = {0},Sending Fail to robot", strResult));

                                lock (lockRobot1)
                                {
                                    robotController.SendCmd2Robot(0, 0, RobotCommandConst.VReplyBarcode, strResult);//0=fail; 1= pass
                                }
                            }
                            else
                            {
                                if (strBarcode.Trim().ToUpper() != productParameters.Finger2Barcode.Trim().ToUpper()) //Same as what we have defined in Product Parameter
                                {
                                    strResult = "0"; //Fail
                                    UpdateLogMessage(String.Format("Gripper Right Finger barcode validation Fail. Reply Value = {0},Sending Fail to robot", strResult));

                                    lock (lockRobot1)
                                    {
                                        robotController.SendCmd2Robot(0, 0, RobotCommandConst.VReplyBarcode, strResult);//0=fail; 1= pass
                                    }
                                }
                                else
                                {
                                    strResult = "1"; //Pass
                                    UpdateLogMessage(String.Format("Gripper Right Finger barcode validation Pass. Reply Value = {0},Sending Pass to robot", strResult));

                                    lock (lockRobot1)
                                    {
                                        robotController.SendCmd2Robot(0, 0, RobotCommandConst.VReplyBarcode, strResult);//0=fail; 1= pass
                                    }
                                }
                            }
                            break;
                            #endregion
                        }
                    case 3://TRAY VALIDATION
                        {
                            #region "TRAY VALIDATION"
                            string strResult;
                            string strTrayId = "";
                            bool IsMatched = false;

                            if (machineParameters.ComSetting.Com1ScannerModel == 0)
                            {
                                strTrayId = Keyscanners[1].Decode();
                            }
                            else if (machineParameters.ComSetting.Com1ScannerModel == 1)
                            {
                                strTrayId = Sickscanners[1].Decode();
                            }
                            else
                            {
                                strTrayId = hikscannerTCP.TCPIntialize(1, machineParameters);
                            }
                            UpdateLogMessage(String.Format("Tray barcode value is {0} ", strTrayId));

                            if ((strTrayId.Equals("Error Time Out")) || (strTrayId.Length < 1) || (strTrayId.ToUpper().Contains("ERROR")))
                            {
                                strResult = "0"; //Fail
                                UpdateLogMessage(String.Format("Tray barcode read Fail. Reply Value = {0},Sending Fail to robot", strResult));

                                lock (lockRobot1)
                                {
                                    robotController.SendCmd2Robot(0, 0, RobotCommandConst.VReplyBarcode, strResult);//0=fail; 1= pass
                                }
                            }
                            else
                            {
                                int PrefixLength = productParameters.InputTrayPartNumber.ToUpper().Trim().Length;
                                for (int i = 0; i < strTrayId.Length; i++)
                                {
                                    if (PrefixLength > 0)
                                    {
                                        if (productParameters.InputTrayPartNumber.ToUpper().Trim() == strTrayId.ToUpper().Substring(0, PrefixLength))
                                        {
                                            if (productParameters.InputTrayPartNumber.ToUpper().Trim() == (strTrayId.ToUpper().Trim().Replace(strTrayId.Trim().Substring(0, PrefixLength), "")).Trim())
                                            {
                                                UpdateLogMessage("Tray barcode prefix excluded");
                                                IsMatched = true;
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        UpdateLogMessage("Tray barcode is new format but product file prefix is empty.");
                                        if (productParameters.TrayBarcode.ToUpper().Trim() == strTrayId.ToUpper().Trim())
                                        {
                                            IsMatched = true;
                                            break;
                                        }
                                    }
                                }

                                if (!IsMatched)
                                {
                                    strResult = "0"; //Fail
                                    UpdateLogMessage(String.Format("Tray barcode validation Fail. Reply Value = {0},Sending Fail to robot", strResult));

                                    lock (lockRobot1)
                                    {
                                        robotController.SendCmd2Robot(0, 0, RobotCommandConst.VReplyBarcode, strResult);//0=fail; 1= pass
                                    }
                                }
                                else
                                {
                                    strResult = "1"; //Pass
                                    UpdateLogMessage(String.Format("Tray barcode validation Pass. Reply Value = {0},Sending Pass to robot", strResult));

                                    lock (lockRobot1)
                                    {
                                        robotController.SendCmd2Robot(0, 0, RobotCommandConst.VReplyBarcode, strResult);//0=fail; 1= pass
                                    }
                                }
                            }
                            break;
                            #endregion
                        }
                    case 4://PALLET VALIDATION
                        {
                            #region "PALLET VALIDATION"
                            string strResult;
                            string strPalletId = "";

                            if (machineParameters.ComSetting.Com1ScannerModel == 0)
                            {
                                strPalletId = Keyscanners[1].Decode();
                            }
                            else if (machineParameters.ComSetting.Com1ScannerModel == 1)
                            {
                                strPalletId = Sickscanners[1].Decode();
                            }
                            else
                            {
                                strPalletId = hikscannerTCP.TCPIntialize(1, machineParameters);
                            }
                            UpdateLogMessage(String.Format("Pallet barcode value is {0} ", strPalletId));

                            if ((strPalletId.Equals("Error Time Out")) || (strPalletId.Length < 1) || (strPalletId.ToUpper().Contains("ERROR")))
                            {
                                strResult = "0"; //Fail
                                UpdateLogMessage(String.Format("Pallet barcode read Fail. Reply Value = {0},Sending Fail to robot", strResult));

                                lock (lockRobot1)
                                {
                                    robotController.SendCmd2Robot(0, 0, RobotCommandConst.VReplyBarcode, strResult);//0=fail; 1= pass
                                }
                            }
                            else
                            {
                                if (strPalletId.Trim().ToUpper() != productParameters.TrayBarcode.Trim().ToUpper()) //Same as what we have defined in Product Parameter
                                {
                                    strResult = "0"; //Fail
                                    UpdateLogMessage(String.Format("Pallet barcode validation Fail. Reply Value = {0},Sending Fail to robot", strResult));

                                    lock (lockRobot1)
                                    {
                                        robotController.SendCmd2Robot(0, 0, Entity.RobotCommandConst.VReplyBarcode, strResult);//0=fail; 1= pass
                                    }
                                }
                                else
                                {
                                    strResult = "1"; //Pass
                                    UpdateLogMessage(String.Format("Pallet barcode validation Pass. Reply Value = {0},Sending Pass to robot", strResult));

                                    lock (lockRobot1)
                                    {
                                        robotController.SendCmd2Robot(0, 0, Entity.RobotCommandConst.VReplyBarcode, strResult);//0=fail; 1= pass
                                    }
                                }
                            }
                            break;
                            #endregion
                        }
                    case 5://PCB VALIDATION
                        {
                            #region "PCB VALIDATION"
                            string strResult;
                            string strPanelId = "";

                            if (machineParameters.ComSetting.Com1ScannerModel == 0)
                            {
                                strPanelId = Keyscanners[1].Decode();
                            }
                            else if (machineParameters.ComSetting.Com1ScannerModel == 1)
                            {
                                strPanelId = Sickscanners[1].Decode();
                            }
                            else
                            {
                                strPanelId = hikscannerTCP.TCPIntialize(1, machineParameters);
                            }
                            UpdateLogMessage(String.Format("Panel barcode value is {0} ", strPanelId));

                            if ((strPanelId.Equals("Error Time Out")) || (strPanelId.Length < 1) || (strPanelId.ToUpper().Contains("ERROR")))
                            {
                                strResult = "0"; //Fail
                                UpdateLogMessage(String.Format("Panel barcode read Fail. Reply Value = {0},Sending Fail to robot", strResult));

                                lock (lockRobot1)
                                {
                                    robotController.SendCmd2Robot(0, 0, Entity.RobotCommandConst.VReplyBarcode, strResult);//0=fail; 1= pass
                                }
                            }
                            else
                            {
                                strResult = "1"; //Pass
                                UpdateLogMessage(String.Format("Panel barcode validation Pass. Reply Value = {0},Sending Pass to robot", strResult));

                                lock (lockRobot1)
                                {
                                    robotController.SendCmd2Robot(0, 0, Entity.RobotCommandConst.VReplyBarcode, strResult);//0=fail; 1= pass
                                }
                            }
                            break;
                            #endregion
                        }
                }

            }
            catch (Exception ex)
            {
                UpdateLogMessage("Exception in ScanBarcode(): " + ex.Message);
            }
        }




        #endregion
        private void ConfigureControls()
        {
            try
            {

                //user level 0 - operator, 1 - technician, 2 - engineer, 3 - service, 4 - developer
                menuProduct.Visibility = System.Windows.Visibility.Visible;
                menuLoadProduct.Visibility = System.Windows.Visibility.Visible;

                if (iCurrentUserLevel > 0)
                {
                    menuEditProduct.Visibility = System.Windows.Visibility.Visible;
                    menuNewProduct.Visibility = System.Windows.Visibility.Visible;
                }
                else
                {
                    menuEditProduct.Visibility = System.Windows.Visibility.Collapsed;
                    menuNewProduct.Visibility = System.Windows.Visibility.Collapsed;
                }
                if (robotController != null)
                {
                    if (iCurrentUserLevel > 0 && robotController.IsConnected)
                    {
                        menuUtilities.Visibility = System.Windows.Visibility.Visible;
                        menuManualUtility.Visibility = System.Windows.Visibility.Visible;
                        menuIo_load.Visibility = System.Windows.Visibility.Visible;

                    }
                    else
                    {
                        menuUtilities.Visibility = System.Windows.Visibility.Collapsed;
                        menuManualUtility.Visibility = System.Windows.Visibility.Collapsed;
                        menuIo_load.Visibility = System.Windows.Visibility.Collapsed;

                        MachineSettings.Visibility = System.Windows.Visibility.Collapsed;
                    }
                }

                if (iCurrentUserLevel > 1)
                {
                    menuService.Visibility = System.Windows.Visibility.Visible;
                    if (robotController == null)
                    {
                        menuRobotTeachUtil.Visibility = Visibility.Collapsed;
                        ServerDriveUtil.Visibility = Visibility.Collapsed;
                        TooltipCaliUtil.Visibility = Visibility.Collapsed;
                    }
                    menuManageUser.Visibility = System.Windows.Visibility.Visible;
                    MachineSettings.Visibility = System.Windows.Visibility.Visible;
                }
                else
                    menuManageUser.Visibility = System.Windows.Visibility.Collapsed;
                if (robotController != null)
                {
                    if (iCurrentUserLevel > 2 && robotController.IsConnected)
                    {
                        menuService.Visibility = System.Windows.Visibility.Visible;
                        menuRobotTeachUtil.Visibility = System.Windows.Visibility.Visible;
                        MachineSettings.Visibility = System.Windows.Visibility.Visible;
                        if (machineParameters.IsModBusTrue)
                        {
                            ServerDriveUtil.Visibility = System.Windows.Visibility.Visible;
                        }
                        TooltipCaliUtil.Visibility = System.Windows.Visibility.Visible;
                        checkboxDryRun.Visibility = System.Windows.Visibility.Visible;
                        checkboxSelfRun.Visibility = System.Windows.Visibility.Visible;
                        sp_sliderRobotSpeed.Visibility = System.Windows.Visibility.Visible;
                    }
                    else if (iCurrentUserLevel > 2)
                    {
                        menuService.Visibility = System.Windows.Visibility.Visible;
                        menuRobotTeachUtil.Visibility = System.Windows.Visibility.Collapsed;
                        TooltipCaliUtil.Visibility = System.Windows.Visibility.Collapsed;
                        MachineSettings.Visibility = System.Windows.Visibility.Visible;
                    }
                    else
                    {
                        menuService.Visibility = System.Windows.Visibility.Collapsed;
                        menuRobotTeachUtil.Visibility = System.Windows.Visibility.Collapsed;
                        ServerDriveUtil.Visibility = System.Windows.Visibility.Collapsed;
                    }
                    if (robotController != null)
                    {
                        if (robotController.IsConnected)
                        {
                            wrapMachineOperations.Visibility = System.Windows.Visibility.Visible;
                            ServerDriveUtil.Visibility = System.Windows.Visibility.Visible;
                        }
                        else
                        {
                            wrapMachineOperations.Visibility = System.Windows.Visibility.Collapsed;
                            ServerDriveUtil.Visibility = System.Windows.Visibility.Collapsed;
                        }
                    }
                }
                else
                    MachineSettings.Visibility = System.Windows.Visibility.Collapsed;

                if (xySoftConn.bEqRemote)
                {
                    buttonRun.IsEnabled = false;
                    buttonLoadBatch.IsEnabled = false;
                    checkboxSelfRun.IsChecked = false;
                    checkboxDryRun.IsChecked = false;

                }
                else
                {
                    buttonRun.IsEnabled = true;
                    buttonLoadBatch.IsEnabled = true;
                    checkboxDryRun.IsEnabled = true;
                    checkboxSelfRun.IsEnabled = true;

                    
                    buttonStop.IsEnabled = false;
                    if (!bVerifyDone)
                    {
                        buttonRun.IsEnabled = false;
                        buttonStop.IsEnabled = false;
                    }

                    if (bBatchStarted && bVerifyDone)
                    {
                        buttonRun.IsEnabled = false;
                        buttonStop.IsEnabled = true;
                    }
                }

                if (bBatchStarted)
                {
                    checkboxDryRun.IsEnabled = false;
                    checkboxSelfRun.IsEnabled = false;
                }
            }
            catch (Exception ex)
            {
                UpdateLogMessage("Exception in ConfigureControls(): " + ex.Message);
                MessageBox.Show("Exception in ConfigureControls(): " + ex.Message);
            }
        }
        private void dispatcherTimerRobotStatusRead_Tick(object sender, EventArgs e)
        {
            try
            {
                //trigger to get pause and door open state
                lock (lockRobot1)
                {
                    if (robotController.IsConnected)
                        robotController.SendCmd2Robot(0, 0, RobotCommandConst.VChkStatus);
                }

                //MachineStateWindow
                if (machineState.IsPause || machineState.IsDoorOpen)
                {
                    machineStateWindow.Visibility = System.Windows.Visibility.Visible;
                    if (machineState.IsPause)
                    {
                        machineStateWindow.textBlockPause.Visibility = System.Windows.Visibility.Visible;
                    }
                    else
                    {
                        machineStateWindow.textBlockPause.Visibility = System.Windows.Visibility.Collapsed;
                    }

                    if (machineState.IsDoorOpen)
                    {
                        machineStateWindow.textBlockDoorOpen.Visibility = System.Windows.Visibility.Visible;
                    }
                    else
                    {
                        machineStateWindow.textBlockDoorOpen.Visibility = System.Windows.Visibility.Collapsed;
                    }
                }
                else
                {
                    machineStateWindow.Visibility = System.Windows.Visibility.Hidden;
                }


                //MachineStateWindow
                if (machineState.IsPause || machineState.IsDoorOpen)
                {
                    machineStateWindow.Visibility = System.Windows.Visibility.Visible;
                    if (machineState.IsPause)
                    {
                        machineStateWindow.textBlockPause.Visibility = System.Windows.Visibility.Visible;
                    }
                    else
                    {
                        machineStateWindow.textBlockPause.Visibility = System.Windows.Visibility.Collapsed;
                    }

                    if (machineState.IsDoorOpen)
                    {
                        machineStateWindow.textBlockDoorOpen.Visibility = System.Windows.Visibility.Visible;
                    }
                    else
                    {
                        machineStateWindow.textBlockDoorOpen.Visibility = System.Windows.Visibility.Collapsed;
                    }
                }
                else
                {
                    machineStateWindow.Visibility = System.Windows.Visibility.Hidden;
                }

            }
            catch (Exception ex)
            {
                UpdateLogMessage("Exception in dispatcherTimerRobotStatusRead: " + ex.Message);
                MessageBox.Show("Exception in dispatcherTimerRobotStatusRead: " + ex.Message);
            }
        }
        private void UserLogout_Click(object sender, RoutedEventArgs e)
        {
            iCurrentUserLevel = 0;
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate ()
            {
                ConfigureControls();
            });
        }

        public bool ModbusCommConnect()
        {
            try
            {
                ModbusMotionControl = new ModbusMotionControl(machineParameters.NoOfDeltaAxis + 1);
                AxesData = new AxisData[machineParameters.NoOfDeltaAxis + 1];

                for (int i = 1; i < machineParameters.NoOfDeltaAxis + 1; i++)
                {
                    //  ModbusMotionControl.ModbusSetParameters[i] = new ModbusDeltaSetParameters();

                    ModbusMotionControl.ModbusSetParameters[i] = new ModbusFujiSetParameters();
                    AxesData[i] = new AxisData();
                    AxesData[i].RefMovement = deltaServoAxisData.deltaAxis[i - 1].RefMov; // 78.0
                    AxesData[i].RefPulses = deltaServoAxisData.deltaAxis[i - 1].Refpulse; //100000;
                }

                ModbusComm.RsData.ComPort = deltaServoAxisData.Comport;
                ModbusComm.RsData.Baudrate = deltaServoAxisData.Baudrate;
                ModbusComm.RsData.DataBits = deltaServoAxisData.Databits;
                ModbusComm.RsData.Parity = System.IO.Ports.Parity.Even;
                ModbusComm.RsData.Stopbits = System.IO.Ports.StopBits.Two;


                for (int i = 1; i < machineParameters.NoOfDeltaAxis + 1; i++)
                {
                    ModbusMotionControl.ModbusSetParameters[i].ModbusComm = ModbusComm;
                    ModbusMotionControl.ModbusSetParameters[i].AxisAddress = i;
                    ModbusMotionControl.AxisData[i] = AxesData[i];
                }

                return ModbusComm.Connect();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception in ModbusCommConnect: " + ex.Message);
                UpdateLogMessage("Error: Exception in ModbusCommConnect: " + ex.Message);
            }
            return false;
        }

        public bool ModbusCommDisconnect()
        {
            try
            {
                ModbusComm.Disconnect();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Exception in ModbusCommDisconnect: " + ex.Message);
                UpdateLogMessage("Error: Exception in ModbusCommDisconnect: " + ex.Message);
            }
            return true;
        }
       
        private void LoadSystemParameters()
        {
            try
            {
                //SystemParameterData = SystemParameter.DeserializeXML();
                SystemParameterData = Serializer.Load(machineParameters.MachineType);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #region "ROBOT EVENTS"

        //Robot intiated functions
        void robotController_OnCommDeviceConnected(bool IsConnected)
        {
            try
            {
                if (IsConnected)
                    this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate ()
                    {
                        labelRobotConnection1.Content = "Robot 1 Connected";
                        labelRobotConnection1.Foreground = Brushes.Green;
                        connectionStatusImage.Source = new BitmapImage(new Uri("pack://application:,,,/Images/RoboticConnected.png", UriKind.Absolute));
                        ConfigureControls();
                    });
                else
                    this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate ()
                    {
                        labelRobotConnection1.Content = "Robot 1 Disconnected";
                        labelRobotConnection1.Foreground = Brushes.Red;
                        connectionStatusImage.Source = new BitmapImage(new Uri("pack://application:,,,/Images/RoboticNotConnected.png", UriKind.Absolute));
                        ConfigureControls();
                        //CloseHomeProgressLoader();
                    });
            }
            catch (Exception ex)
            {
                UpdateLogMessage("Exception in robotController_OnCommDeviceConnected(): " + ex.Message);

            }
        }

        void robotController_OnRobotError_Loader(RobotError error)
        {
            try
            {
                UpdateLogMessage(String.Format("ErrorResume callback called for error {0}", error.ErrorCode));
                UpdateLogMessage("No action taken in OnRobotErrorResume(). to review");
            }
            catch (Exception ex)
            {
                UpdateLogMessage("Exception in robotController_OnRobotErrorResume(): " + ex.Message);
            }
        }

        void robotController_OnRobotErrorResume_Loader(RobotError error)
        {
            try
            {
                UpdateLogMessage(String.Format("ErrorResume callback called for error {0}", error.ErrorCode));
                UpdateLogMessage("No action taken in OnRobotErrorResume(). to review");
            }
            catch (Exception ex)
            {
                UpdateLogMessage("Exception in robotController_OnRobotErrorResume(): " + ex.Message);
            }

        }

        void robotController_UpdateRobotStatus_Loader(RobotStatus status)
        {
            try
            {
                machineState.IsDoorOpen = status.IsDoorOpen;
                machineState.IsPause = status.IsPauseOn;
            }
            catch (Exception ex)
            {
                UpdateLogMessage("Exception in robotController_UpdateRobotStatus(): " + ex.Message);
            }

        }

        void robotController_OnRobotCmd_Loader(CommEventCmd cmd)
        {
            int Result = 0;
            UpdateLogMessage("Robot CMD = " + cmd.CmdList[4]);
            try
            {
                if (string.Compare(cmd.CmdList[4].ToUpper(), "MODE".ToUpper()) == 0)//All
                {
                    int.TryParse(cmd.CmdList[2], out Result);
                    robotController.ReplyCheckMode2Robot(Result, 0);
                }

                else if (string.Compare(cmd.CmdList[4].ToUpper(), "ERROR_RESUME".ToUpper()) == 0)//All
                {
                    #region ERROR_RESUME
                    string ErrorMsg = "";
                    this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate ()
                    {
                        try
                        {
                            if (dictErrorList.ContainsKey(Convert.ToInt32(cmd.CmdList[5])))
                            {
                                ErrorMsg = dictErrorList[Convert.ToInt32(cmd.CmdList[5])];
                            }

                            UpdateLogMessage(String.Format("ERROR_RESUME error code is {0}", cmd.CmdList[5]));
                            //UpdateAlarmLog(String.Format("RBT ERROR_RESUME error code is {0} with Error Message is {1}", cmd.CmdList[5], ErrorMsg));
                           // CloseErrorWindow(Convert.ToInt32(cmd.CmdList[5]));
                            // SendEventToHost(String.Format("ClearAlarm,{0}", cmd.CmdList[5]));
                        }
                        catch (Exception ex)
                        {
                            UpdateLogMessage("Exception closing error window and/or removing from dictionary. " + ex.Message);
                        }
                    });
                    #endregion
                }

                else if (string.Compare(cmd.CmdList[4].ToUpper(), "ScanBarcode".ToUpper()) == 0)//All
                {
                    int.TryParse(cmd.CmdList[5], out Result);
                    //ScanBarcode(cmd);
                }

                else if (string.Compare(cmd.CmdList[4].ToUpper(), "SystemParameter".ToUpper()) == 0)//All
                {
                    CalibrationData calData = CalibDataStream.Load(machineParameters.MachineType);
                    RobotStream.SendSysParameter(calData, robotController, productParameters, machineParameters);
                    robotController.SendCmd2Robot(0, 0, RobotCommandConst.VSendSysParameter);
                }

                else if (string.Compare(cmd.CmdList[4].ToUpper(), "ProductData".ToUpper()) == 0)//All
                {
                    #region ProductData
                    RobotStream.SendPanelInfo(productParameters, robotController);
                    RobotStream.SendProductDataGAL(productParameters, robotController, machineParameters);
                    robotController.SendCmd2Robot(0, 0, RobotCommandConst.VSendProductData, "1");
                    #endregion
                }

                else if (string.Compare(cmd.CmdList[4].ToUpper(), "Home".ToUpper()) == 0)//All
                {
                    #region
                    bHomeDone = false;
                    bBatchStarted = false;
                    bVerifyDone = false;
                    //ShowHomeProgressLoader();
                    #endregion
                }

                else if (string.Compare(cmd.CmdList[4].ToUpper(), "HomeDone".ToUpper()) == 0)//All
                {
                    bHomeDone = true;
                    //CloseHomeProgressLoader();
                }

                else if (string.Compare(cmd.CmdList[4].ToUpper(), "VerifyDone".ToUpper()) == 0)//All
                {
                    #region
                    bVerifyDone = true;
                    bBatchStarted = false;
                    this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate ()
                    {
                        ConfigureControls();
                    });
                    #endregion
                }

                else if (string.Compare(cmd.CmdList[4].ToUpper(), "StopDone".ToUpper()) == 0)//ALL
                {
                    //bVerifyDone = false;
                    bBatchStarted = false;
                    this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate ()
                    {
                        ConfigureControls();
                    });
                }

                else if (string.Compare(cmd.CmdList[4].ToUpper(), "PCBPlaced".ToUpper()) == 0)//ALL
                {
                    UpdateLogMessage(String.Format("PCB has arrived to shuttle axis."));
                }

                else if (string.Compare(cmd.CmdList[4].ToUpper(), "PalletComplete".ToUpper()) == 0)//ALL
                {
                    UpdateLogMessage(String.Format("Pallet has completedly placed."));
                }

                else if (string.Compare(cmd.CmdList[4].ToUpper(), "PalletReturn".ToUpper()) == 0)//ALL
                {
                    UpdateLogMessage(String.Format("Pallet has returned to place."));
                }

                else
                {
                    //Note: This should not be set true if not processed.
                    //cmd.IsProcessed = true;
                    return;
                }

                cmd.IsProcessed = true;
            }
            catch (Exception ex)
            {
                UpdateLogMessage(String.Format("Exception: {0} while processing robot cmd {1}", ex.Message, cmd.CmdList[4]));
            }

        }





        #endregion
        private void MenuMachineSetting_Click(object sender, RoutedEventArgs e)
        {
            var AboutWindow = new MachineNewGUI.Service.MachineSetting(); // Use the correct namespace if needed
            AboutWindow.Owner = this;
            AboutWindow.ShowDialog(); // Or use Show() if you don’t want modal

        }
        private void DeleteJsonFilesOnStartup()
        {
            string appDirectory = AppDomain.CurrentDomain.BaseDirectory;

            var jsonFiles = Directory.GetFiles(appDirectory, "*.json", SearchOption.TopDirectoryOnly);
            foreach (var file in jsonFiles)
            {
                try
                {
                    File.Delete(file);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exception Message :"+ex.Message);
                }
            }
        }
        private void MenuLoadProduct_Click(object sender, RoutedEventArgs e)
        {
            string str = string.Empty;
            string selectedFile = string.Empty;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = MachineGUIDirectroy + @"\Product Files"; //@"C:\router\Product File";
            openFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
            openFileDialog.Title = "Select a Product JSON file";
            string model = string.Empty;
            bool? result = openFileDialog.ShowDialog();

            if (result == true)
            {
                selectedFile = openFileDialog.FileName;
                model = System.IO.Path.GetFileNameWithoutExtension(openFileDialog.FileName);
                productParameters = ProductStream.Load(model);
                Internalmachinestatemanagent.LastProduct = model;
                InternalMemoryStateManagementConfigStream.Save(Internalmachinestatemanagent);
                str = MachineGUIDirectroy+@"\Product Files\" + model+".json";
                txtProductName.Content = str;
                RecipeCreate_Modified_Loaded(Internalmachinestatemanagent.LastProduct, "LOADED");

            }
        }
        private void MenuHelp_Click(object sender, RoutedEventArgs e)
        {
            var AboutWindow = new MachineNewGUI.Help.About(); // Use the correct namespace if needed
            AboutWindow.Owner = this;
            AboutWindow.ShowDialog(); // Or use Show() if you don’t want modal

        }
        void RecipeCreate_Modified_Loaded(string RecipeName, string Type)
        {

                if (Type == "CREATED")
                {
                   // xySoftConn.RecipeCreated(RecipeName);
                    UpdateLogMessage($"{DateTime.Now:HH:mm:ss.fff}> " + String.Format("RecipeCreated : RecipeName = {0} ,Sent to host", RecipeName));
                }
                else if (Type == "MODIFIED")
                {
                    //xySoftConn.RecipeModified(RecipeName);
                    UpdateLogMessage($"{DateTime.Now:HH:mm:ss.fff}> " + String.Format("RecipeModified : RecipeName = {0} ,Sent to host", RecipeName));
                }
                else if (Type == "LOADED")
                {
                    //xySoftConn.RecipeLoaded(RecipeName);
                    UpdateLogMessage($"{DateTime.Now:HH:mm:ss.fff}> " + String.Format("RecipeLoaded : RecipeName = {0} ,Sent to host", RecipeName));
                }
            
        }
        private void MenuRobotTechUtil_Click(object sender, RoutedEventArgs e)
        {
            var TeachUtilityWindow = new MachineNewGUI.Service.TeachUtility(); // Use the correct namespace if needed
            TeachUtilityWindow.Owner = this;
            TeachUtilityWindow.ShowDialog(); // Or use Show() if you don’t want modal

        }
        private void MenuNewProduct_Click(object sender, RoutedEventArgs e)
        {
            var InputDialogWindow = new MachineNewGUI.Product.InputDialog();
            InputDialogWindow.Owner = this;
            InputDialogWindow.ProductCreated += MainWindow_ProductReceived; // subscribe first
            InputDialogWindow.ShowDialog();

        }
        private void MainWindow_ProductReceived(InternalMemoryStateManagement memory)
        {
            if (memory.isCreateProduct)
            {
                Internalmachinestatemanagent.LastProduct = memory.LastProduct; 
                Internalmachinestatemanagent.LastReservation = memory.LastReservation;
                InternalMemoryStateManagementConfigStream.Save(Internalmachinestatemanagent);
                string str = MachineGUIDirectroy + @"\Product File\" + Internalmachinestatemanagent.LastProduct + ".json";
                txtProductName.Content = str;
                RecipeCreate_Modified_Loaded(Internalmachinestatemanagent.LastProduct, "CREATED");
            }
        }
        private void MenuEditProduct_Click(object sender, RoutedEventArgs e)
        {

                if (productParameters == null)
                {
                    productParameters = new ProductParameters();
                }
                //EditProduct editForm = new EditProduct(Internalmachinestatemanagent.LastProduct, productParameters, machineParameters, Internalmachinestatemanagent, Internalmachinestatemanagent.LastProduct);
                EditProduct editForm = new EditProduct(Internalmachinestatemanagent.LastProduct);
                editForm.ShowDialog();
                productParameters = ProductStream.Load(Internalmachinestatemanagent.LastProduct);
                RecipeCreate_Modified_Loaded(Internalmachinestatemanagent.LastProduct, "MODIFIED");
 
        }
        private void menuManageUser_Click(object sender, RoutedEventArgs e)
        {
            UserAuthentication.ManageUser();
            //var manageUserWindow = new MachineNewGUI.UserManagement.ManageUser(); // Use the correct namespace if needed
            //manageUserWindow.Owner = this;
            //manageUserWindow.ShowDialog(); // Or use Show() if you don’t want modal

        }
        private void menuIOUtility_Click(object sender, RoutedEventArgs e)
        {
            var IOUtilityWindow = new MachineNewGUI.Utilities.IOUtility(); 
            IOUtilityWindow.Owner = this;
            IOUtilityWindow.ShowDialog(); 

        }
        private void menuManualUtility_Click(object sender, RoutedEventArgs e)
        {
            var utilityWindow = new MachineNewGUI.Utilities.MannualUtilities();
            utilityWindow.Owner = this;
            utilityWindow.ShowDialog();
        
        }
        private void UserLogin_Click(object sender, RoutedEventArgs e)
        {
            iCurrentUserLevel = 0;
            iCurrentUserLevel = UserAuthentication.Login();

            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate ()
            {
                ConfigureControls();
            });
        }
        private void UpdateLogMessage(string logEntry)
        {

                logEntry = $"{DateTime.Now:HH:mm:ss.fff}> " + logEntry;
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        while (textboxLog.Text.Length > 10000)
                        {

                            string str1;
                            str1 = textboxLog.Text.Remove(0, 100);
                            textboxLog.Text = str1;
                        }
                        textboxLog.Text = logEntry + "\n" + textboxLog.Text; // Append new log at the top
                        textboxLog.CaretIndex = 0;  // Move caret to the start
                        textboxLog.ScrollToHome();  // Ensure scrollbar stays at the top
                    });

        }


    }
}
