﻿using MachineNewGUI.Controls;
using MachineNewGUI.Entity;
using MachineNewGUI.JsonEncryption;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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

namespace MachineNewGUI.Product
{
    /// <summary>
    /// Interaction logic for EditProduct.xaml
    /// </summary>
    public partial class EditProduct : Window
    {
        private string MachineGUIDirectroy = ConfigurationManager.AppSettings["Directory"].ToString();
        private static readonly Regex _regex = new Regex(@"^[0-9]*(\.[0-9]*)?$");
        private string currentProductName;
        private Entity.Product root = null;
        private bool flag = false;
        private bool isSaveFile = false;
        private ProductParameters productParameter=null;
        private string productFilePath = string.Empty;
        //private InternalMemoryStateManagement InternalMemoryStateManagement = null;
        //public event Action<InternalMemoryStateManagement> InternalMemoryStateManagementReady;
        //private bool isCreateProduct = false;
        public EditProduct()
        {
            InitializeComponent();
        }
        public EditProduct(string productName)
        {
            string directory = MachineGUIDirectroy + @"/Product Files";
            InitializeComponent();
            currentProductName = productName;
            productFilePath = MachineGUIDirectroy + @"/Product Files/" + currentProductName + ".json";
       

        }
        protected void EditProduct_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCurrentProduct();



        }
        private void EditProduct_Closing(object sender, CancelEventArgs e)
        {
            if (root.ProductParameters != null)
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
                if (!AreObjectsEqualByValue<ProductParameters>(root.ProductParameters, productParameter))
                {
                    MessageBoxResult result = MessageBox.Show("Do you want to save the product file before exiting this page?", "Confirm Exit", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    if (result != MessageBoxResult.Yes)
                    {

                        //this.Close();
                    }
                    else
                    {

                        SaveProductFile();

                    }
                }

            }

        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void LoadCurrentProduct()
        {

            if (!string.IsNullOrEmpty(currentProductName))
            {
                root = new Entity.Product();
                root.ProductParameters = ProductStream.Load(currentProductName);

                if (root.ProductParameters.LeftTable != null)
                {

                    ProductHierarchyViewLeftTable.Items = root.ProductParameters.LeftTable.Items;

                }
                if (root.ProductParameters.RightTable != null)
                {

                    ProductHierarchyViewRightTable.Items = root.ProductParameters.RightTable.Items;

                }

                this.DataContext = root.ProductParameters;
                productFilePath = MachineGUIDirectroy + @"/Product Files/" + currentProductName + ".json";
                var tempObj = JsonConvert.SerializeObject(root.ProductParameters);
                productParameter = JsonConvert.DeserializeObject<ProductParameters>(tempObj);
            }
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

        private bool FileNameExists(string fileName, string directoryPath)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                throw new ArgumentException("File name must not be empty.", nameof(fileName));

            if (!Directory.Exists(directoryPath))
                throw new DirectoryNotFoundException($"Directory not found: {directoryPath}");

            foreach (var filePath in Directory.EnumerateFiles(directoryPath, "*", SearchOption.AllDirectories))
            {
                string temp = System.IO.Path.GetFileNameWithoutExtension(filePath);
                if (string.Equals(temp, fileName, StringComparison.OrdinalIgnoreCase))
                    return true;
            }

            return false;
        }
  
        private bool AreObjectsEqualByValue<T>(T obj1, T obj2)
        {
            if (obj1 == null && obj2 == null) return true;
            if (obj1 == null || obj2 == null) return false;

            var json1 = JsonConvert.SerializeObject(obj1);
            var json2 = JsonConvert.SerializeObject(obj2);

            return json1 == json2;
        }



        private void LoadProduct(string filePath)
        {

            //JsonMechanism jsonDecryption = new JsonMechanism();
            string json = string.Empty;
            if (File.Exists(filePath))
            {
                try
                {
                    json = File.ReadAllText(filePath);
                    json = XorJsonEncryption.Decrypt(json);
                    root = JsonConvert.DeserializeObject<Entity.Product>(json);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error deserializing JSON: {ex.Message}");
                }
                if (root != null)
                {
                    if (root.ProductParameters.LeftTable != null)
                    {

                        ProductHierarchyViewLeftTable.Items = root.ProductParameters.LeftTable.Items;

                    }
                    if (root.ProductParameters.RightTable != null)
                    {

                        ProductHierarchyViewRightTable.Items = root.ProductParameters.RightTable.Items;

                    }
                    if (root.ProductParameters.InputTray == null)
                        root.ProductParameters.InputTray = new Tray();
                    if (root.ProductParameters.InputTray.ModuleBarcode_Points == null)
                        root.ProductParameters.InputTray.ModuleBarcode_Points = new JogControl.RobotPoint();
                    if (root.ProductParameters.InputTray.BarcodeOffset_Points == null)
                        root.ProductParameters.InputTray.BarcodeOffset_Points = new JogControl.RobotPoint();
                    if (root.ProductParameters.AdaptorPallet == null)
                    {
                        root.ProductParameters.AdaptorPallet = new Tray();
                        if (root.ProductParameters.AdaptorPallet.BarcodeOffset_Points == null)
                            root.ProductParameters.AdaptorPallet.BarcodeOffset_Points = new JogControl.RobotPoint();
                        if (root.ProductParameters.AdaptorPallet.PlacementOffset == null)
                            root.ProductParameters.AdaptorPallet.PlacementOffset = new JogControl.RobotPoint();

                    }
                    this.DataContext = root.ProductParameters;
                }
            }
            else
            {
                root = new Entity.Product();
                root.ProductParameters = new ProductParameters();
                root.ProductParameters.ProductName = currentProductName;
                root.ProductParameters.ProductFileName = currentProductName;
                this.DataContext = root.ProductParameters;

            }

            var tempObj = JsonConvert.SerializeObject(root.ProductParameters);
            productParameter = JsonConvert.DeserializeObject<ProductParameters>(tempObj);
        }
        private void SaveProductFile()
        {
            string fileName = string.Empty;
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
               

                string json = JsonConvert.SerializeObject(root);
                json = XorJsonEncryption.Encrypt(json);

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

                    //isCreateProduct = true;
                    File.WriteAllText(productFilePath, json);
                }
                MessageBox.Show("Save Product File Successfully");
            

            var tempObj = JsonConvert.SerializeObject(root.ProductParameters);
            productParameter = JsonConvert.DeserializeObject<ProductParameters>(tempObj);
            
        }
        protected void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        protected void SaveFile_Click(object sender, RoutedEventArgs e)
        {
            if (root != null)
            {
               
                SaveProductFile();
                //WindowClosedWithData?.Invoke(this, "Data from child");
            }
        
        }
    }
}
