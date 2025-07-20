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

namespace MachineNewGUI.Controls
{
    /// <summary>
    /// Interaction logic for Pallet.xaml
    /// </summary>
    public partial class Pallet : UserControl
    {
        public MachineNewGUI.Entity.Pallet pallet = null;
        private string SavePath = "pallet";
        private string PalletName = string.Empty;
        public Pallet(string name,int num)
        {
            InitializeComponent();
            for (int i = 1; i <= 6; i++)
            {
                cmbRow.Items.Add(i);

            }
            cmbRow.SelectedValue = 4;
            for (int i = 2; i <= 6; i++)
            {
                cmbColumn.Items.Add(i);

            }
            cmbColumn.SelectedValue = 2;
            PalletName = name;
            LoadPalletData(num);
        }

        private void LoadPalletData(int num)
        {
            try
            {
                string table = string.Empty;
                if (num == 1)
                {
                    table = "LEFT_";
                }
                else
                    table = "RIGHT_";

                if (!string.IsNullOrEmpty(PalletName))
                    SavePath = table + SavePath + "_" + PalletName + ".json";
                else
                    SavePath = table + SavePath + ".json";
                if (File.Exists(SavePath))
                {
                    var json = File.ReadAllText(SavePath);
                    pallet = JsonConvert.DeserializeObject<MachineNewGUI.Entity.Pallet>(json);
                }

                if (pallet == null)
                {
                    pallet = GetDefaultPallet();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load Failure: " + ex.Message);
                pallet = GetDefaultPallet();
            }

            // ✅ Attach change event so every update triggers Save
            pallet.PropertyChanged += (_, __) => SavePalletData();
        }

        private MachineNewGUI.Entity.Pallet GetDefaultPallet()
        {
            return new MachineNewGUI.Entity.Pallet(4,2, -208.01, 51.05, -48.95,50.90, -208.01,50.05,false);
        }
        private void SavePalletData()
        {
            try
            {
                if (pallet != null)
                {
                    var json = JsonConvert.SerializeObject(pallet);
                    File.WriteAllText(SavePath, json);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Save Failure: " + ex.Message);
            }
        }
        private void Pallet_Loaded(object sender, RoutedEventArgs e)
        {
            if (pallet == null)
            {
                pallet = GetDefaultPallet();

            }

            this.DataContext = pallet;
        }
    }
}
