using GALNewGUI.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
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
        private string productFilePath;
        private Root root = null;
        //private ProductParameters productParameter;
        public EditProduct()
        {
            InitializeComponent();
        }
        public EditProduct(string filePath)
        {
            InitializeComponent();
            productFilePath = filePath;

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
            string json = string.Empty;
            if (File.Exists(filePath))
            {
                json = File.ReadAllText(filePath);
                try
                {
                    root = JsonConvert.DeserializeObject<Entity.Root>(json);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error deserializing JSON: {ex.Message}");
                }
                this.DataContext = root.ProductParameters;
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
            string json = JsonConvert.SerializeObject(root);

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
