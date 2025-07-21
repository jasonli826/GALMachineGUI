using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;//for INotifyPropertyChanged
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Windows;
using System.Threading;
using RobotController;
using Getech.GS.RobotController;

namespace MachineNewGUI.Entity
{
    public class CalibrationData : INotifyPropertyChanged
    {
        public LocalData Local1 { get; set; }
        public LocalData Local2 { get; set; }
        public LocalData Local3 { get; set; }
        public LocalData Local4 { get; set; }
        public LocalData Local5 { get; set; }
        public LocalData Local6 { get; set; }
        public LocalData GALTimer1 { get; set; }
        public List<RobotPoint> DatumPoints { get; set; }

        public CalibrationData()
        {
            Local1 = new LocalData();
            Local2 = new LocalData();
            Local3 = new LocalData();
            Local4 = new LocalData();
            Local5 = new LocalData();
            Local6 = new LocalData();
            GALTimer1 = new LocalData();
            DatumPoints = new List<RobotPoint>();

            Local1.WorldPoint1.PointNumber = 41;
            Local1.WorldPoint2.PointNumber = 42;
            Local1.LocalPoint1.PointNumber = 43;
            Local1.LocalPoint2.PointNumber = 44;

            Local2.WorldPoint1.PointNumber = 45;
            Local2.WorldPoint2.PointNumber = 46;
            Local2.LocalPoint1.PointNumber = 47;
            Local2.LocalPoint2.PointNumber = 48;

            GALTimer1.GALTimer.PointNumber = 25;
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

    public class LocalData
    {
        public RobotPoint WorldPoint1 { get; set; }
        public RobotPoint LocalPoint1 { get; set; }

        public RobotPoint WorldPoint2 { get; set; }
        public RobotPoint LocalPoint2 { get; set; }

        public RobotPoint GALTimer { get; set; }

        public List<RobotPoint> DatumPoints { get; set; }
     
        public LocalData()
        {
            WorldPoint1 = new RobotPoint();
            LocalPoint1 = new RobotPoint();
            WorldPoint2 = new RobotPoint();
            LocalPoint2 = new RobotPoint();
            GALTimer = new RobotPoint();
            DatumPoints = new List<RobotPoint>();
        }
    }

    public class CalibDataStream
    {
        static string strFolder = @"c:/GAL/System/";

        public static void Save(CalibrationData data, string strMachineType)
        {
            //validation
            if (data == null)
                return;

            string strPath = strFolder + "CalibrationData" + strMachineType + ".xml";
            
            //create folder
            if (!Directory.Exists(System.IO.Path.GetDirectoryName(strPath)))
                Directory.CreateDirectory(System.IO.Path.GetDirectoryName(strPath));

            //save product
            try
            {
                using (FileStream fs = new FileStream(strPath, FileMode.Create, FileAccess.Write))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(CalibrationData));

                    TextWriter writer = new StreamWriter(fs);
                    serializer.Serialize(writer, data);
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception saving Calibration to file: " + ex.Message);
            }
        }

        public static CalibrationData Load(string strMachineType)
        {
            CalibrationData data = null;

            string strPath = strFolder + "CalibrationData" + strMachineType + ".xml";            

            //save if file does not exist
            if ((!Directory.Exists(System.IO.Path.GetDirectoryName(strPath)) || (!File.Exists(strPath))))
            {
                if(!Directory.Exists(System.IO.Path.GetDirectoryName(strPath)))
                    Directory.CreateDirectory(System.IO.Path.GetDirectoryName(strPath));
                
                data = new CalibrationData();                
                
                //saving
                try
                {
                    using (FileStream fs = new FileStream(strPath, FileMode.Create, FileAccess.Write))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(CalibrationData));

                        TextWriter writer = new StreamWriter(fs);
                        serializer.Serialize(writer, data);
                        writer.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exception saving calibration file: " + ex.Message);
                }
            }           
            
            //loading
            try
            {
                using (FileStream fs = new FileStream(strPath, FileMode.Open, FileAccess.Read))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(CalibrationData));

                    TextReader reader = new StreamReader(fs);
                    data = (CalibrationData)serializer.Deserialize(reader);
                    reader.Close();                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception loading Calibration file: " + ex.Message);                
            }
            return data;        
        }
    }

    public class RobotStream
    {
        //sends local definition and datum points (cal data)
        public static void SendSysParameter(CalibrationData calData, EpsonRobotController epsonRbt_Loader, ProductParameters productParameters, MachineConfiguration MachineParameter)
        {
            //validation
            if (epsonRbt_Loader == null)
                return;
            if (!epsonRbt_Loader.IsConnected)
                return;

            JogControl.RobotPoint point = new JogControl.RobotPoint();

            #region LOCAL POINTS
            //Local 1
            calData.Local1.WorldPoint1.PointNumber = 41;
            CopyPoint(point, calData.Local1.WorldPoint1);
            epsonRbt_Loader.SendRobotPoint(point);
            calData.Local1.LocalPoint1.PointNumber = 43;
            CopyPoint(point, calData.Local1.LocalPoint1);
            epsonRbt_Loader.SendRobotPoint(point);
            calData.Local1.WorldPoint2.PointNumber = 42;
            CopyPoint(point, calData.Local1.WorldPoint2);
            epsonRbt_Loader.SendRobotPoint(point);
            calData.Local1.LocalPoint2.PointNumber = 44;
            CopyPoint(point, calData.Local1.LocalPoint2);
            epsonRbt_Loader.SendRobotPoint(point);

            //Local 2
            calData.Local2.WorldPoint1.PointNumber = 45;
            CopyPoint(point, calData.Local2.WorldPoint1);
            epsonRbt_Loader.SendRobotPoint(point);
            calData.Local2.LocalPoint1.PointNumber = 47;
            CopyPoint(point, calData.Local2.LocalPoint1);
            epsonRbt_Loader.SendRobotPoint(point);
            calData.Local2.WorldPoint2.PointNumber = 46;
            CopyPoint(point, calData.Local2.WorldPoint2);
            epsonRbt_Loader.SendRobotPoint(point);
            calData.Local2.LocalPoint2.PointNumber = 48;
            CopyPoint(point, calData.Local2.LocalPoint2);
            epsonRbt_Loader.SendRobotPoint(point);
            #endregion

            #region TIMERS
            calData.GALTimer1.GALTimer.PointNumber = 25;
            CopyPoint(point, calData.GALTimer1.GALTimer);
            epsonRbt_Loader.SendRobotPoint(point);
            #endregion

            foreach (Getech.GS.RobotController.RobotPoint rp in calData.DatumPoints)
            {
                JogControl.RobotPoint Pt = new JogControl.RobotPoint(rp.X, rp.Y, rp.Z, rp.U, rp.V, rp.W);
                Pt.Hand = rp.Hand;
                Pt.ZOff = 0; //default seems 50 
                Pt.PointNum = (int)rp.PointNumber;

                epsonRbt_Loader.SendRobotPoint(Pt);
                Thread.Sleep(100);
            }
        }

        static void CopyPoint(JogControl.RobotPoint jpoint, Getech.GS.RobotController.RobotPoint cpoint)
        {
            jpoint.PointNum = (int)cpoint.PointNumber;
            jpoint.X = cpoint.X;
            jpoint.Y = cpoint.Y;
            jpoint.Z = cpoint.Z;
            jpoint.U = cpoint.U;
            jpoint.Hand = cpoint.Hand;
        }


        //sends pallet points and product data variables
        public static void SendProductDataGAL(ProductParameters productParameters, EpsonRobotController robotController_Loader, MachineConfiguration MachineParameter)
        {
            JogControl.RobotPoint point = new JogControl.RobotPoint();

            #region ADAPTER OFFSET
            //AdapterOffset
            point.PointNum = 7;
            point.X = productParameters.AdaptorPallet.PlacementOffset.X;
            point.Y = productParameters.AdaptorPallet.PlacementOffset.Y;
            point.Z = productParameters.AdaptorPallet.PlacementOffset.Z;
            point.U = productParameters.AdaptorPallet.PlacementOffset.W;
            robotController_Loader.SendRobotPoint(point);
            Thread.Sleep(200);
            #endregion

            #region INPUT TRAY BARCODE OFFSET
            //TrayBarcode Offset
            point.PointNum = 3;
            point.X = productParameters.InputTray.BarcodeOffsetX;
            point.Y = productParameters.InputTray.BarcodeOffsetY;
            point.Z = productParameters.InputTray.BarcodeOffsetZ;
            point.U = productParameters.InputTray.BarcodeOffsetU;
            robotController_Loader.SendRobotPoint(point);
            Thread.Sleep(200);
            #endregion
            
            #region INPUT TRAY
            //InputTray Info
            point.PointNum = 9;
            point.X = productParameters.InputTray.RowPitch;
            point.Y = productParameters.InputTray.ColumnPitch;
            point.Z = productParameters.InputTray.RowOffset;
            point.U = productParameters.InputTray.ColumnOffset;
            robotController_Loader.SendRobotPoint(point);
            Thread.Sleep(200);
            #endregion

            #region OUTPUT ADAPTER PALLET
            //OutputCarrier Info
            point.PointNum = 10;
            point.X = productParameters.AdaptorPallet.RowPitch;
            point.Y = productParameters.AdaptorPallet.ColumnPitch;
            point.Z = productParameters.AdaptorPallet.RowOffset;
            point.U = productParameters.AdaptorPallet.ColumnOffset;
            robotController_Loader.SendRobotPoint(point);
            Thread.Sleep(200);
            #endregion

            #region TOOL 3 OFFSET
            //Tool3Offset
            //point.PointNum = 13;
            //point.X = productParameters.InputTray;
            //point.Y = productParameters.Tool3YOffset;
            //point.Z = productParameters.Tool3ZOffset;
            //point.U = productParameters.Tool3UOffset;
            //robotController_Loader.SendRobotPoint(point);
            //Thread.Sleep(200);
            #endregion

            #region GRIPPER CONFIG
            //Finger1Offset
            point.PointNum = 15;
            point.X = productParameters.Finger1OffsetX;
            point.Y = productParameters.Finger1OffsetY;
            point.Z = productParameters.Finger1OffsetZ;
            point.U = productParameters.Finger1OffsetU;
            robotController_Loader.SendRobotPoint(point);
            Thread.Sleep(200);

            //Finger1Offset
            point.PointNum = 16;
            point.X = productParameters.Finger2OffsetX;
            point.Y = productParameters.Finger2OffsetY;
            point.Z = productParameters.Finger2OffsetZ;
            point.U = productParameters.Finger2OffsetU;
            robotController_Loader.SendRobotPoint(point);
            Thread.Sleep(200);
            #endregion

            #region PALLET BARCODE OFFSET
            //PLT_BarcOffset
            point.PointNum = 21;
            point.X = productParameters.AdaptorPallet.BarcodeOffsetX;
            point.Y = productParameters.AdaptorPallet.BarcodeOffsetY;
            point.Z = productParameters.AdaptorPallet.BarcodeOffsetZ;
            point.U = productParameters.AdaptorPallet.BarcodeOffsetU;
            robotController_Loader.SendRobotPoint(point);
            Thread.Sleep(200);
            #endregion

            #region THICKOFFSET
            //ThickOffset
            point.PointNum = 24;
            point.X = 0;
            point.Y = 0;
            point.Z = productParameters.AdaptorPallet.ThicknessDiffMM;
            robotController_Loader.SendRobotPoint(point);
            Thread.Sleep(200);
            #endregion

            #region ADAPTER CHECK
            //AdptCheck 1 Offset
            point.PointNum = 31;
            point.X = productParameters.AdaptorPallet.CheckSpot1Offset.X;
            point.Y = productParameters.AdaptorPallet.CheckSpot1Offset.Y;
            point.Z = Convert.ToInt32(productParameters.AdaptorPallet.CheckSpotEnable);
            point.U = 0;
            robotController_Loader.SendRobotPoint(point);
            Thread.Sleep(200);

            //AdptCheck 2 Offset
            point.PointNum = 33;
            point.X = productParameters.AdaptorPallet.CheckSpot1Offset.X;
            point.Y = productParameters.AdaptorPallet.CheckSpot1Offset.Y;
            point.Z = Convert.ToInt32(productParameters.AdaptorPallet.CheckSpotEnable);
            point.U = 0;
            robotController_Loader.SendRobotPoint(point);
            Thread.Sleep(200);

            //AdptCheck 3 Offset
            point.PointNum = 35;
            point.X = productParameters.AdaptorPallet.CheckSpot3Offset.X;
            point.Y = productParameters.AdaptorPallet.CheckSpot3Offset.Y;
            point.Z = Convert.ToInt32(productParameters.AdaptorPallet.CheckSpotEnable);
            point.U = 0;
            robotController_Loader.SendRobotPoint(point);
            Thread.Sleep(200);

            //AdptCheck 4 Offset
            point.PointNum = 37;
            point.X = productParameters.AdaptorPallet.CheckSpot4Offset.X;
            point.Y = productParameters.AdaptorPallet.CheckSpot4Offset.Y;
            point.Z = Convert.ToInt32(productParameters.AdaptorPallet.CheckSpotEnable);
            point.U = 0;
            robotController_Loader.SendRobotPoint(point);
            Thread.Sleep(200);
            #endregion
        }



        //sends panel row and column numbers
        public static void SendPanelInfo(ProductParameters productParameters, EpsonRobotController robotController_Loader)
        {
            robotController_Loader.SendCmd2Robot(0, 0, RobotCommandConst.VSendPanelInfo, String.Format("1 {0} {1}", productParameters.InputTray.Columns, productParameters.InputTray.Rows));
            Thread.Sleep(200);
            robotController_Loader.SendCmd2Robot(0, 0, RobotCommandConst.VSendPanelInfo, String.Format("1 {0} {1}", productParameters.AdaptorPallet.Columns, productParameters.AdaptorPallet.Rows));

        }

    }
        
}
