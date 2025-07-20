using APILXYSoftCommunication;
using CommControlLib;
using MachineNewGUI.Entity;
using MachineNewGUI.Product;
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

namespace MachineNewGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EpsonRobotController robotController;
        private string FirstMessage = $"{DateTime.Now:HH:mm:ss.fff}> Application started\n" +
                                     $"{DateTime.Now:HH:mm:ss.fff}> Getech Automatic Loader  -  Version: 1.0.0.1\n";
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


        //SECS/GEM interface   
        XYSoftConn xySoftConn = new XYSoftConn();


        //SCANNER
        //KeyenceScanner[] Keyscanners = new KeyenceScanner[4]; // Index Zero Not Used
        //SICK_Scanner[] Sickscanners = new SICK_Scanner[4];// Index Zero Not Used
        HIKScannerTCP hikscannerTCP = new HIKScannerTCP();
        SystemParameter SystemParameterData;
        //Error list
        Dictionary<int, string> dictErrorList = new Dictionary<int, string>();


        //batch control flags
        DispatcherTimer dispatcherTimerRobotStatusRead = new DispatcherTimer();
        bool bBatchStarted = false;

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
        public ObservableCollection<string> LogEntries { get; set; } = new ObservableCollection<string>();
        public MainWindow()
        {
            InitializeComponent();
            UpdateLogMessage(FirstMessage);
            DeleteJsonFilesOnStartup();
            machineParameters = MachineConfigStream.Load();
            Thread EpsonSoftThread = new Thread(new ThreadStart(InitEpsonSoftware));
            EpsonSoftThread.Start();

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
                    //RobotInitializing = true;
                    //ShowWindow(Prc.Handle, 6);
                }
            }
            catch (Exception ex)
            {
                UpdateLogMessage("InitEpsonSoftware ex" + ex.Message);
            }
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
        private void UserLogout_Click(object sender, RoutedEventArgs e)
        {
            iCurrentUserLevel = 0;
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate ()
            {
                ConfigureControls();
            });
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ConstructBatchParameterObject();

            Internalmachinestatemanagent = InternalMemoryStateManagementConfigStream.Load();
            if (!string.IsNullOrEmpty(Internalmachinestatemanagent.LastProduct))
            {

                txtProductName.Content = MachineGUIDirectroy + @"\Product File\" + Internalmachinestatemanagent.LastProduct+".json";
            }
            ConfigureControls();
        } 
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
            openFileDialog.InitialDirectory = MachineGUIDirectroy + @"\Product File"; //@"C:\router\Product File";
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
                str = MachineGUIDirectroy+@"\Product File\" + model+".json";
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
            if (Internalmachinestatemanagent.isCreateProduct)
            {
                Internalmachinestatemanagent.LastProduct = memory.LastProduct; ;
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
            var manageUserWindow = new MachineNewGUI.UserManagement.ManageUser(); // Use the correct namespace if needed
            manageUserWindow.Owner = this;
            manageUserWindow.ShowDialog(); // Or use Show() if you don’t want modal

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
                    

                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        textboxLog.Text = logEntry + "\n" + textboxLog.Text; // Append new log at the top
                        textboxLog.CaretIndex = 0;  // Move caret to the start
                        textboxLog.ScrollToHome();  // Ensure scrollbar stays at the top
                    });

        }


    }
}
