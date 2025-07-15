using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProductViewHierarchy.Controls
{
    /// <summary>
    /// Interaction logic for Barcode.xaml
    /// </summary>
    public partial class Barcode : UserControl
    {
        public ProductViewHierarchy.Entity.Barcode barcode = null;
        private string SavePath = "barcode";
        private string Name = string.Empty;


        public Barcode()
        {
            InitializeComponent();

            // Populate dropdowns
            //for (int i = 0; i <= 10; i++)
            //{
            //    cmbListForSendParameter.Items.Add(i);
            //    cmbListForSaveParameter.Items.Add(i);
            //}
            //cmbListForSendParameter.SelectedIndex = 0;
            //cmbListForSaveParameter.SelectedIndex = 0;

            // Load saved or default barcode
            LoadBarcodeData();

            // Bind to UI
            this.DataContext = barcode;
        }
        public Entity.Barcode GetCurrentBarcode()
        {
            return barcode;
        }
        public Barcode(string name)
        {
            InitializeComponent();
            Name = name;
            // Populate dropdowns
            //for (int i = 0; i <= 10; i++)
            //{
            //    cmbListForSendParameter.Items.Add(i);
            //    cmbListForSaveParameter.Items.Add(i);
            //}
            //cmbListForSendParameter.SelectedIndex = 0;
            //cmbListForSaveParameter.SelectedIndex = 0;

            // Load saved or default barcode
            LoadBarcodeData();

            // Bind to UI
            this.DataContext = barcode;
        }
        private void LoadBarcodeData()
        {
            try
            {
                if (!string.IsNullOrEmpty(Name))
                    SavePath = SavePath + "_" + Name + ".json";
                else
                    SavePath = SavePath + ".json";
                if (File.Exists(SavePath))
                {
                    var json = File.ReadAllText(SavePath);
                    barcode =JsonConvert.DeserializeObject<Entity.Barcode>(json);
                }

                if (barcode == null)
                {
                    barcode = GetDefaultBarcode();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load Failure: " + ex.Message);
                barcode = GetDefaultBarcode();
            }

            // ✅ Attach change event so every update triggers Save
            barcode.PropertyChanged += (_, __) => SaveBarcodeData();
        }

        private Entity.Barcode GetDefaultBarcode()
        {
            return new Entity.Barcode(
                Name, -210.50, -210.50, 61.58, 61.58,23,25);
        }
        private void SaveBarcodeData()
        {
            try
            {
                var json = JsonConvert.SerializeObject(barcode);
                File.WriteAllText(SavePath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Save Failure: " + ex.Message);
            }
        }

        private  void Barcode_Loaded(object sender, RoutedEventArgs e)
        {
            if (barcode == null)
            {
                barcode = new Entity.Barcode(Name, -210.50, -210.50, 61.58, 61.58, 23, 25);
            
            }
            //LoadBarcodeData();
            this.DataContext = barcode;
        }
    }
}
