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
    /// Interaction logic for InterfaceResult.xaml
    /// </summary>
    public partial class InterfaceResult : UserControl
    {
        private string InferfaceName = string.Empty;
        public Entity.InterfaceResult interfaceResult = null;
        private string SavePath = "interfaceresult";
        public event Action<Entity.InterfaceResult> InterfaceResultUpdate;
        public InterfaceResult()
        {
            InitializeComponent();
            for (int i = 0; i <= 2; i++)
            {
                cmbListForSendParameter.Items.Add(i);

            }
    
           //adInterfaceResultD Loata();
           // this.DataContext = interfaceResult;

        }
        public InterfaceResult(string name,int num)
        {
            InitializeComponent();
            InferfaceName = name;
            for (int i = 0; i <= 2; i++)
            {
                cmbListForSendParameter.Items.Add(i);

            }

            LoadInterfaceResultData(num);
            this.DataContext = interfaceResult;

        }
        private void LoadInterfaceResultData(int i)
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

                if (!string.IsNullOrEmpty(InferfaceName))
                    SavePath = table + SavePath + "_" + InferfaceName + ".json";
                else
                    SavePath = table + SavePath + ".json";
                if (File.Exists(SavePath))
                {
                    var json = File.ReadAllText(SavePath);
                    interfaceResult = JsonSerializer.Deserialize<Entity.InterfaceResult>(json);
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
                var json = JsonSerializer.Serialize(interfaceResult, new JsonSerializerOptions
                {
                    WriteIndented = true
                });
                File.WriteAllText(SavePath, json);
                InterfaceResultUpdate?.Invoke(interfaceResult);
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
