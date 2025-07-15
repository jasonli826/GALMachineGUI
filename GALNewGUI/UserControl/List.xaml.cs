using Newtonsoft.Json;
using ProductViewHierarchy.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
    /// Interaction logic for List.xaml
    /// </summary>
    public partial class List : UserControl
    {
        public ProductViewHierarchy.Entity.List list = null;
        private string SavePath = "list";
        private string Name = string.Empty;

        public List()
        {
            InitializeComponent();
            LoadListData();

            // Bind to UI
            this.DataContext = list;
        }
        public Entity.List GetCurrentList()
        {
            return list;
        }

        private void LoadListData()
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
                    list = JsonConvert.DeserializeObject<Entity.List>(json);
                }

                if (list == null)
                {
                    list = GetDefaultList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load Failure: " + ex.Message);
                list = GetDefaultList();
            }

            // ✅ Attach change event so every update triggers Save
            list.PropertyChanged += (_, __) => SaveBarcodeData();
        }

        private Entity.List GetDefaultList()
        {
            return new Entity.List(-224.87,159.65,-224.87,159.65,-59.85,33.61,-59.85,-10,1,10,6.00);
        }
        private void SaveBarcodeData()
        {
            try
            {

                var json = JsonConvert.SerializeObject(list);
                File.WriteAllText(SavePath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Save Failure: " + ex.Message);
            }
        }

        private void Barcode_Loaded(object sender, RoutedEventArgs e)
        {
            if (list == null)
            {
                list = GetDefaultList();

            }
            this.DataContext = list;
        }
    }
}
