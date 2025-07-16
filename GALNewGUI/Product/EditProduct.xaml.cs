using GALNewGUI.Controls;
using GALNewGUI.Entity;
using GALNewGUI.JsonEncryption;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GALNewGUI.Product
{
    /// <summary>
    /// Interaction logic for EditProduct.xaml
    /// </summary>
    public partial class EditProduct : Window
    {

        private static readonly Regex _regex = new Regex(@"^[0-9]*(\.[0-9]*)?$");
        private string productFilePath;
        private Root root = null;
        //private ProductParameters productParameter;
        public EditProduct()
        {
            InitializeComponent();
        }
        private void DecimalOnlyTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            string fullText = textBox.Text.Insert(textBox.SelectionStart, e.Text);
            e.Handled = !_regex.IsMatch(fullText);
        }

        private void DecimalOnlyTextBox_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(string)))
            {
                string text = (string)e.DataObject.GetData(typeof(string));
                TextBox textBox = sender as TextBox;
                string fullText = textBox.Text.Insert(textBox.SelectionStart, text);

                if (!_regex.IsMatch(fullText))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }
        public EditProduct(string filePath)
        {
            InitializeComponent();
            productFilePath = filePath;
            if (string.IsNullOrEmpty(productFilePath))
            {
                productFilePath = "C:\\router\\Product File\\NewProductForGAL.json";
            
            }
            LoadProduct(productFilePath);
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void EditProduct_Closing(object sender, CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to save the product file before exiting this page?","Confirm Exit",MessageBoxButton.YesNo,MessageBoxImage.Question);

            if (result != MessageBoxResult.Yes)
            {
                //this.Close();
            }
            else
            {
                SaveProductFile();
                MessageBox.Show("Save Product File Successfully");
            }
        }
        private void LoadProduct(string filePath)
        {
            JsonMechanism jsonDecryption = new JsonMechanism();
            string json = string.Empty;
            if (File.Exists(filePath))
            {
                try
                {
                    json = File.ReadAllText(filePath);
                    json = jsonDecryption.DecryptString(json);
                    root = JsonConvert.DeserializeObject<Entity.Root>(json);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error deserializing JSON: {ex.Message}");
                }
                this.DataContext = root.ProductParameters;
                if (root.ProductParameters.LeftTable != null)
                {

                    ProductHierarchyViewLeftTable.Items = root.ProductParameters.LeftTable.Items;

                }
                if (root.ProductParameters.RightTable != null)
                {

                    ProductHierarchyViewRightTable.Items = root.ProductParameters.RightTable.Items;

                }
            }
            else
            {
                root = new Root();
                root.ProductParameters = new ProductParameters();
                this.DataContext = root.ProductParameters;
            }  
        }
        private void SaveProductFile()
        {
            if (root.ProductParameters.LeftTable == null)
            {
                root.ProductParameters.LeftTable = new LeftTable();
                root.ProductParameters.LeftTable.Items = ProductHierarchyViewLeftTable.GetCurrentTableData();
            }
            else
            {

                root.ProductParameters.LeftTable.Items = ProductHierarchyViewLeftTable.GetCurrentTableData();
            }
            if (root.ProductParameters.RightTable == null)
            {
                root.ProductParameters.RightTable = new RightTable();
                root.ProductParameters.RightTable.Items = ProductHierarchyViewRightTable.GetCurrentTableData();
            }
            else
            {
                root.ProductParameters.RightTable.Items = ProductHierarchyViewRightTable.GetCurrentTableData();
            }
            JsonMechanism jsonEncryption = new JsonMechanism();

            string json = JsonConvert.SerializeObject(root);
            json = jsonEncryption.EncryptionString(json);
            if (File.Exists(productFilePath))
            {
                File.Delete(productFilePath);
                using (StreamWriter writer = new StreamWriter(productFilePath))
                {
                    writer.WriteLine(json);
                }

            }
            else
            {

                File.WriteAllText(productFilePath, json);
            }

        }
        protected void Close_Click(object sender, RoutedEventArgs e)
        {
            //MessageBoxResult result = MessageBox.Show("Do you want to save the product file before exiting this page?", "Confirm Exit", MessageBoxButton.YesNo, MessageBoxImage.Question);

            //if (result != MessageBoxResult.Yes)
            //{
            //    this.Close();
            //}
            //else
            //{
            //    SaveProductFile();
            //    MessageBox.Show("Save Product File Successfully");
            //}
            this.Close();
        }
        protected void SaveFile_Click(object sender, RoutedEventArgs e)
        {
            if (root != null)
            {
                SaveProductFile();
                MessageBox.Show("Save Product File Successfully");
            }
        
        }



    }
}
