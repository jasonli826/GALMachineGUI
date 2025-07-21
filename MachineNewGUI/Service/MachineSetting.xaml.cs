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
    /// Interaction logic for MachineSetting.xaml
    /// </summary>
    public partial class MachineSetting : Window
    {
        enum LightStatus
        {
            _ = 0,
            Off = 1,
            On = 2,
            Flash = 3,
        }
        public class SingleLightConfig
        {
            private static readonly SingleLightConfig[] value = null;

            public string Name { get; set; } = "";
            public int Green { get; set; }
            public int Yellow { get; set; }
            public int Red { get; set; }
            public int Blue { get; set; }
            public int Buzzer { get; set; }
            public bool IsEditable { get; set; } = true;

            public string RobotCmdString => $"{Green}{Yellow}{Red}{Blue}{Buzzer}";
            public SingleLightConfig(string name) { Name = name; }
            public SingleLightConfig() { }

            public SingleLightConfig[] LightConfig { get; set; } = value;
        }
        public MachineSetting()
        {
            InitializeComponent();
            ResetTowerLight();

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            WrapDeveloperMode.Visibility = Visibility.Collapsed;


            List<string> listScannerType = new List<string>();

            listScannerType.Add("Keyence");
            listScannerType.Add("Sick");
            listScannerType.Add("HIK");
            comboboxloader1.ItemsSource = listScannerType;
            comboboxloader2.ItemsSource = listScannerType;
            comboboxloader1.SelectedIndex = 0;
            comboboxloader2.SelectedIndex = 0;

            //gblightconfig.DataContext = machineParameters;
        }
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public SingleLightConfig[] LightConfig { get; set; } = null;
        private void ResetTowerLight()
        {
            //LightConfig = [new SingleLightConfig("Home"), new SingleLightConfig("Auto/Verify"), new SingleLightConfig("Teach"), new SingleLightConfig("Pause"), new SingleLightConfig("Operation Call"), new SingleLightConfig("Machine Error"), new SingleLightConfig("Power Up/Reset")];
            LightConfig = Enumerable
            .Range(0, 10) // Generate a sequence of 10 numbers
            .Select(_ => new SingleLightConfig()) // Create a new instance for each
            .ToArray();

            LightConfig[0].Name = "AUTO";
            LightConfig[0].Green = (int)LightStatus.On;
            LightConfig[0].Yellow = (int)LightStatus.Off;
            LightConfig[0].Red = (int)LightStatus._;
            LightConfig[0].Blue = (int)LightStatus._;
            LightConfig[0].Buzzer = (int)LightStatus._;

            LightConfig[1].Name = "VERIFY";
            LightConfig[1].Green = (int)LightStatus.Flash;
            LightConfig[1].Yellow = (int)LightStatus.Flash;
            LightConfig[1].Red = (int)LightStatus._;
            LightConfig[1].Buzzer = (int)LightStatus._;
            LightConfig[1].Blue = (int)LightStatus._;

            LightConfig[2].Name = "TEACH";
            LightConfig[2].Green = (int)LightStatus.Flash;
            LightConfig[2].Yellow = (int)LightStatus.On;
            LightConfig[2].Red = (int)LightStatus._;
            LightConfig[2].Buzzer = (int)LightStatus._;
            LightConfig[2].Blue = (int)LightStatus._;

            LightConfig[3].Name = "HOME";
            LightConfig[3].Green = (int)LightStatus.Flash;
            LightConfig[3].Yellow = (int)LightStatus.Off;
            LightConfig[3].Red = (int)LightStatus._;
            LightConfig[3].Buzzer = (int)LightStatus._;
            LightConfig[3].Blue = (int)LightStatus._;

            LightConfig[4].Name = "OP-CALL(ALERT)";
            LightConfig[4].Green = (int)LightStatus._;
            LightConfig[4].Yellow = (int)LightStatus.Flash;
            LightConfig[4].Red = (int)LightStatus._;
            LightConfig[4].Buzzer = (int)LightStatus.Flash;
            LightConfig[4].Blue = (int)LightStatus._;

            LightConfig[5].Name = "PAUSE";
            LightConfig[5].Green = (int)LightStatus.Off;
            LightConfig[5].Yellow = (int)LightStatus.On;
            LightConfig[5].Red = (int)LightStatus._;
            LightConfig[5].Buzzer = (int)LightStatus.Off;
            LightConfig[5].Blue = (int)LightStatus._;

            LightConfig[6].Name = "ALARM(ERROR)";
            LightConfig[6].Green = (int)LightStatus._;
            LightConfig[6].Yellow = (int)LightStatus._;
            LightConfig[6].Red = (int)LightStatus.On;
            LightConfig[6].Buzzer = (int)LightStatus.On;
            LightConfig[6].Blue = (int)LightStatus._;

            LightConfig[9].Name = "RESET(POWER UP)";
            LightConfig[9].Green = (int)LightStatus.On;
            LightConfig[9].Yellow = (int)LightStatus.On;
            LightConfig[9].Red = (int)LightStatus.On;
            LightConfig[9].Buzzer = (int)LightStatus._;
            LightConfig[9].Blue = (int)LightStatus.On;
            LightConfig[9].IsEditable = false;

            OnPropertyChanged(nameof(LightConfig));
        }
        //public ICommand ResetTowerLightCommand => new RelayCommand(ResetTowerLight);

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }

    //JunTeng--14012025
    enum LightStatus
    {
        _ = 0,
        Off = 1,
        On = 2,
        Flash = 3,
    }
    public class SingleLightConfig
    {
        public string Name { get; set; } = "";
        public int Green { get; set; }
        public int Yellow { get; set; }
        public int Red { get; set; }
        public int Blue { get; set; }
        public int Buzzer { get; set; }
        public bool IsEditable { get; set; } = true;

        public string RobotCmdString => $"{Green}{Yellow}{Red}{Blue}{Buzzer}";
        public SingleLightConfig(string name) { Name = name; }
        public SingleLightConfig() { }
    }

    public class ScannerSettings : INotifyPropertyChanged
    {
        public bool HasEnableCom1 { get; set; }
        public int Comport1 { get; set; }
        public int Baudrate1 { get; set; }
        public int Com1ScannerModel { get; set; }

        public bool HasEnableCom2 { get; set; }
        public int Comport2 { get; set; }
        public int Baudrate2 { get; set; }
        public int Com2ScannerModel { get; set; }

        public bool HasEnableCom3 { get; set; }
        public int Comport3 { get; set; }
        public int Baudrate3 { get; set; }
        public int Com3ScannerModel { get; set; }


        public string IP_SC1 { get; set; }
        public int Port_SC1 { get; set; }


        public string IP_SC2 { get; set; }
        public int Port_SC2 { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }
    
    }
}
