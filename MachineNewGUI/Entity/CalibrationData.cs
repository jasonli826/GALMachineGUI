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
using GALXYSoftCommunication;
using MachineNewGUI.Entity;
using MachineNewGUI;


namespace MachineNewGUI.Entity
{
    public class CalibrationData : INotifyPropertyChanged
    {
        public LocalData Local1 { get; set; }
        public LocalData Local2 { get; set; }
        public LocalData Local3 { get; set; }
        //public LocalData Local4 { get; set; }
        //public LocalData Local5 { get; set; }
        //public LocalData Local6 { get; set; }
        //public LocalData GALTimer1 { get; set; }
        //[XmlElement("DatumPoints")]
        public List<RobotPoint> DatumPoints { get; set; }

        public CalibrationData()
        {
            Local1 = new LocalData();
            Local2 = new LocalData();
            Local3 = new LocalData();
            //Local4 = new LocalData();
            //Local5 = new LocalData();
            //Local6 = new LocalData();
            //GALTimer1 = new LocalData();
            DatumPoints = new List<RobotPoint>();


            Local1.WorldPoint1.PointNumber = 51;
            Local1.WorldPoint2.PointNumber = 52;
            Local1.LocalPoint1.PointNumber = 53;
            Local1.LocalPoint2.PointNumber = 54;

            Local2.WorldPoint1.PointNumber = 56;
            Local2.WorldPoint2.PointNumber = 57;
            Local2.LocalPoint1.PointNumber = 58;
            Local2.LocalPoint2.PointNumber = 59;

            //GALTimer1.GALTimer.PointNumber = 40;
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

        //public RobotPoint GALTimer { get; set; }

        //public List<RobotPoint> DatumPoints { get; set; }

        public LocalData()
        {
            WorldPoint1 = new RobotPoint();
            LocalPoint1 = new RobotPoint();
            WorldPoint2 = new RobotPoint();
            LocalPoint2 = new RobotPoint();
            //GALTimer = new RobotPoint();
            //DatumPoints = new List<RobotPoint>();
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
                if (!Directory.Exists(System.IO.Path.GetDirectoryName(strPath)))
                    Directory.CreateDirectory(System.IO.Path.GetDirectoryName(strPath));

                data = new CalibrationData();
                data.DatumPoints.Add(new RobotPoint() { PointNumber = 5, PointName = "ScanGrip1" });
                data.DatumPoints.Add(new RobotPoint() { PointNumber = 6, PointName = "PartScan" });
                data.DatumPoints.Add(new RobotPoint() { PointNumber = 7, PointName = "DumpPoint" });
                data.DatumPoints.Add(new RobotPoint() { PointNumber = 8, PointName = "SpotPoint" });

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
            calData.Local1.WorldPoint1.PointNumber = 51;
            CopyPoint(point, calData.Local1.WorldPoint1);
            epsonRbt_Loader.SendRobotPoint(point);
            calData.Local1.WorldPoint2.PointNumber = 52;
            CopyPoint(point, calData.Local1.WorldPoint2);
            epsonRbt_Loader.SendRobotPoint(point);
            calData.Local1.LocalPoint1.PointNumber = 53;
            CopyPoint(point, calData.Local1.LocalPoint1);
            epsonRbt_Loader.SendRobotPoint(point);
            calData.Local1.LocalPoint2.PointNumber = 54;
            CopyPoint(point, calData.Local1.LocalPoint2);
            epsonRbt_Loader.SendRobotPoint(point);

            //Local 2
            calData.Local2.WorldPoint1.PointNumber = 56;
            CopyPoint(point, calData.Local2.WorldPoint1);
            epsonRbt_Loader.SendRobotPoint(point);
            calData.Local2.WorldPoint2.PointNumber = 57;
            CopyPoint(point, calData.Local2.WorldPoint2);
            epsonRbt_Loader.SendRobotPoint(point);
            calData.Local2.LocalPoint1.PointNumber = 58;
            CopyPoint(point, calData.Local2.LocalPoint1);
            epsonRbt_Loader.SendRobotPoint(point);
            calData.Local2.LocalPoint2.PointNumber = 59;
            CopyPoint(point, calData.Local2.LocalPoint2);
            epsonRbt_Loader.SendRobotPoint(point);
            #endregion

            //#region TIMERS
            //calData.GALTimer1.GALTimer.PointNumber = 40;
            //CopyPoint(point, calData.GALTimer1.GALTimer);
            //epsonRbt_Loader.SendRobotPoint(point);
            //#endregion

            foreach (Getech.GS.RobotController.RobotPoint rp in calData.DatumPoints)
            {
                JogControl.RobotPoint Pt = new JogControl.RobotPoint(rp.X, rp.Y, rp.Z, rp.U, rp.V, rp.W);
                Pt.Hand = rp.Hand;
                Pt.ZOff = 0; //default seems 50 
                Pt.PointNum = (int)rp.PointNumber;

                epsonRbt_Loader.SendRobotPoint(Pt);
                Thread.Sleep(50);
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
        public static void SendProductDataGAL(ProductParameters productParameters, EpsonRobotController robotController_Loader, MachineConfiguration MachineParameter, SystemParameter SysParaData)
        {

            JogControl.RobotPoint point = new JogControl.RobotPoint();

            #region INPUT TRAY
            //GUI_Tray Info
            point.PointNum = 10;
            point.X = productParameters.InputTray.RowPitch;
            point.Y = productParameters.InputTray.ColumnPitch;
            point.Z = productParameters.InputTray.RowOffset;
            point.U = productParameters.InputTray.ColumnOffset;
            robotController_Loader.SendRobotPoint(point);
            Thread.Sleep(50);

            //Tray PickOffset
            point.PointNum = 11;
            point.X = productParameters.InputTray.GripperPickOffsetX;
            point.Y = productParameters.InputTray.GripperPickOffsetY;
            point.Z = productParameters.InputTray.GripperPickOffsetZ;
            point.U = productParameters.InputTray.GripperPickOffsetU;
            robotController_Loader.SendRobotPoint(point);
            Thread.Sleep(50);

            //TrayBarcode Offset
            point.PointNum = 12;
            point.X = productParameters.InputTray.BarcodeOffset_Points.X;
            point.Y = productParameters.InputTray.BarcodeOffset_Points.Y;
            point.Z = productParameters.InputTray.BarcodeOffset_Points.Z;
            point.U = productParameters.InputTray.BarcodeOffset_Points.U;
            point.Local = 2;
            point.Hand = true;
            robotController_Loader.SendRobotPoint(point);
            Thread.Sleep(50);
            point = new JogControl.RobotPoint();

            //MIDBarcode Offset
            point.PointNum = 17;
            point.X = productParameters.InputTray.ModuleBarcode_Points.X;
            point.Y = productParameters.InputTray.ModuleBarcode_Points.Y;
            point.Z = productParameters.InputTray.ModuleBarcode_Points.Z;
            point.U = productParameters.InputTray.ModuleBarcode_Points.U;
            robotController_Loader.SendRobotPoint(point);
            Thread.Sleep(50);

            #endregion

            #region OUTPUT ADAPTER PALLET
            //GUI Pallet Info
            point.PointNum = 20;
            point.X = productParameters.AdaptorPallet.RowPitch;
            point.Y = productParameters.AdaptorPallet.ColumnPitch;
            point.Z = productParameters.AdaptorPallet.RowOffset;
            point.U = productParameters.AdaptorPallet.ColumnOffset;
            robotController_Loader.SendRobotPoint(point);
            Thread.Sleep(50);

            //PlaceOffset
            point.PointNum = 21;
            point.X = productParameters.AdaptorPallet.PlacementOffset.X;
            point.Y = productParameters.AdaptorPallet.PlacementOffset.Y;
            point.Z = productParameters.AdaptorPallet.PlacementOffset.Z;
            point.U = productParameters.AdaptorPallet.PlacementOffset.U;
            robotController_Loader.SendRobotPoint(point);
            Thread.Sleep(50);
            #endregion

            #region TOOL 1 OFFSET
            //Tool2Offset
            point.PointNum = 1;
            point.X = SysParaData.Tip1.TipOffset.X;
            point.Y = SysParaData.Tip1.TipOffset.Y;
            point.Z = SysParaData.Tip1.TipOffset.Z;
            point.U = SysParaData.Tip1.TipOffset.U;
            robotController_Loader.SendRobotPoint(point);
            Thread.Sleep(50);
            #endregion

            #region TOOL 2 OFFSET
            //Tool2Offset
            point.PointNum = 2;
            point.X = SysParaData.Tip2.TipOffset.X;
            point.Y = SysParaData.Tip2.TipOffset.Y;
            point.Z = SysParaData.Tip2.TipOffset.Z;
            point.U = SysParaData.Tip2.TipOffset.U;
            robotController_Loader.SendRobotPoint(point);
            Thread.Sleep(50);
            #endregion

            #region TOOL 3 OFFSET
            //Tool3Offset
            point.PointNum = 3;
            point.X = SysParaData.Tip3.TipOffset.X;
            point.Y = SysParaData.Tip3.TipOffset.Y;
            point.Z = SysParaData.Tip3.TipOffset.Z;
            point.U = SysParaData.Tip3.TipOffset.U;
            robotController_Loader.SendRobotPoint(point);
            Thread.Sleep(50);

            //point.PointNum = 3;
            //point.X = productParameters.GALTool3XOffset;
            //point.Y = productParameters.GALTool3YOffset;
            //point.Z = productParameters.GALTool3ZOffset;
            //point.U = productParameters.GALTool3UOffset;
            //robotController_Loader.SendRobotPoint(point);
            //Thread.Sleep(50);
            #endregion

            #region GRIPPER FINGER CONFIG
            //Finger1Offset
            point.PointNum = 41;
            point.X = productParameters.Finger1OffsetX;
            point.Y = productParameters.Finger1OffsetY;
            point.Z = productParameters.Finger1OffsetZ;
            point.U = productParameters.Finger1OffsetU;
            robotController_Loader.SendRobotPoint(point);
            Thread.Sleep(50);

            //Finger2Offset
            point.PointNum = 42;
            point.X = productParameters.Finger2OffsetX;
            point.Y = productParameters.Finger2OffsetY;
            point.Z = productParameters.Finger2OffsetZ;
            point.U = productParameters.Finger2OffsetU;
            robotController_Loader.SendRobotPoint(point);
            Thread.Sleep(50);
            #endregion

            #region ADAPTER SPOTCHECK
            //AdptCheck 1 Offset
            point.PointNum = 31;
            point.X = productParameters.AdaptorPallet.CheckSpot1Offset.X;
            point.Y = productParameters.AdaptorPallet.CheckSpot1Offset.Y;
            point.Z = productParameters.AdaptorPallet.CheckSpot1Offset.Z;
            point.U = productParameters.AdaptorPallet.CheckSpot1Offset.U;
            robotController_Loader.SendRobotPoint(point);
            Thread.Sleep(50);

            //AdptCheck 2 Offset
            point.PointNum = 33;
            point.X = productParameters.AdaptorPallet.CheckSpot2Offset.X;
            point.Y = productParameters.AdaptorPallet.CheckSpot2Offset.Y;
            point.Z = productParameters.AdaptorPallet.CheckSpot2Offset.Z;
            point.U = productParameters.AdaptorPallet.CheckSpot2Offset.U;
            robotController_Loader.SendRobotPoint(point);
            Thread.Sleep(50);

            //AdptCheck 3 Offset
            point.PointNum = 35;
            point.X = productParameters.AdaptorPallet.CheckSpot3Offset.X;
            point.Y = productParameters.AdaptorPallet.CheckSpot3Offset.Y;
            point.Z = productParameters.AdaptorPallet.CheckSpot3Offset.Z;
            point.U = productParameters.AdaptorPallet.CheckSpot3Offset.U;
            robotController_Loader.SendRobotPoint(point);
            Thread.Sleep(50);

            //AdptCheck 4 Offset
            point.PointNum = 37;
            point.X = productParameters.AdaptorPallet.CheckSpot4Offset.X;
            point.Y = productParameters.AdaptorPallet.CheckSpot4Offset.Y;
            point.Z = productParameters.AdaptorPallet.CheckSpot4Offset.Z;
            point.U = productParameters.AdaptorPallet.CheckSpot4Offset.U;
            robotController_Loader.SendRobotPoint(point);
            Thread.Sleep(50);

            //AdptCheck Enable
            point.PointNum = 29;
            point.X = productParameters.AdaptorPallet.CheckSpotEnable.X;
            point.Y = productParameters.AdaptorPallet.CheckSpotEnable.Y;
            point.Z = productParameters.AdaptorPallet.CheckSpotEnable.Z;
            point.U = productParameters.AdaptorPallet.CheckSpotEnable.U;
            robotController_Loader.SendRobotPoint(point);
            Thread.Sleep(50);

            //AdptCheck Pos On/Off
            point.PointNum = 30;
            point.X = productParameters.AdaptorPallet.CheckSpotPosOnOff.X;
            point.Y = productParameters.AdaptorPallet.CheckSpotPosOnOff.Y;
            point.Z = productParameters.AdaptorPallet.CheckSpotPosOnOff.Z;
            point.U = productParameters.AdaptorPallet.CheckSpotPosOnOff.U;
            robotController_Loader.SendRobotPoint(point);
            Thread.Sleep(50);
            #endregion

            #region ADAPTER ON FLY SPOTCHECK
            //FlyCheckEnable, FlyCheckSpeed, CheckDelta
            point.PointNum = 60;
            point.X = productParameters.AdaptorPallet.FlyCheckSpotEnable;
            point.Y = productParameters.AdaptorPallet.FlyCheckSpeed;
            point.Z = productParameters.AdaptorPallet.CheckDelta;
            point.U = 0;
            robotController_Loader.SendRobotPoint(point);
            Thread.Sleep(50);

            //FlyAdptCheck 1 Offset
            point.PointNum = 61;
            point.X = productParameters.AdaptorPallet.FlyCheckSpot1Offset.X;
            point.Y = productParameters.AdaptorPallet.FlyCheckSpot1Offset.Y;
            point.Z = productParameters.AdaptorPallet.FlyCheckSpot1Offset.Z;
            point.U = productParameters.AdaptorPallet.FlyCheckSpot1Offset.U;
            robotController_Loader.SendRobotPoint(point);
            Thread.Sleep(50);

            //FlyAdptCheck 2 Offset
            point.PointNum = 62;
            point.X = productParameters.AdaptorPallet.FlyCheckSpot2Offset.X;
            point.Y = productParameters.AdaptorPallet.FlyCheckSpot2Offset.Y;
            point.Z = productParameters.AdaptorPallet.FlyCheckSpot2Offset.Z;
            point.U = productParameters.AdaptorPallet.FlyCheckSpot2Offset.U;
            robotController_Loader.SendRobotPoint(point);
            Thread.Sleep(50);

            //FlyAdptCheck 3 Offset
            point.PointNum = 63;
            point.X = productParameters.AdaptorPallet.FlyCheckSpot3Offset.X;
            point.Y = productParameters.AdaptorPallet.FlyCheckSpot3Offset.Y;
            point.Z = productParameters.AdaptorPallet.FlyCheckSpot3Offset.Z;
            point.U = productParameters.AdaptorPallet.FlyCheckSpot3Offset.U;
            robotController_Loader.SendRobotPoint(point);
            Thread.Sleep(50);

            //FlyAdptCheck 4 Offset
            point.PointNum = 64;
            point.X = productParameters.AdaptorPallet.FlyCheckSpot4Offset.X;
            point.Y = productParameters.AdaptorPallet.FlyCheckSpot4Offset.Y;
            point.Z = productParameters.AdaptorPallet.FlyCheckSpot4Offset.Z;
            point.U = productParameters.AdaptorPallet.FlyCheckSpot4Offset.U;
            robotController_Loader.SendRobotPoint(point);
            Thread.Sleep(50);
            #endregion

            #region PALLET BARCODE OFFSET 
            //PLT_BarcOffset
            point.PointNum = 70;
            point.X = productParameters.AdaptorPallet.BarcodeOffsetX;
            point.Y = productParameters.AdaptorPallet.BarcodeOffsetY;
            point.Z = productParameters.AdaptorPallet.BarcodeOffsetZ;
            point.U = productParameters.AdaptorPallet.BarcodeOffsetU;
            point.Local = 1;
            point.Hand = true;
            robotController_Loader.SendRobotPoint(point);
            Thread.Sleep(50);
            point = new JogControl.RobotPoint();
            #endregion

            #region THICKOFFSET
            //ThickOffset
            //point.PointNum = 27;
            //point.X = 0;
            //point.Y = 0;
            //point.Z = productParameters.AdaptorPallet.ThicknessDiffMM;
            //robotController_Loader.SendRobotPoint(point);
            //Thread.Sleep(50);
            #endregion

            #region TIMERS
            point.PointNum = 40;
            point.X = productParameters.GALTimer.X;
            point.Y = productParameters.GALTimer.Y;
            point.Z = productParameters.GALTimer.Z;
            point.U = productParameters.GALTimer.U;
            robotController_Loader.SendRobotPoint(point);
            Thread.Sleep(50);
            #endregion

            Thread.Sleep(50);
        }



        //sends panel row and column numbers
        public static void SendPanelInfo(ProductParameters productParameters, EpsonRobotController robotController_Loader)
        {
            robotController_Loader.SendCmd2Robot(0, 0, RobotCommandConst.VSendPanelInfo, String.Format("1 {0} {1}", productParameters.InputTray.Columns, productParameters.InputTray.Rows));
            Thread.Sleep(50);
            robotController_Loader.SendCmd2Robot(0, 0, RobotCommandConst.VSendPanelInfo, String.Format("2 {0} {1}", productParameters.AdaptorPallet.Columns, productParameters.AdaptorPallet.Rows));

        }

    }

}
