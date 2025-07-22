using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Ports;
using System.Xml;
using System.Xml.Serialization;
using System.Windows;
using Getech.IO;
using System.ComponentModel;
using static MachineNewGUI.Service.MachineSetting;
//using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using System.Configuration;
using Newtonsoft.Json;
using GalaSoft.MvvmLight.Command;

namespace MachineNewGUI
{
    public class MachineConfiguration : INotifyPropertyChanged
    {
        public string MachineType { get; set; }
        public string MachineSerialNo { get; set; }
        public string RobotControllerIP_Loader { get; set; }
        public string RobotControllerPort_Loader { get; set; }

        public string LastProduct { get; set; }
        public int NoOfDeltaAxis { get; set; }
        public bool IsModBusTrue { get; set; }
        public int NoOfLocal { get; set; }
        public double ConveyorWidth { get; set; }
        public bool HasDeveloperSkipPartScan { get; set; }
        public bool HasDeveloperOnFlyCheckspot { get; set; }

        public ScannerSettings ComSetting { get; set; }
        public MachineConfiguration()
        {
            MachineType = "GAL";
            MachineSerialNo = "GAL101";
            RobotControllerIP_Loader = "192.168.20.142";
            RobotControllerPort_Loader = "2001";
            LastProduct = String.Empty;
            NoOfDeltaAxis = 3;
            IsModBusTrue = true;
            NoOfLocal = 2;
            HasDeveloperSkipPartScan = false;
            HasDeveloperOnFlyCheckspot = true;
            ComSetting = new ScannerSettings();
            ComSetting.Comport1 = 1;
            ComSetting.Comport2 = 2;
            ComSetting.Comport3 = 3;

            ComSetting.Baudrate1 = 9600;
            ComSetting.Baudrate2 = 9600;
            ComSetting.Baudrate3 = 9600;

            ComSetting.IP_SC1 = "127.0.0.1";
            ComSetting.Port_SC1 = 3001;

            ComSetting.IP_SC2 = "127.0.0.1";
            ComSetting.Port_SC2 = 3002;

            if (LightConfig == null)
            {
                ResetTowerLight();
            }

            ConveyorWidth = 400;
        }

     
        public SingleLightConfig[] LightConfig { get; set; } = null;
        private void ResetTowerLight()
        {
            //LightConfig = [new SingleLightConfig("Home"), new SingleLightConfig("Auto/Verify"), new SingleLightConfig("Teach"), new SingleLightConfig("Pause"), new SingleLightConfig("Operation Call"), new SingleLightConfig("Machine Error"), new SingleLightConfig("Power Up/Reset")];
            LightConfig = Enumerable
            .Range(0, 10) // Generate a sequence of 10 numbers
            .Select(_ => new SingleLightConfig()) // Create a new instance for each
            .ToArray();

            LightConfig[0].Name = "AUTO(RUN)";
            LightConfig[0].Green = (int)LightStatus.On;
            LightConfig[0].Yellow = (int)LightStatus.Off;
            LightConfig[0].Red = (int)LightStatus.Off;
            LightConfig[0].Blue = (int)LightStatus.Off;
            LightConfig[0].Buzzer = (int)LightStatus.Off;

            LightConfig[1].Name = "VERIFY(RUN)";
            LightConfig[1].Green = (int)LightStatus.Flash;
            LightConfig[1].Yellow = (int)LightStatus.Flash;
            LightConfig[1].Red = (int)LightStatus.Off;
            LightConfig[1].Buzzer = (int)LightStatus.Off;
            LightConfig[1].Blue = (int)LightStatus.Off;

            LightConfig[2].Name = "TEACH(RUN)";
            LightConfig[2].Green = (int)LightStatus.Flash;
            LightConfig[2].Yellow = (int)LightStatus.On;
            LightConfig[2].Red = (int)LightStatus.Off;
            LightConfig[2].Buzzer = (int)LightStatus.Off;
            LightConfig[2].Blue = (int)LightStatus.Off;

            LightConfig[3].Name = "HOME(RUN)";
            LightConfig[3].Green = (int)LightStatus.Flash;
            LightConfig[3].Yellow = (int)LightStatus.Off;
            LightConfig[3].Red = (int)LightStatus.Off;
            LightConfig[3].Buzzer = (int)LightStatus.Off;
            LightConfig[3].Blue = (int)LightStatus.Off;

            LightConfig[4].Name = "OP-CALL(ALERT)";
            LightConfig[4].Green = (int)LightStatus._;
            LightConfig[4].Yellow = (int)LightStatus.Flash;
            LightConfig[4].Red = (int)LightStatus._;
            LightConfig[4].Buzzer = (int)LightStatus.Flash;
            LightConfig[4].Blue = (int)LightStatus._;

            LightConfig[5].Name = "PAUSE(NO RUN)";
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
        public ICommand ResetTowerLightCommand => new RelayCommand(ResetTowerLight);

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }

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

