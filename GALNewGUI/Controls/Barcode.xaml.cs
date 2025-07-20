using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
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

namespace MachineNewGUI.Controls
{
    /// <summary>
    /// Interaction logic for Barcode.xaml
    /// </summary>
    public partial class Barcode : UserControl
    {
        public  Entity.Barcode barcode = null;
        private string SavePath = "barcode";
        private string BarcodeName = string.Empty;
        public Barcode()
        {
            InitializeComponent();

            //LoadBarcodeData();

            //this.DataContext = barcode;
        }
        public Entity.Barcode GetCurrentBarcode()
        {
            return barcode;
        }
        public Barcode(string name,int i)
        {
            InitializeComponent();
            BarcodeName = name;
            LoadBarcodeData(i);

            // Bind to UI
            this.DataContext = barcode;
        }
        private void LoadBarcodeData(int i )
        {
            string table = string.Empty;
            try
            {
                if (i == 1)
                {
                    table = "LEFT";
                }
                else
                    table = "RIGHT";
                if (!string.IsNullOrEmpty(BarcodeName))
                    SavePath =table+"_"+SavePath + "_" + BarcodeName + ".json";
                else
                    SavePath =table+"_"+ SavePath + ".json";
                if (File.Exists(SavePath))
                {
                    var json = File.ReadAllText(SavePath);
                    barcode = System.Text.Json.JsonSerializer.Deserialize<Entity.Barcode>(json);
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
                BarcodeName, -210.50, -210.50, 61.58, 61.58, 23, 25);
        }
        private void SaveBarcodeData()
        {
            try
            {
                var json = System.Text.Json.JsonSerializer.Serialize(barcode, new JsonSerializerOptions
                {
                    WriteIndented = true
                });
                File.WriteAllText(SavePath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Save Failure: " + ex.Message);
            }
        }

        private void Barcode_Loaded(object sender, RoutedEventArgs e)
        {
            if (barcode == null)
            {
                barcode = new Entity.Barcode(BarcodeName, -210.50, -210.50, 61.58, 61.58, 23, 25);

            }
            //LoadBarcodeData();
            this.DataContext = barcode;
        }
    }
}
