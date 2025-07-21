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
namespace MachineNewGUI.Entity
{
    public class DeltaServoAxisData : INotifyPropertyChanged
    {
        public List<DeltaAxis> deltaAxis { get; set; }

        public int Comport { get; set; }
        public int Baudrate { get; set; }
        public int Databits { get; set; }

        public int Comport1 { get; set; }
        public int Baudrate1 { get; set; }

        public int Comport2 { get; set; }
        public int Baudrate2 { get; set; }

        public int Comport3 { get; set; }
        public int Baudrate3 { get; set; }

        public int Comport4 { get; set; }
        public int Baudrate4 { get; set; }

        public int Comport5 { get; set; }
        public int Baudrate5 { get; set; }

        public int Comport6 { get; set; }
        public int Baudrate6 { get; set; }

        public int Comport7 { get; set; }
        public int Baudrate7 { get; set; }

        public int Comport8 { get; set; }
        public int Baudrate8 { get; set; }

     

        public DeltaServoAxisData()
        {
            deltaAxis = new List<DeltaAxis>();
            Comport = 3;
            Baudrate = 38400;
            Databits = 8;

            Comport1 = 1;
            Baudrate1 = 9600;

            Comport2 = 1;
            Baudrate2 = 9600;

            Comport3 = 1;
            Baudrate3 = 9600;

            Comport4 = 1;
            Baudrate4 = 9600;

            Comport5 = 1;
            Baudrate5 = 9600;

            Comport6 = 1;
            Baudrate6 = 9600;

            Comport7 = 1;
            Baudrate7 = 9600;

            Comport8 = 1;
            Baudrate8 = 9600;    

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
    public class DeltaAxis : INotifyPropertyChanged
    {
        public int AxisNo { get; set; }
        public double RefMov { get; set; }
        public int Refpulse { get; set; }


        public DeltaAxis()
        {

        }
        public DeltaAxis(int num, double refmov, int refpulse)
        {
            AxisNo = num;
            RefMov = refmov;
            Refpulse = refpulse;
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


    public class DeltaServoAxisDataStream
    {
        static string strFolder = @"c:/GAL/System/";
        public static void Save(DeltaServoAxisData data, string strMachineType)
        {
            //validation
            if (data == null)
                return;

            string strPath = strFolder + "DeltaServoAxisData" + strMachineType + ".xml";

            //create folder
            if (!Directory.Exists(System.IO.Path.GetDirectoryName(strPath)))
                Directory.CreateDirectory(System.IO.Path.GetDirectoryName(strPath));

            //save product
            try
            {
                using (FileStream fs = new FileStream(strPath, FileMode.Create, FileAccess.Write))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(DeltaServoAxisData));

                    TextWriter writer = new StreamWriter(fs);
                    serializer.Serialize(writer, data);
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception saving DeltaServoAxisData to file: " + ex.Message);
            }
        }

        public static DeltaServoAxisData Load(string strMachineType, int NoOfAxis)
        {
            DeltaServoAxisData data = null;

            string strPath = strFolder + "DeltaServoAxisData" + strMachineType + ".xml";

            //save if file does not exist
            if ((Directory.Exists(System.IO.Path.GetDirectoryName(strPath)) || (!File.Exists(strPath))))
            {
                if (!Directory.Exists(System.IO.Path.GetDirectoryName(strPath)))
                    Directory.CreateDirectory(System.IO.Path.GetDirectoryName(strPath));

                data = new DeltaServoAxisData();
                if (!File.Exists(strPath))
                {
                    List<DeltaAxis> list = new List<DeltaAxis>();

                    for (int i = 1; i <= NoOfAxis; i++)
                    {
                        list.Add(new DeltaAxis(i, 0, 0));
                    }
                    data.deltaAxis = list;

                    try
                    {
                        using (FileStream fs = new FileStream(strPath, FileMode.Create, FileAccess.Write))
                        {
                            XmlSerializer serializer = new XmlSerializer(typeof(DeltaServoAxisData));

                            TextWriter writer = new StreamWriter(fs);
                            serializer.Serialize(writer, data);
                            writer.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Exception saving DeltaServoAxisData file: " + ex.Message);
                    }
                }
            }

            //loading
            try
            {
                using (FileStream fs = new FileStream(strPath, FileMode.Open, FileAccess.Read))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(DeltaServoAxisData));

                    TextReader reader = new StreamReader(fs);
                    data = (DeltaServoAxisData)serializer.Deserialize(reader);
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception loading DeltaServoAxisData file: " + ex.Message);
            }
            return data;
        }
    }
}
