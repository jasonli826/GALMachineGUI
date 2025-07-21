using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows;

using System.Xml;
using System.Xml.Serialization;
using System.ComponentModel;
using System.Windows.Media;
using System.Collections.ObjectModel;
using JogControl;


namespace MachineNewGUI.Entity
{
    public class ProductParameters : INotifyPropertyChanged
    {
        #region PRODUCT

        public string ProductFileName { get; set; }
        public string Name { get; set; }
        public string ProductName { get; set; }
        public double Length { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public string LabelPlacementSide { get; set; }
        public string InputTrayPartNumber { get; set; }
        public string OutputTrayPartNumber { get; set; }
        public bool PreInspectionNeeded { get; set; }
        public bool[] Options { get; set; } = new bool[10];
        public string ProgressInfo { get; set; }

        #endregion

        #region INPUT TRAY

        public Tray InputTray { get; set; }
        public string TrayBarcodePrefix { get; set; }
        public string TrayBarcode { get; set; }
        public double MidBarcodeSkip { get; set; }

        #endregion

        #region OUTPUT PALLET

        public Tray AdaptorPallet { get; set; }
        public string PalletBarcode { get; set; }
        public string PalletBarcodeDelimiter { get; set; }
        public double PalletLength { get; set; }
        public double PalletHeight { get; set; }
        public double PalletWidth { get; set; }
        public double PalletConveyorAxisClampStrokeGAL { get; set; }

        #endregion

        #region GRIPPER FINGER

        public double Finger1OffsetX { get; set; }
        public double Finger1OffsetY { get; set; }
        public double Finger1OffsetZ { get; set; }
        public double Finger1OffsetU { get; set; }
        public string Finger1Barcode { get; set; }

        public double Finger2OffsetX { get; set; }
        public double Finger2OffsetY { get; set; }
        public double Finger2OffsetZ { get; set; }
        public double Finger2OffsetU { get; set; }
        public string Finger2Barcode { get; set; }

        #endregion

        #region SERVO AXIS OFFSET

        public double Axis3ServoTraySingulatePos2GAL { get; set; }

        #endregion

        #region TIMERS
        public JogControl.RobotPoint GALTimer { get; set; }
        #endregion

        public LeftTable LeftTable { get; set; }
        public RightTable RightTable { get; set; }
        public ProductParameters()
        {
            InputTray = new Tray();
            ProductFileName = string.Empty;
            Name = string.Empty;
            ProductName = string.Empty;
            ProgressInfo = "Downloading System and Product Parameters";
            Length = 1;
            Height = 2.15;
            Width = 2;
            AdaptorPallet = new Tray();
            //GALTool1XOffset = 0;
            //GALTool1YOffset = 0;
            //GALTool1ZOffset = 0;
            //GALTool1UOffset = 0;
            //GALTool2XOffset = 0;
            //GALTool2YOffset = 0;
            //GALTool2ZOffset = 0;
            //GALTool2UOffset = 0;
            //GALTool3XOffset = 0;
            //GALTool3YOffset = 0;
            //GALTool3ZOffset = 0;
            //GALTool3UOffset = 0;
            TrayBarcodePrefix = "";
            TrayBarcode = "";
            PalletBarcode = "";
            PalletConveyorAxisClampStrokeGAL = 0.5;
            Axis3ServoTraySingulatePos2GAL = 0;
            Finger1OffsetX = 0;
            Finger1OffsetY = 0;
            Finger1OffsetZ = 0;
            Finger1OffsetU = 0;
            Finger2OffsetX = 0;
            Finger2OffsetY = 0;
            Finger2OffsetZ = 0;
            Finger2OffsetU = 0;
            Finger1Barcode = "Finger1Barcode";
            Finger2Barcode = "Finger2Barcode";
            MidBarcodeSkip = 0; //Default Scanning Board
            GALTimer = new JogControl.RobotPoint();
            GALTimer.PointNum = 40;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }
    }

    public class Tray : INotifyPropertyChanged
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        public double RowPitch { get; set; }
        public double ColumnPitch { get; set; }
        public double RowOffset { get; set; }
        public double ColumnOffset { get; set; }

        #region INPUT TRAY

        public double ModuleZOffset { get; set; }
        public double ModuleOrientation { get; set; }

