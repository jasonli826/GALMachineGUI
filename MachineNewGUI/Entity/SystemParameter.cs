using System;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Windows;
using System.Xml.Serialization;
using GalaSoft.MvvmLight;
using JogControl;
using RobotController;

namespace MachineNewGUI.Entity
{
    [Serializable]
    public class RobotTipCalibPoint : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        RobotPoint tip0Deg = new RobotPoint();
        public RobotPoint Tip0Deg
        {
            get => tip0Deg;
            set { tip0Deg = value; OnPropertyChanged(nameof(Tip0Deg)); }
        }

        RobotPoint tip180Deg = new RobotPoint();
        public RobotPoint Tip180Deg
        {
            get => tip180Deg;
            set { tip180Deg = value; OnPropertyChanged(nameof(Tip180Deg)); }
        }

        RobotPoint tipOffset = new RobotPoint();
        public RobotPoint TipOffset
        {
            get => tipOffset;
            set { tipOffset = value; OnPropertyChanged(nameof(TipOffset)); }
        }

        RobotPoint tipBarcodePt = new RobotPoint();
        public RobotPoint TipBarcodePt
        {
            get => tipBarcodePt;
            set { tipBarcodePt = value; OnPropertyChanged(nameof(TipBarcodePt)); }
        }
    }

    // ✅ ViewModel
    public class SystemParameter : GalaSoft.MvvmLight.ViewModelBase
    {
        public RobotTipCalibPoint Tip1 { get; set; } = new RobotTipCalibPoint();
        public RobotTipCalibPoint Tip2 { get; set; } = new RobotTipCalibPoint();
        public RobotPoint FixtureBarcodePoint { get; set; } = new RobotPoint();
        public RobotPoint ScannerLeftPos { get; set; } = new RobotPoint();
        public RobotPoint ScannerRightPos { get; set; } = new RobotPoint();
        public RobotJointAngle ScannerLeftJointAngle { get; set; } = new RobotJointAngle();
        public RobotJointAngle ScannerRightJointAngle { get; set; } = new RobotJointAngle();
        public double Arm2OrgLength { get; set; }
        public double Arm2Length { get; set; }
        public double Arm2Angle { get; set; }
    }

    // ✅ Pure DTO for XML serialization
    [Serializable]
    public class SystemParameterData
    {
        public RobotTipCalibPoint Tip1 { get; set; } = new RobotTipCalibPoint();
        public RobotTipCalibPoint Tip2 { get; set; } = new RobotTipCalibPoint();
        public RobotPoint FixtureBarcodePoint { get; set; } = new RobotPoint();
        public RobotPoint ScannerLeftPos { get; set; } = new RobotPoint();
        public RobotPoint ScannerRightPos { get; set; } = new RobotPoint();
        public RobotJointAngle ScannerLeftJointAngle { get; set; } = new RobotJointAngle();
        public RobotJointAngle ScannerRightJointAngle { get; set; } = new RobotJointAngle();
        public double Arm2OrgLength { get; set; }
        public double Arm2Length { get; set; }
        public double Arm2Angle { get; set; }
    }

    // ✅ Converter between ViewModel and DTO
    public static class SystemParameterConverter
    {
        public static SystemParameterData ToData(SystemParameter vm)
        {
            return new SystemParameterData
            {
                Tip1 = vm.Tip1,
                Tip2 = vm.Tip2,
                FixtureBarcodePoint = vm.FixtureBarcodePoint,
                ScannerLeftPos = vm.ScannerLeftPos,
                ScannerRightPos = vm.ScannerRightPos,
                ScannerLeftJointAngle = vm.ScannerLeftJointAngle,
                ScannerRightJointAngle = vm.ScannerRightJointAngle,
                Arm2OrgLength = vm.Arm2OrgLength,
                Arm2Length = vm.Arm2Length,
                Arm2Angle = vm.Arm2Angle
            };
        }

        public static SystemParameter FromData(SystemParameterData data)
        {
            return new SystemParameter
            {
                Tip1 = data.Tip1,
                Tip2 = data.Tip2,
                FixtureBarcodePoint = data.FixtureBarcodePoint,
                ScannerLeftPos = data.ScannerLeftPos,
                ScannerRightPos = data.ScannerRightPos,
                ScannerLeftJointAngle = data.ScannerLeftJointAngle,
                ScannerRightJointAngle = data.ScannerRightJointAngle,
                Arm2OrgLength = data.Arm2OrgLength,
                Arm2Length = data.Arm2Length,
                Arm2Angle = data.Arm2Angle
            };
        }
    }

    // ✅ Serializer
    public class Serializer
    {
        private static readonly string MachineGUIDirectory = ConfigurationManager.AppSettings["Directory"];
        private static readonly string strFolder = Path.Combine(MachineGUIDirectory, "System");

        public static void Save(SystemParameter vm, string strMachineType)
        {
            if (vm == null) return;

            var data = SystemParameterConverter.ToData(vm);
            string strPath = Path.Combine(strFolder, $"SysParameter{strMachineType}.xml");

            if (!Directory.Exists(Path.GetDirectoryName(strPath)))
                Directory.CreateDirectory(Path.GetDirectoryName(strPath));

            try
            {
                 FileStream fs = new FileStream(strPath, FileMode.Create, FileAccess.Write);
                var serializer = new XmlSerializer(typeof(SystemParameterData));
                TextWriter writer = new StreamWriter(fs);
                serializer.Serialize(writer, data);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception saving SystemParameter: " + ex.Message);
            }
        }

        public static SystemParameter Load(string strMachineType)
        {
            string strPath = Path.Combine(strFolder, $"SysParameter{strMachineType}.xml");

            if (!Directory.Exists(Path.GetDirectoryName(strPath)))
                Directory.CreateDirectory(Path.GetDirectoryName(strPath));

            SystemParameterData data = null;

            if (!File.Exists(strPath))
            {
                data = new SystemParameterData();
                try
                {
                    FileStream fs = new FileStream(strPath, FileMode.Create, FileAccess.Write);
                    var serializer = new XmlSerializer(typeof(SystemParameterData));
                     TextWriter writer = new StreamWriter(fs);
                    serializer.Serialize(writer, data);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exception saving new SystemParameter file: " + ex.Message);
                }
            }

            try
            {
                 FileStream fs = new FileStream(strPath, FileMode.Open, FileAccess.Read);
                var serializer = new XmlSerializer(typeof(SystemParameterData));
                TextReader reader = new StreamReader(fs);
                data = (SystemParameterData)serializer.Deserialize(reader);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception loading SystemParameter file: " + ex.Message);
            }

            return data != null ? SystemParameterConverter.FromData(data) : new SystemParameter();
        }
    }
}
