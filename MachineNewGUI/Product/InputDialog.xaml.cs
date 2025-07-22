
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
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
using Path = System.IO.Path;

namespace MachineNewGUI.Product
{
    /// <summary>
    /// Interaction logic for InputDialog.xaml
    /// </summary>
    public partial class InputDialog : Window
    {
        private string MachineGUIDirectroy = ConfigurationManager.AppSettings["Directory"].ToString();
        public InputDialog()
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(txtAnswer.Text.Trim()))
            {
                txtAnswer.Text = "NewProduct";
            }
        }
        public InputDialog(string question, string defaultAnswer = "")
        {
            InitializeComponent();
            lblQuestion.Content = question;
            txtAnswer.Text = defaultAnswer;
        }

        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            string directoryPath = MachineGUIDirectroy + @"/Product Files";
            string productName = txtAnswer.Text.Trim();

            if (string.IsNullOrEmpty(productName))
            {
                MessageBox.Show("Product Name Cannot be empty");
                return;
            }
            if (FileNameExists(productName,directoryPath))
            {
                MessageBox.Show("File Name Already Exsits And Please Change The File Name");
                return;

            }

            //var NewProductWindow = new MachineNewGUI.Product.EditProduct(productName); // Use the correct namespace if needed

            //NewProductWindow.InternalMemoryStateManagementReady += (InternalMemoryStateManagementReady) =>
            //{
            //    ProductCreated?.Invoke(InternalMemoryStateManagementReady); // Forward to MainWindow
            //};

            //NewProductWindow.ShowDialog(); // Or use Show() if you don’t want modal
            this.DialogResult = true;
        }
 
        private bool isDuplicationProductFile(string productName)
        {
            string fileDirectory = MachineGUIDirectroy + @"/Product Files";
            var duplicateNames = from filePath in Directory.GetFiles(fileDirectory, "*", SearchOption.AllDirectories)
                                 let filename = Path.GetFileName(productName)
                                 group filePath by filename into files
                                 where files.Count() > 1
                                 select files;
            if (duplicateNames.Count() > 1)
                return true;

            return false;
        }
        public static bool FileNameExists(string fileName, string directoryPath)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                throw new ArgumentException("File name must not be empty.", nameof(fileName));

            if (!Directory.Exists(directoryPath))
                throw new DirectoryNotFoundException($"Directory not found: {directoryPath}");

            foreach (var filePath in Directory.EnumerateFiles(directoryPath, "*", SearchOption.AllDirectories))
            {
                string temp = Path.GetFileNameWithoutExtension(filePath);
                if (string.Equals(temp, fileName, StringComparison.OrdinalIgnoreCase))
                    return true;
            }

            return false;
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public string Answer
        {
            get { return txtAnswer.Text; }
        }
    }
}
