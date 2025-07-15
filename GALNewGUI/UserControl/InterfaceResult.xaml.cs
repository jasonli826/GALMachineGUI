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
    /// Interaction logic for InterfaceResult.xaml
    /// </summary>
    public partial class InterfaceResult : UserControl
    {
        private string Name = string.Empty;
        private ProductViewHierarchy.Entity.InterfaceResult interfaceResult = null;
        private string SavePath = "interfaceresult";
        public InterfaceResult()
        {
            InitializeComponent();
            for (int i = 0; i <= 10; i++)
            {
                cmbListForSendParameter.Items.Add(i);

            }
    
            LoadInterfaceResultData();
            this.DataContext = interfaceResult;

        }
        public InterfaceResult(string name)
        {
            InitializeComponent();
            Name = name;
            for (int i = 0; i <= 10; i++)
            {
                cmbListForSendParameter.Items.Add(i);

            }

            LoadInterfaceResultData();
            this.DataContext = interfaceResult;

        }
        private void LoadInterfaceResultData()
        {
            try
            {
                if (string.IsNullOrEmpty(Name)) 
                    SavePath = SavePath + ".json";
                else
                    SavePath = SavePath + "_"+Name+".json";
                if (File.Exists(SavePath))
                {
                    var json = File.ReadAllText(SavePath);
                    interfaceResult = JsonConvert.DeserializeObject<Entity.InterfaceResult>(json);
                }

                if (interfaceResult == null)
                {
                    interfaceResult = GetDefaultOInterfaceResult();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load Failed: " + ex.Message);
                interfaceResult = GetDefaultOInterfaceResult();
            }

            // ✅ Attach change event so every update triggers Save
            interfaceResult.PropertyChanged += (_, __) => SaveInterfaceResultData();
        }
        private Entity.InterfaceResult GetDefaultOInterfaceResult()
        {
            return new Entity.InterfaceResult("COM::RouterBarcode_Dll.Barcode", "InterfaceResult", "0|B116680A", false, 0, false, false, false);
        }
        private void SaveInterfaceResultData()
        {
            try
            {
                var json = JsonConvert.SerializeObject(interfaceResult);
                File.WriteAllText(SavePath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Save Failed: " + ex.Message);
            }
        }
        public Entity.InterfaceResult GetCurrentInterfaceResult()
        {
            return interfaceResult;
        }
        private void InterfaceResult_Load(object sender, RoutedEventArgs e)
        {
            if (interfaceResult == null)
            {
                interfaceResult = new Entity.InterfaceResult("COM::RouterBarcode_Dll.Barcodet", "InterfaceResult", "0|B116680A", false, 0, false, false, false);

            }
            this.DataContext = interfaceResult;
        }
    }
}
