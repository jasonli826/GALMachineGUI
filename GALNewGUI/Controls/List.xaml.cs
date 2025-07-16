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

namespace GALNewGUI.Controls
{
    /// <summary>
    /// Interaction logic for List.xaml
    /// </summary>
    public partial class List : UserControl
    {
        public Entity.List list = null;
        private string SavePath = "list";
        private string ListName = string.Empty;

        public List()
        {
            InitializeComponent();

        }
        public List(string name, int i)
        {
            InitializeComponent();
            ListName = name;
            LoadListData(i);

            // Bind to UI
            this.DataContext = list;
        }
        public Entity.List GetCurrentList()
        {
            return list;
        }

        private void LoadListData(int  i)
        {
            try
            {
                string table = string.Empty;
                if (i == 1)
                {
                    table = "LEFT_";
                }
                else
                    table = "RIGHT_";

                if (!string.IsNullOrEmpty(ListName))
                    SavePath = table + SavePath + "_" + ListName + ".json";
                else
                    SavePath = table + SavePath + ".json";
                if (File.Exists(SavePath))
                {
                    var json = File.ReadAllText(SavePath);
                    list = JsonSerializer.Deserialize<Entity.List>(json);
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
            list.PropertyChanged += (_, __) => SaveListData();
        }

        private Entity.List GetDefaultList()
        {
            return new Entity.List(-224.87,159.65,-224.87,159.65,-59.85,33.61,-59.85,-10,1,10,6.00);
        }
        private void SaveListData()
        {
            try
            {
                var json = JsonSerializer.Serialize(list, new JsonSerializerOptions
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

        private void List_Loaded(object sender, RoutedEventArgs e)
        {
            if (list == null)
            {
                list = GetDefaultList();

            }
            //LoadBarcodeData();
            this.DataContext = list;
        }
    }
}
