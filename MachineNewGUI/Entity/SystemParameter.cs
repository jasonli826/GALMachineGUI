using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using JogControl;
using RobotController;
using System.IO;
using System.Windows;

namespace MachineNewGUI.Entity
{
    [Serializable]

    public class RobotTipCalibPoint : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #region "LOADER"

        RobotPoint tip0Deg = new RobotPoint();

        public RobotPoint Tip0Deg
        {

            get { return tip0Deg; }
            set
            {
                tip0Deg = value;
                this.OnPropertyChanged("Tip0Deg");
            }
        }
        RobotPoint tip180Deg = new RobotPoint();
        public RobotPoint Tip180Deg
        {

            get { return tip180Deg; }
            set
            {
                tip180Deg = value;
                this.OnPropertyChanged("Tip180Deg");
            }
        }
        RobotPoint tipOffset = new RobotPoint();
        public RobotPoint TipOffset
        {

            get { return tipOffset; }
            set
            {
                tipOffset = value;
                this.OnPropertyChanged("TipOffset");
            }
        }
        RobotPoint tipBarcodePt = new RobotPoint();
        public RobotPoint TipBarcodePt
        {

            get { return tipBarcodePt; }
            set
            {
                tipBarcodePt = value;
                this.OnPropertyChanged("TipBarcodePt");
            }
        }

        #endregion

    }


    public class SystemParameter : ViewModelBase
    {
        public SystemParameter()
        {

        }

        #region "LOADER"

        RobotTipCalibPoint tip1 = new RobotTipCalibPoint();
        public RobotTipCalibPoint Tip1
        {

            get { return tip1; }
            set { tip1 = value; this.OnPropertyChanged("Tip1"); }
        }
        RobotTipCalibPoint tip2 = new RobotTipCalibPoint();

        public RobotTipCalibPoint Tip2
        {
            get { return tip2; }
            set { tip2 = value; this.OnPropertyChanged("Tip2"); }
        }
        RobotTipCalibPoint tip3 = new RobotTipCalibPoint();

        public RobotTipCalibPoint Tip3
        {
            get { return tip3; }
            set { tip3 = value; this.OnPropertyChanged("Tip3"); }
        }

        RobotPoint fixtureBarcodePoint = new RobotPoint();
        public RobotPoint FixtureBarcodePoint
        {

            get { return fixtureBarcodePoint; }
            set { fixtureBarcodePoint = value; this.OnPropertyChanged("FixtureBarcodePoint"); }
        }

        RobotPoint scannerLeftPos = new RobotPoint();
        public RobotPoint ScannerLeftPos
        {

            get { return scannerLeftPos; }
            set { scannerLeftPos = value; this.OnPropertyChanged("ScannerLeftPos"); }
        }
        RobotPoint scannerRightPos = new RobotPoint();
        public RobotPoint ScannerRightPos
        {
            get { return scannerRightPos; }
            set { scannerRightPos = value; this.OnPropertyChanged("scannerRightPos"); }
        }
        RobotJointAngle scannerLeftJointAngle = new RobotJointAngle();
        public RobotJointAngle ScannerLeftJointAngle
        {
            get { return scannerLeftJointAngle; }
            set { scannerLeftJointAngle = value; this.OnPropertyChanged(""); }
        }
        RobotJointAngle scannerRightJointAngle = new RobotJointAngle();
        public RobotJointAngle ScannerRightJointAngle
        {
            get { return scannerRightJointAngle; }
            set { scannerRightJointAngle = value; this.OnPropertyChanged("ScannerRightJointAngle"); }
        }

        double arm2OrgLength;
        public double Arm2OrgLength
        {
            get { return arm2OrgLength; }
            set { arm2OrgLength = value; this.OnPropertyChanged("Arm2OrgLength"); }
        }
        double arm2Length;
        public double Arm2Length
        {
            get { return arm2Length; }
            set { arm2Length = value; this.OnPropertyChanged("Arm2Length"); }
        }
        double arm2Angle;
        public double Arm2Angle
        {
            get { return arm2Angle; }
            set { arm2Angle = value; this.OnPropertyChanged("Arm2Angle"); }
        }

        #endregion 

    }

    public class Serializer
    {
        static string strFolder = @"c:/GAL/System/";
        public static void Save(SystemParameter data, string strMachineType)
        {
            //validation
            if (data == null)
                return;

            string strPath = strFolder + "SysParameter" + strMachineType + ".xml";

            //create folder
            if (!Directory.Exists(System.IO.Path.GetDirectoryName(strPath)))
                Directory.CreateDirectory(System.IO.Path.GetDirectoryName(strPath));

            //save product
            try
            {
                using (FileStream fs = new FileStream(strPath, FileMode.Create, FileAccess.Write))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(SystemParameter));

                    TextWriter writer = new StreamWriter(fs);
                    serializer.Serialize(writer, data);
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception saving SystemParameter to file: " + ex.Message);
            }
        }

        public static SystemParameter Load(string strMachineType)
        {
            SystemParameter data = null;

            string strPath = strFolder + "SysParameter" + strMachineType + ".xml";

            //save if file does not exist
            if ((Directory.Exists(System.IO.Path.GetDirectoryName(strPath)) || (!File.Exists(strPath))))
            {
                if (!Directory.Exists(System.IO.Path.GetDirectoryName(strPath)))
                    Directory.CreateDirectory(System.IO.Path.GetDirectoryName(strPath));

                data = new SystemParameter();
                if (!File.Exists(strPath))
                {

                    try
                    {
                        using (FileStream fs = new FileStream(strPath, FileMode.Create, FileAccess.Write))
                        {
                            XmlSerializer serializer = new XmlSerializer(typeof(SystemParameter));

                            TextWriter writer = new StreamWriter(fs);
                            serializer.Serialize(writer, data);
                            writer.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Exception saving SystemParameter file: " + ex.Message);
                    }
                }
            }

            //loading
            try
            {
                using (FileStream fs = new FileStream(strPath, FileMode.Open, FileAccess.Read))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(SystemParameter));

                    TextReader reader = new StreamReader(fs);
                    data = (SystemParameter)serializer.Deserialize(reader);
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception loading SystemParameter file: " + ex.Message);
            }
            return data;
        }


        //public static void SerializeXML<T>(string Filepath, T pt)
        //{
        //    XmlSerializer xmlser = new XmlSerializer(typeof(T));

        //    using (TextWriter textWriter = new StreamWriter(Filepath))
        //    {
        //        xmlser.Serialize(textWriter, pt);
        //    }
        //}
        //public static object DeserializeXML<T>(string Filepath)
        //{


        //    XmlSerializer xmlser = new XmlSerializer(typeof(T));
        //    using (TextReader textReader = new StreamReader(Filepath))
        //    {
        //        return xmlser.Deserialize(textReader);
        //    }

        //}



    }
}
