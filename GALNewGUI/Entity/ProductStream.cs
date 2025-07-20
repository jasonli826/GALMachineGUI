using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;
using System.Xml.Serialization;
using System.Configuration;
using Newtonsoft.Json;

namespace MachineNewGUI.Entity
{
    public class ProductStream
    {
        private static string MachineGUIDirectroy = ConfigurationManager.AppSettings["Directory"].ToString();
        public static string strFolder = MachineGUIDirectroy + @"\Product File";

        public static void Save(string ProductName, ProductParameters product)
        {
            //validation
            if (product == null)
                return;


            string strPath = strFolder + ProductName + ".xml";

            //create folder
            if (!Directory.Exists(System.IO.Path.GetDirectoryName(strPath)))
                Directory.CreateDirectory(System.IO.Path.GetDirectoryName(strPath));

            //save product
            try
            {
                using (FileStream fs = new FileStream(strPath, FileMode.Create, FileAccess.Write))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(ProductParameters));

                    TextWriter writer = new StreamWriter(fs);
                    serializer.Serialize(writer, product);
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception saving product to file: " + ex.Message);
            }
        }

        public static ProductParameters Load(string name)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(name))
            {
                name = "New Product";
            }

            string strPath = strFolder + name + ".json";

            ProductParameters product = null;

            // If file does not exist, create a new product
            if (!Directory.Exists(Path.GetDirectoryName(strPath)) || !File.Exists(strPath))
            {
                product = new ProductParameters();
            }
            else
            {
                // Load from JSON
                try
                {
                    string json = File.ReadAllText(strPath);
                    product = JsonConvert.DeserializeObject<Product>(json).ProductParameters;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exception loading product file: " + ex.Message);
                    product = new ProductParameters(); // fallback to default if load fails
                }
            }

            return product;
        }
    }

    public static class ProductResults
    {
        static string strRemoteTestResults = @"T:/TestResults/";
        static string strRemoteMidVerificationResults = @"T:/MidVerificationResults/";
        static string strRemoteInspectionResults = @"T:/InspectionResults/";
        static string strRemotePrintResults = @"T:/PrintResults/";

        /// <summary>
        /// Writes to disk file
        /// </summary>
        /// <param name="iType">0 = Test Result, 1 = MidVerificationResult, 2 = Inspection Result, 3 = Print Result</param>
        /// <param name="strMid">Mid String</param>
        /// <param name="iResult">As per the result definitions</param>
        public static void WriteResult(int iType, string strMid, string iResult)
        {
            string strFilePath;
            if (iType == 2)
                strFilePath = strRemoteInspectionResults + strMid + ".csv";
            else if (iType == 3)
                strFilePath = strRemotePrintResults + strMid + ".csv";
            else
                return;

            if (!Directory.Exists(Path.GetDirectoryName(strFilePath)))
                Directory.CreateDirectory(Path.GetDirectoryName(strFilePath));
            try
            {
                using (FileStream fs = new FileStream(strFilePath, FileMode.Create, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        try
                        {
                            sw.WriteLine(iResult);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Exception writing test results to file. " + ex.Message);
                        }
                        finally
                        {
                            sw.Flush();
                            sw.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception writing results to file " + ex.Message);
            }
        }

        /// <summary>
        /// Reads from diskfile
        /// </summary>
        /// <param name="iType">0 = Test Result, 1 = MidVerificationResult, 2 = Inspection Result, 3 = Print Result</param>
        /// <param name="strMid">Mid</param>
        /// <returns>As per respective result definitions</returns>
        public static string ReadResult(int iType, string strMid)
        {
            //to do
            //need to check for drive exists here
            string strResult;
            string strLine;

            string strFilePath;
            if (iType == 0)
                strFilePath = strRemoteTestResults + strMid + ".csv";
            else if (iType == 1)
                strFilePath = strRemoteMidVerificationResults + strMid + ".csv";
            else if (iType == 2)
                strFilePath = strRemoteInspectionResults + strMid + ".csv";
            else if (iType == 3)
                strFilePath = strRemotePrintResults + strMid + ".csv";//local folder exception
            else
                return String.Empty;
            try
            {
                using (FileStream fs = new FileStream(strFilePath, FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        try
                        {
                            strLine = sr.ReadLine();
                            strResult = strLine;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Exception reading test results to file. " + ex.Message);
                            strResult = String.Empty;
                        }
                        finally
                        {
                            sr.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Exception reading result files " + ex.Message);
                strResult = String.Empty;
                //throw ex;
            }

            return strResult;
        }

        /// <summary>
        /// Deletes all results if exists
        /// </summary>
        /// <param name="strMid"></param>
        public static void DeleteResult(string strMid)
        {
            try
            {
                FileInfo fi = new FileInfo(strRemoteTestResults + strMid + ".csv");
                if (fi.Exists)
                    fi.Delete();
                FileInfo fi1 = new FileInfo(strRemoteMidVerificationResults + strMid + ".csv");
                if (fi1.Exists)
                    fi1.Delete();
                FileInfo fi2 = new FileInfo(strRemoteInspectionResults + strMid + ".csv");
                if (fi2.Exists)
                    fi2.Delete();
                FileInfo fi3 = new FileInfo(strRemotePrintResults + strMid + ".csv");
                if (fi3.Exists)
                    fi3.Delete();
            }
            catch (Exception ex)
            {
                //                
            }

        }

        public static void DeleteResults()
        {
            try
            {
                string[] files = Directory.GetFiles(strRemoteTestResults);
                foreach (string str in files)
                {
                    File.Delete(str);
                }
                files = Directory.GetFiles(strRemoteMidVerificationResults);
                foreach (string str in files)
                {
                    File.Delete(str);
                }
                files = Directory.GetFiles(strRemoteInspectionResults);
                foreach (string str in files)
                {
                    File.Delete(str);
                }
                files = Directory.GetFiles(strRemotePrintResults);
                foreach (string str in files)
                {
                    File.Delete(str);
                }
            }
            catch (Exception ex)
            {
                //
            }
        }
    }

    public class LabelDisplay : INotifyPropertyChanged
    {
        public LabelDisplay()
        {

        }

        string _MID = "123";
        public string MID
        {
            get { return _MID; }
            set { _MID = value; OnPropertyChanged(nameof(MID)); }
        }

        public Brush brush
        {
            get => Pass ? new SolidColorBrush(Colors.Green) : new SolidColorBrush(Colors.Red);
        }

        bool _Pass;
        public bool Pass
        {
            get { return _Pass; }
            set
            {
                _Pass = value;
                OnPropertyChanged(nameof(Pass));
                OnPropertyChanged(nameof(brush));
            }
        }

        string _FailReason = "";
        public string FailReason
        {
            get { return _FailReason; }
            set { _FailReason = value; OnPropertyChanged(nameof(FailReason)); }
        }

        public string display { get => MID + " " + FailReason; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
