using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MachineNewGUI.Entity;
using RobotController;
namespace MachineNewGUI.Service
{
    /// <summary>
    /// Interaction logic for ModBusUtility.xaml
    /// </summary>
    public partial class ModBusUtility : Window
    {
        MachineConfiguration machineParameters;
        DeltaServoAxisData axisdata;
        ModbusMotionControl ModbusMotionControl;
        public ModBusUtility(DeltaServoAxisData _axisdata, MachineConfiguration _machineParameters, ModbusMotionControl modbusMotionControl)
        {
            InitializeComponent();
            machineParameters = _machineParameters;
            ModbusMotionControl = modbusMotionControl;
            axisdata = _axisdata;
            Stackpanel1.DataContext = axisdata;
            datagridRobotPoints.ItemsSource = axisdata.deltaAxis;
        }

        private void Form_Loaded(object sender, RoutedEventArgs e)
        {
            List<int> listAxisNo = new List<int>();
            datagridRobotPoints.CanUserAddRows = false;
            datagridRobotPoints.CanUserDeleteRows = false;


            for (int s = 1; s <= machineParameters.NoOfDeltaAxis; s++)
            {
                listAxisNo.Add(s);
            }
            comboboxAxisNo.ItemsSource = listAxisNo;
        }
        private void buttonSave2File_Click(object sender, RoutedEventArgs e)
        {
            DeltaServoAxisDataStream.Save(axisdata, machineParameters.MachineType);

            
        }

        private void buttonGetvalue_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TxtPrNum.Text != "")
                {
                    double Pos = 0.0;  //StackDown Pos
                    int a = comboboxAxisNo.SelectedIndex;
                    if (ModbusMotionControl.GetPosition(Convert.ToInt32(comboboxAxisNo.Text), Convert.ToInt32(TxtPrNum.Text), ref Pos))
                    {
                        TxtResult.Text = Pos.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Could not get the Axis point");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void buttonSave2File1_Click(object sender, RoutedEventArgs e)
        {
            DeltaServoAxisDataStream.Save(axisdata, machineParameters.MachineType);
        }

        private void datagridRobotPoints_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            if(datagridRobotPoints.SelectedIndex == 4  || datagridRobotPoints.SelectedIndex ==3 )
            {
                MessageBox.Show("Axis 4 and 5 are not editable");
                e.Cancel =true;
            }
        }
    }
}