        //Input Tray Barcode Offset
        public RobotPoint BarcodeOffset_Points { get; set; } = new RobotPoint();
        public RobotPoint ModuleBarcode_Points { get; set; } = new RobotPoint();

        #endregion

        #region OUTPUT PALLET

        //Pallet Barcode Offset
        public double BarcodeOffsetX { get; set; }
        public double BarcodeOffsetY { get; set; }
        public double BarcodeOffsetZ { get; set; }
        public double BarcodeOffsetU { get; set; }

        //Pallet Checkspot
        public RobotPoint CheckSpot1Offset { get; set; } = new RobotPoint();
        public RobotPoint CheckSpot2Offset { get; set; } = new RobotPoint();
        public RobotPoint CheckSpot3Offset { get; set; } = new RobotPoint();
        public RobotPoint CheckSpot4Offset { get; set; } = new RobotPoint();
        public RobotPoint CheckSpotEnable { get; set; } = new RobotPoint(); //X=Chk1,Y=Chk2,Z=Chk3,U=Chk4; 0=Disable, 1=Enable
        public RobotPoint CheckSpotPosOnOff { get; set; } = new RobotPoint(); //X=UpperLeftPos,Y=UpperRightPos,Z=BtmLeftPos,U=BtmRightPos; 0=OffCheck, 1=OnCheck
        public double ThicknessDiffMM { get; set; }//Thickness Difference in MM
        //public double CheckSpotAllEnable { get; set; }

        //Pallet OnFly Checkspot
        public RobotPoint FlyCheckSpot1Offset { get; set; } = new RobotPoint();
        public RobotPoint FlyCheckSpot2Offset { get; set; } = new RobotPoint();
        public RobotPoint FlyCheckSpot3Offset { get; set; } = new RobotPoint();
        public RobotPoint FlyCheckSpot4Offset { get; set; } = new RobotPoint();
        public double FlyCheckSpotEnable { get; set; } //0=Disable, 1=Enable
        public double FlyCheckSpeed { get; set; } //100-800mm/s
        public double CheckDelta { get; set; }//0.5-1.5mm for sensor On-Off
        #endregion

        #region PLACEMENT & PICK

        //For Placement & Pick, I tried 2 ways:
        //1) Using single Robotpoint to represent 4 offsets.
        //2) Declare 4 individual offsets.
        public RobotPoint PlacementOffset { get; set; } = new RobotPoint();
        public double GripperPickOffsetX { get; set; }
        public double GripperPickOffsetY { get; set; }
        public double GripperPickOffsetZ { get; set; }
        public double GripperPickOffsetU { get; set; }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }
    }

    public class ProductStream
    {
        public static string strFolder = @"C:/GAL/Product Files/";

        public static void Save(string ProductName, ProductParameters product)
        {
            //validation
            if (product == null)
                return;


            string strPath = strFolder + ProductName + ".xml";

            //create folder
            if (!Directory.Exists(System.IO.Path.GetDirectoryName(strPath)))
                Directory.CreateDirectory(System.IO.Path.GetDirectoryName(strPath));

            //save product
            try
            {
                using (FileStream fs = new FileStream(strPath, FileMode.Create, FileAccess.Write))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(ProductParameters));

                    TextWriter writer = new StreamWriter(fs);
                    serializer.Serialize(writer, product);
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception saving product to file: " + ex.Message);
            }
        }

        public static ProductParameters Load(string name)
        {
            //validation
            if (name == null)
            {
                name = "New Product";
            }

            if (name.Length == 0)
            {
                name = "New Product";
            }

            string strPath = strFolder + name + ".xml";

            ProductParameters product = null;
            //save if file does not exist
            if ((!Directory.Exists(System.IO.Path.GetDirectoryName(strPath)) || (!File.Exists(strPath))))
            {

                product = new ProductParameters();
            }

            //loading
            try
            {
                using (FileStream fs = new FileStream(strPath, FileMode.Open, FileAccess.Read))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(ProductParameters));

                    TextReader reader = new StreamReader(fs);
                    product = (ProductParameters)serializer.Deserialize(reader);
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception loading product file: " + ex.Message);
            }
            return product;
        }
    }

}
