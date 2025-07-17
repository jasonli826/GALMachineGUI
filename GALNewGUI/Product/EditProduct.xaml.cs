using GALNewGUI.Controls;
using GALNewGUI.Entity;
using GALNewGUI.JsonEncryption;
using Microsoft.Win32;
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
        private bool flag = false;
        private bool isSaveFile = false;
        private ProductParameters productParameter=null;
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
        public EditProduct(string filePath,bool f)
        {
            InitializeComponent();
            productFilePath = filePath;
            if (string.IsNullOrEmpty(productFilePath))
            {
                productFilePath = "C:\\router\\Product File\\NewProductForGAL.json";
            
            }
            LoadProduct(productFilePath);
            flag = f;
        }
        private bool AreObjectsEqualByValue<T>(T obj1, T obj2)
        {
            if (obj1 == null && obj2 == null) return true;
            if (obj1 == null || obj2 == null) return false;

            var json1 = JsonConvert.SerializeObject(obj1);
            var json2 = JsonConvert.SerializeObject(obj2);

            return json1 == json2;
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void EditProduct_Closing(object sender, CancelEventArgs e)
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
            if (!AreObjectsEqualByValue<ProductParameters>(root.ProductParameters,productParameter))
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
                root.ProductParameters.InputTray = new InputTray();
                root.ProductParameters.InputTray.ModuleBarcodePoints = new ModuleBarcodePoints();
                root.ProductParameters.InputTray.BarcodeOffsetPoints = new BarcodeOffsetPoints();
                root.ProductParameters.Options = new Options();
                root.ProductParameters.AdaptorPallet = new AdaptorPallet();
                root.ProductParameters.GALTimer = new GALTimer();
                root.ProductParameters.LeftTable = new LeftTable();
                root.ProductParameters.RightTable = new RightTable();
                root.ProductParameters.AdaptorPallet.PlacementOffset = new PlacementOffset();
                root.ProductParameters.AdaptorPallet.BarcodeOffset_Points = new BarcodeOffsetPoints();
                this.DataContext = root.ProductParameters;

            }

            var tempObj = JsonConvert.SerializeObject(root.ProductParameters);
            productParameter = JsonConvert.DeserializeObject<ProductParameters>(tempObj);
            //productParameter = root.ProductParameters.ShallowCopy();
            
            //productParameter.InputTray = root.ProductParameters.InputTray.ShallowCopy();
            //productParameter = root.ProductParameters.ShallowCopy();
            //productParameter.InputTray = root.ProductParameters.InputTray.ShallowCopy();
            //productParameter.InputTray.BarcodeOffset_Points = root.ProductParameters.InputTray.BarcodeOffset_Points.ShallowCopy();
            //productParameter.InputTray.ModuleBarcode_Points = root.ProductParameters.InputTray.ModuleBarcode_Points.ShallowCopy();
            //productParameter.InputTray.CheckSpot1Offset = root.ProductParameters.InputTray.CheckSpot1Offset.ShallowCopy();
            //productParameter.InputTray.CheckSpot2Offset = root.ProductParameters.InputTray.CheckSpot2Offset.ShallowCopy();
            //productParameter.InputTray.CheckSpot3Offset = root.ProductParameters.InputTray.CheckSpot3Offset.ShallowCopy();
            //productParameter.InputTray.CheckSpot4Offset = root.ProductParameters.InputTray.CheckSpot4Offset.ShallowCopy();
            //productParameter.InputTray.CheckSpotEnable = root.ProductParameters.InputTray.CheckSpotEnable.ShallowCopy();
            //productParameter.InputTray.CheckSpotPosOnOff = root.ProductParameters.InputTray.CheckSpotPosOnOff.ShallowCopy();
            //productParameter.InputTray.FlyCheckSpot1Offset = root.ProductParameters.InputTray.FlyCheckSpot1Offset.ShallowCopy();
            //productParameter.InputTray.FlyCheckSpot2Offset = root.ProductParameters.InputTray.FlyCheckSpot2Offset.ShallowCopy();
            //productParameter.InputTray.FlyCheckSpot3Offset = root.ProductParameters.InputTray.FlyCheckSpot3Offset.ShallowCopy();
            //productParameter.InputTray.FlyCheckSpot4Offset = root.ProductParameters.InputTray.FlyCheckSpot4Offset.ShallowCopy();
            //productParameter.InputTray.PlacementOffset = root.ProductParameters.InputTray.PlacementOffset.ShallowCopy();

            //productParameter.Options = root.ProductParameters.Options.ShallowCopy();
            //productParameter.AdaptorPallet = root.ProductParameters.AdaptorPallet.ShallowCopy();
            //productParameter.GALTimer = root.ProductParameters.GALTimer.ShallowCopy();
            //productParameter.LeftTable = root.ProductParameters.LeftTable.ShallowCopy();
            //productParameter.RightTable = root.ProductParameters.RightTable.ShallowCopy();
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
            JsonMechanism jsonEncryption = new JsonMechanism();

            string json = JsonConvert.SerializeObject(root);
            json = jsonEncryption.EncryptionString(json);
            if (flag)
            {
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
                MessageBox.Show("Save Product File Successfully");
            }
            else
            {
                SaveFileDialog openFileDialog = new SaveFileDialog();
                openFileDialog.InitialDirectory = @"C:\router\Product File";
                openFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                fileName = System.IO.Path.GetFileName(productFilePath);
                openFileDialog.FileName = fileName;

                bool? result = openFileDialog.ShowDialog();
                if (result.Value == true)
                {
                    File.WriteAllText(openFileDialog.FileName, json);
                    MessageBox.Show("Save Product File Successfully");
                }
            }
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
              
            }
        
        }



    }
}
