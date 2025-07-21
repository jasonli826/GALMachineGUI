using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MachineNewGUI.Service
{
    /// <summary>
    /// Interaction logic for TeachUtility.xaml
    /// </summary>
    public partial class TeachUtility : Window
    {
        //Global Variables
        //public EpsonRobotController epsonRbt_Loader;

        //CalibrationData calData = new CalibrationData();
        //MachineConfiguration machineParameters;
        //ProductParameters productParameters;

        bool bWindowloaded = false;

        public TeachUtility()
        {
            InitializeComponent();
            //epsonRbt_Loader = rcLoader;

            //machineParameters = machine;
            //productParameters = prod;
        }

        //window event handlers
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            //jog control initialization
            bWindowloaded = true;

            //calData = CalibDataStream.Load(machineParameters.MachineType);

            //JogUserControl.JogControl = epsonRbt_Loader;
            //jogUserControl.NumOfLocal = machineParameters.NoOfLocal;
            ////jogUserControl.UserControlLoaded();

            //jogUserControl.IsUseGripper = true;
            //jogUserControl.ArmGroupEnable = true;
            //jogUserControl.XYAxesOrientation = -90.0;
            //jogUserControl.ToolTip = true;

            //jogUserControl.UserControlLoaded();

            //datagrid initialization
           // datagridRobotPoints.CanUserAddRows = false; //hides empty row display
            //datagridRobotPoints.ItemsSource = calData.DatumPoints;

            //textboxZOffset.Text = calData.Zoffst_Loader;
            //textboxZOffset_Unloader.Text = calData.Zoffst_UnLoader;

            //if (!calData.DatumPoints.Any(pt => pt.PointNumber == 2))
            //{
            //    Getech.GS.RobotController.RobotPoint ScanGrip1 = new Getech.GS.RobotController.RobotPoint();
            //    ScanGrip1.PointNumber = 2;
            //    ScanGrip1.PointName = "ScanGrip1";
            //    calData.DatumPoints.Add(ScanGrip1);
            //}

            //if (!calData.DatumPoints.Any(pt => pt.PointNumber == 5))
            //{
            //    Getech.GS.RobotController.RobotPoint PartScan = new Getech.GS.RobotController.RobotPoint();
            //    PartScan.PointNumber = 5;
            //    PartScan.PointName = "PartScan";
            //    calData.DatumPoints.Add(PartScan);
            //}

            //if (!calData.DatumPoints.Any(pt => pt.PointNumber == 20))
            //{
            //    Getech.GS.RobotController.RobotPoint DumpPoint = new Getech.GS.RobotController.RobotPoint();
            //    DumpPoint.PointNumber = 20;
            //    DumpPoint.PointName = "DumpPoint";
            //    calData.DatumPoints.Add(DumpPoint);
            //}


            //scrollViewer1.DataContext = calData;
            //datagridRobotPoints.ItemsSource = calData.DatumPoints;

        }

        private void Window_Closed(object sender, EventArgs e)
        {


            //JogUserControl.JogControl = epsonRbt_Loader;
            //jogUserControl.UserControlUnloaded();
        }

        //controls event handlers
        private void buttonJump_Click(object sender, RoutedEventArgs e)
        {
            int index = 0;

            if (index < 0)
            {
                MessageBox.Show("Select point then try again");
                return;
            }
            else
            {
                //Getech.GS.RobotController.RobotPoint rp = (Getech.GS.RobotController.RobotPoint)datagridRobotPoints.SelectedItem;
                //double dZOffset = Convert.ToDouble(textboxZOffset.Text);

                //JogControl.RobotPoint Pt = new JogControl.RobotPoint(rp.X, rp.Y, rp.Z, rp.U);
                //Pt.Hand = rp.Hand;
                //Pt.ZOff = dZOffset; //-10; //-50                
                //epsonRbt_Loader.JumpRobotZOffset(Pt);
            }
        }

        public DependencyProperty GetDependencyByName(Type ob, string name)
        {
            DependencyProperty dp = null;
            var fieldinfo = ob.GetField(name);
            if (fieldinfo != null)
            {
                dp = fieldinfo.GetValue(null) as DependencyProperty;
            }

            return dp;
        }


        private void buttonTeach_Click(object sender, RoutedEventArgs e)
        {
            int index = 0;
            if (index < 0)
            {
                MessageBox.Show("Select point then try again");
                return;
            }

            //JogControl.RobotPoint rp = jogUserControl.CurRobotPoint;

            //calData.DatumPoints[index].X = rp.X;
            //calData.DatumPoints[index].Y = rp.Y;
            //calData.DatumPoints[index].Z = rp.Z;
            //calData.DatumPoints[index].U = rp.U;
            //calData.DatumPoints[index].V = rp.V;
            //calData.DatumPoints[index].W = rp.W;
            //calData.DatumPoints[index].Hand = rp.Hand;
            //calData.DatumPoints[index].Wrist = rp.Wrist;
            //calData.DatumPoints[index].Elbow = rp.Elbow;

            //datagridRobotPoints.ItemsSource = null;
            //datagridRobotPoints.ItemsSource = calData.DatumPoints;
        }

        private void buttonSave2File_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               // ICollectionView cvTasks = CollectionViewSource.GetDefaultView(datagridRobotPoints.ItemsSource);
                //calData.DatumPoints = cvTasks.OfType<Getech.GS.RobotController.RobotPoint>().ToList();

                //CalibDataStream.Save(calData, machineParameters.MachineType);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception :" + ex.Message);
            }

        }

        private void buttonSent2Robot_Click(object sender, RoutedEventArgs e)
        {
            //RobotStream.SendSysParameter(calData, epsonRbt_Loader, productParameters, machineParameters);
        }

        private void buttonLoadFromFile_Click(object sender, RoutedEventArgs e)
        {
            //calData = CalibDataStream.Load(machineParameters.MachineType);


            //datagridRobotPoints.ItemsSource = calData.DatumPoints;

            //textboxZOffset.Text = calData.Zoffst_Loader;
            //textboxZOffset_Unloader.Text = calData.Zoffst_UnLoader;
        }

        private void buttonL2Wpt1Jump_Click(object sender, RoutedEventArgs e)
        {
            //JogControl.RobotPoint point = new JogControl.RobotPoint();
            //point.PointNum = (int)calData.Local2.WorldPoint1.PointNumber;
            //point.X = calData.Local2.WorldPoint1.X;
            //point.Y = calData.Local2.WorldPoint1.Y;
            //point.Z = calData.Local2.WorldPoint1.Z;
            //point.U = calData.Local2.WorldPoint1.U;

            //point.Hand = calData.Local2.WorldPoint1.Hand;
            //point.ZOff = (double)Convert.ToDouble(textboxL2Wpt1Zoffset.Text);

            //epsonRbt_Loader.JumpRobotZOffset(point);
        }

        private void buttonL2Wpt2Jump_Click(object sender, RoutedEventArgs e)
        {
            //JogControl.RobotPoint point = new JogControl.RobotPoint();
            //point.PointNum = (int)calData.Local2.WorldPoint2.PointNumber;
            //point.X = calData.Local2.WorldPoint2.X;
            //point.Y = calData.Local2.WorldPoint2.Y;
            //point.Z = calData.Local2.WorldPoint2.Z;
            //point.U = calData.Local2.WorldPoint2.U;

            //point.Hand = calData.Local2.WorldPoint2.Hand;
            //point.ZOff = (double)Convert.ToDouble(textboxL2Wpt2Zoffset.Text);

            //epsonRbt_Loader.JumpRobotZOffset(point);
        }

        private void buttonL1Wpt1Jump_Click(object sender, RoutedEventArgs e)
        {
            //JogControl.RobotPoint point = new JogControl.RobotPoint();
            //point.PointNum = (int)calData.Local1.WorldPoint1.PointNumber;
            //point.X = calData.Local1.WorldPoint1.X;
            //point.Y = calData.Local1.WorldPoint1.Y;
            //point.Z = calData.Local1.WorldPoint1.Z;
            //point.U = calData.Local1.WorldPoint1.U;

            //point.Hand = calData.Local1.WorldPoint1.Hand;
            //point.ZOff = (double)Convert.ToDouble(textboxL1Wpt1Zoffset.Text);

            //epsonRbt_Loader.JumpRobotZOffset(point);
        }

        private void buttonL1Wpt2Jump_Click(object sender, RoutedEventArgs e)
        {
            //JogControl.RobotPoint point = new JogControl.RobotPoint();
            //point.PointNum = (int)calData.Local1.WorldPoint2.PointNumber;
            //point.X = calData.Local1.WorldPoint2.X;
            //point.Y = calData.Local1.WorldPoint2.Y;
            //point.Z = calData.Local1.WorldPoint2.Z;
            //point.U = calData.Local1.WorldPoint2.U;

            //point.Hand = calData.Local1.WorldPoint2.Hand;
            //point.ZOff = (double)Convert.ToDouble(textboxL1Wpt2Zoffset.Text);

            //epsonRbt_Loader.JumpRobotZOffset(point);
        }

        private void buttonL2Wpt1Teach_Click(object sender, RoutedEventArgs e)
        {
            //calData.Local2.WorldPoint1.X = jogUserControl.CurRobotPoint.X;
            //calData.Local2.WorldPoint1.Y = jogUserControl.CurRobotPoint.Y;
            //calData.Local2.WorldPoint1.Z = jogUserControl.CurRobotPoint.Z;
            //calData.Local2.WorldPoint1.U = jogUserControl.CurRobotPoint.U;
        }

        private void buttonL2Wpt2Teach_Click(object sender, RoutedEventArgs e)
        {
            //calData.Local2.WorldPoint2.X = jogUserControl.CurRobotPoint.X;
            //calData.Local2.WorldPoint2.Y = jogUserControl.CurRobotPoint.Y;
            //calData.Local2.WorldPoint2.Z = jogUserControl.CurRobotPoint.Z;
            //calData.Local2.WorldPoint2.U = jogUserControl.CurRobotPoint.U;
        }

        private void buttonL1Wpt1Teach_Click(object sender, RoutedEventArgs e)
        {
            //calData.Local1.WorldPoint1.X = jogUserControl.CurRobotPoint.X;
            //calData.Local1.WorldPoint1.Y = jogUserControl.CurRobotPoint.Y;
            //calData.Local1.WorldPoint1.Z = jogUserControl.CurRobotPoint.Z;
            //calData.Local1.WorldPoint1.U = jogUserControl.CurRobotPoint.U;
        }

        private void buttonL1Wpt2Teach_Click(object sender, RoutedEventArgs e)
        {
            //calData.Local1.WorldPoint2.X = jogUserControl.CurRobotPoint.X;
            //calData.Local1.WorldPoint2.Y = jogUserControl.CurRobotPoint.Y;
            //calData.Local1.WorldPoint2.Z = jogUserControl.CurRobotPoint.Z;
            //calData.Local1.WorldPoint2.U = jogUserControl.CurRobotPoint.U;
        }

        private void buttonAddRow_Click(object sender, RoutedEventArgs e)
        {
           // datagridRobotPoints.CanUserAddRows = true;
        }

        private void buttonRemoveRow_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    int index = datagridRobotPoints.SelectedIndex;

            //    if (index < 0)
            //    {
            //        MessageBox.Show("Select point then try again");
            //        return;
            //    }
            //    else
            //    {
            //        calData.DatumPoints.RemoveAt(index);
            //        CalibDataStream.Save(calData, machineParameters.MachineType);
            //        calData = CalibDataStream.Load(machineParameters.MachineType);

            //        scrollViewer1.DataContext = calData;
            //        datagridRobotPoints.ItemsSource = calData.DatumPoints;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }
    }
}
