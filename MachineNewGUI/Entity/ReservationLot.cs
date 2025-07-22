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
using System.Xml.Linq;

namespace MachineNewGUI.Entity
{
    public class Lot
    {
        [XmlAttribute]
        public string LotCode;
        [XmlAttribute]
        public string continuation;
        [XmlElement]
        public string UserName;
        [XmlElement]
        public string SystemId;
        [XmlElement]
        public string InspectionType;
        [XmlElement]
        public string Assembly;
        [XmlElement]
        public string StartTime;
        [XmlElement]
        public string EndTime;
        [XmlElement]
        public List<C_Tray> Tray = new List<C_Tray>();

        public Lot()
        {
        } 
    }
    public class C_Tray
    {
        [XmlAttribute]
        public string Name;
        [XmlAttribute]
        public string TrayStatus;
        [XmlAttribute]
        public string Barcode;
        [XmlElement]
        public List<C_Module> Module = new List<C_Module>();
    }
    public class C_Module
    {
        [XmlAttribute]
        public string Name;
       [XmlAttribute]
        public string Barcode;
       [XmlAttribute]
        public string Output_slot;
       [XmlAttribute]
        public string ReworkError;
        public C_Module()
        {

        }
        public C_Module(string name, string barcode, string output_slot, string reworkError)
        {
            Name = name;
            Barcode = barcode;
            Output_slot = output_slot;
            ReworkError = reworkError;
        }
    }



    public class ResvervationDataStream
    {
        static string strFolder = @"c:/GAL/System/";
        public static void Save(Lot data,string PathAndFileName)
        {
            //validation
            if (data == null)
                return;

            string strPath = PathAndFileName + ".xml";// strFolder + "Reservation_Lot" + ".xml";

            //create folder
            if (!Directory.Exists(System.IO.Path.GetDirectoryName(strPath)))
                Directory.CreateDirectory(System.IO.Path.GetDirectoryName(strPath));


            //save product
            try
            {
                using (FileStream fs = new FileStream(strPath, FileMode.Create, FileAccess.Write))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Lot));
                    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                    ns.Add("", "");
                    TextWriter writer = new StreamWriter(fs);
                    serializer.Serialize(writer, data, ns);
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception saving ReservationInfo_Tool to file: " + ex.Message);
            }
        }

        public static Lot Load(string PathAndFileName)
        {
            Lot data = null;

            string strPath = PathAndFileName + ".xml";//strFolder + "Reservation_Lot" + ".xml";

            //save if file does not exist
            if ((Directory.Exists(System.IO.Path.GetDirectoryName(strPath)) || (!File.Exists(strPath))))
            {
                if (!Directory.Exists(System.IO.Path.GetDirectoryName(strPath)))
                    Directory.CreateDirectory(System.IO.Path.GetDirectoryName(strPath));

                data = new Lot();
                File.Delete(strPath);
                if (!File.Exists(strPath))
                {
                    try
                    {
                        using (FileStream fs = new FileStream(strPath, FileMode.Create, FileAccess.Write))
                        {
                            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                            ns.Add("", "");

                            XmlSerializer serializer = new XmlSerializer(typeof(Lot));
                            // XmlRootAttribute = false;
                            TextWriter writer = new StreamWriter(fs);

                            serializer.Serialize(writer, data, ns);
                            writer.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Exception saving Reservation_Lot file: " + ex.Message);
                    }
                }
            }

            //loading
            try
            {
                using (FileStream fs = new FileStream(strPath, FileMode.Open, FileAccess.Read))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Lot));

                    TextReader reader = new StreamReader(fs);
                    data = (Lot)serializer.Deserialize(reader);
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception loading Reservation_Lot file: " + ex.Message);
            }
            return data;
        }
    }
}