    public class MachineConfigStream
    {
        
        private static string MachineGUIDirectroy = ConfigurationManager.AppSettings["Directory"].ToString();
        static string strPath = MachineGUIDirectroy+ @"/system/Machine Configuration.xml";
        public static void Save(MachineConfiguration config)
        {
            if (!Directory.Exists(Path.GetDirectoryName(strPath)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(strPath));
            }

            try
            {                
                using (FileStream fs = new FileStream(strPath, FileMode.Create, FileAccess.Write))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(MachineConfiguration));

                    TextWriter writer = new StreamWriter(fs);
                    serializer.Serialize(writer, config);
                    writer.Close();
                }

                Log.WriteToFile("Machine Configutation file saved");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception reading to file: " + ex.Message);               
            }
        }

        public static MachineConfiguration Load()
        {
            MachineConfiguration config;
            
            if(!Directory.Exists(Path.GetDirectoryName(strPath)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(strPath));                
            }

            if(!File.Exists(strPath))
            {
                config = new MachineConfiguration();
                try
                {
                    using (FileStream fs = new FileStream(strPath, FileMode.Create, FileAccess.Write))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(MachineConfiguration));

                        TextWriter writer = new StreamWriter(fs);
                        serializer.Serialize(writer, config);
                        writer.Close();
                    }

                    Log.WriteToFile("Machine Configuration file overwrite.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exception reading to file: " + ex.Message);
                }
            }

            try
            {
                using (FileStream fs = new FileStream(strPath, FileMode.Open, FileAccess.Read))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(MachineConfiguration));

                    TextReader reader = new StreamReader(fs);
                    config = (MachineConfiguration)serializer.Deserialize(reader);
                    reader.Close();                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception reading machine config file: " + ex.Message); 
                config = new MachineConfiguration();
            }

            return config;
        }
    }

    public class MachineState
    {
        public bool IsDoorOpen;
        public bool IsPause;
        public int Mode;
        public MachineState()
        {
            IsDoorOpen = false;
            IsPause = false;
            Mode = 0;
        }
    }


    public class InternalMemoryStateManagement
    {
        public string LastReservation { get; set; }
        public string LastProduct { get; set; }
        public bool isCreateProduct { get; set; }
        public InternalMemoryStateManagement()
        {
            LastProduct = String.Empty;
            LastReservation = String.Empty;
            isCreateProduct = false;
        }
    }

    public class InternalMemoryStateManagementConfigStream
    {
        //static string strPath = @"C:/GAL/system/InternalMemoryStateManagement.xml";
        static string MachineGUIDirectroy = ConfigurationManager.AppSettings["Directory"].ToString();
        static string strPath = MachineGUIDirectroy+ @"/system/InternalMemoryStateManagement.json";

        public static void Save(InternalMemoryStateManagement InternalState)
        {
            try
            {
                if (!Directory.Exists(Path.GetDirectoryName(strPath)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(strPath));
                }

                string json = JsonConvert.SerializeObject(InternalState);
                File.WriteAllText(strPath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception writing to file: " + ex.Message);
            }
        }

        public static InternalMemoryStateManagement Load()
        {
            string json = string.Empty;
            InternalMemoryStateManagement InternalState;

            if (!Directory.Exists(strPath))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(strPath));
            }

            if (!File.Exists(strPath))
            {
                InternalState = new InternalMemoryStateManagement();
                try
                {
                    using (FileStream fs = new FileStream(strPath, FileMode.Create, FileAccess.Write))
                    {

                        //XmlSerializer serializer = new XmlSerializer(typeof(InternalMemoryStateManagement));

                        TextWriter writer = new StreamWriter(fs);
                        json = JsonConvert.SerializeObject(InternalState);
                        writer.Write(json);
                        writer.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exception reading to file: " + ex.Message);
                }
            }

            try
            {
                using (FileStream fs = new FileStream(strPath, FileMode.Open, FileAccess.Read))
                {
                   

                    TextReader reader = new StreamReader(fs);
                    json = reader.ReadToEnd();
                    InternalState = JsonConvert.DeserializeObject<InternalMemoryStateManagement>(json);
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception reading machine config file: " + ex.Message);
                InternalState = new InternalMemoryStateManagement();
            }

            return InternalState;
        }
    }

}
