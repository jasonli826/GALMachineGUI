using RobotController;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Numerics;
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
//using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MachineNewGUI.WindowPage
{
    /// <summary>
    /// Interaction logic for ErrorDescriptionConfig.xaml
    /// </summary>
    public partial class ErrorDescriptionConfig : Window, INotifyPropertyChanged
    {
        public string ErrorDescriptionPath = MainWindow.ErrorDescriptionPath;
        ObservableCollection<RobotDescError> RobotErrors;
        public ObservableCollection<RobotDescError> robotErrors
        {
            get { return RobotErrors; }
            set { RobotErrors = value; OnPropertyChanged(nameof(robotErrors)); }
        }
        public Dictionary<int, string> dictErrorList = new Dictionary<int, string>();

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ErrorDescriptionConfig(Dictionary<int, string> _dictErrorList)
        {
            InitializeComponent();
            dictErrorList = _dictErrorList;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Check if ErrorDescription txt exists
            if (!File.Exists(ErrorDescriptionPath))
            {
                MessageBox.Show("Error Description file is not found and now we will create one at following location:\n \""+ ErrorDescriptionPath + "\"");
            }
            robotErrors = new ObservableCollection<RobotDescError>();

            //Read dictErrorList and save them into robotErrors
            foreach (KeyValuePair<int, string> err in dictErrorList)
            {
                robotErrors.Add(new RobotDescError { ErrorCode = err.Key.ToString().Trim(), ErrorMsg = err.Value.Trim()});
            }

            //Read ErrorDescription.txt and save them into robotErrors
            using (FileStream fs = new FileStream(ErrorDescriptionPath, FileMode.OpenOrCreate, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    while (!sr.EndOfStream)
                    {
                        string errorDescription = "";
                        string txt = sr.ReadLine();
                        string[] error1 = txt.Split(',');
                        if (error1.Length < 2)
                            continue;
                        int n;
                        //Error code Validation (Only acccept integer)
                        if (int.TryParse(error1[0].Trim(), out n))
                        {
                            //Check if dictErrorList contains the same Error Code, if not then skip
                            if (!dictErrorList.ContainsKey(n))
                                continue;
                            //Get the full error description
                            for (int i = 1; i <= error1.Length - 1; i++)
                            {
                                if (errorDescription != "")
                                    errorDescription += ", ";
                                errorDescription += error1[i].Trim();
                            }
                            if (errorDescription != "")
                            {
                                //Search error with same ErrorCode and set its description
                                var err = robotErrors.Where(x => x.ErrorCode == n.ToString()).FirstOrDefault();

                                //Replace \\r\\n into \r\n
                                string errDesc = errorDescription.Replace("\\r\\n", "\r\n");

                                if (err != null)
                                    err.ErrorDescription = errDesc;
                            }  
                        }
                    }
                    sr.Close();
                }
            }
            datagridErrors.ItemsSource = robotErrors;
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {   
            //Saving Confirmation
            MessageBoxResult result = MessageBox.Show("Are you sure to save?", "Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    //Clearing whole txt before writing
                    File.WriteAllText(ErrorDescriptionPath, string.Empty);
                    using (FileStream fs = new FileStream(ErrorDescriptionPath, FileMode.Open, FileAccess.ReadWrite))
                    {
                        using (StreamWriter sw = new StreamWriter(fs))
                        {
                            foreach (RobotDescError error in robotErrors)
                            {
                                //Skip if ErrorDescription is empty
                                if (error.ErrorDescription == null || error.ErrorDescription == "")
                                    continue;

                                //Replace \r\n into \\r\\n
                                string errDesc = error.ErrorDescription.Replace("\r\n", "\\r\\n");

                                //Write into Error Description txt file
                                sw.WriteLine(error.ErrorCode.Trim() + ", " + errDesc.Trim());
                            }
                            sw.Close();
                        }
                        fs.Close();
                    }
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
                return;
        }

        private void DescTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;

            // Count number of lines (split by newline)
            string[] lines = textBox.Text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

            if (lines.Length > 6)
            {
                textBox.Text = string.Join(Environment.NewLine, lines.Take(5));
                textBox.CaretIndex = textBox.Text.Length;
            }
        }
    }
    public class RobotDescError
    {
        public string ErrorCode { get; set; }
        public string ErrorMsg { get; set; }
        public string ErrorDescription { get; set; }
    }
}
