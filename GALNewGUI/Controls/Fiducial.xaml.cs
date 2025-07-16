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
    /// Interaction logic for Fiducial.xaml
    /// </summary>
    public partial class Fiducial : UserControl
    {
        public Entity.Fiducial fiducial = null;
        private string SavePath = "fiducial";
        private string FiducialName = string.Empty;
        public Fiducial()
        {
            InitializeComponent();
        }
        public Fiducial(string name,int i)
        {
            InitializeComponent();
            txtFiducial.Text = name;
            FiducialName = name;
            LoadFiducialData(i);
            cmbType.Items.Add("Circle");
            cmbType.Items.Add("Square");

        }
        private void LoadFiducialData(int i)
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

                if (!string.IsNullOrEmpty(FiducialName))
                    SavePath =table+SavePath + "_" + FiducialName + ".json";
                else
                    SavePath = table+SavePath + ".json";
                if (File.Exists(SavePath))
                {
                    var json = File.ReadAllText(SavePath);
                    fiducial = JsonSerializer.Deserialize<Entity.Fiducial>(json);
                }

                if (fiducial == null)
                {
                    fiducial = GetDefaultFiducial();
                    //var json = JsonSerializer.Serialize<Entity.Fiducial>(fiducial);
                    ////File.WriteAllText(SavePath, json);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load Failure: " + ex.Message);
                fiducial = GetDefaultFiducial();
            }

            // ✅ Attach change event so every update triggers Save
            fiducial.PropertyChanged += (_, __) => SaveFiducialData();
        }

        private Entity.Fiducial GetDefaultFiducial()
        {
            return new Entity.Fiducial(FiducialName, 0, 0, 1, 1, 0.2, 2.2, 2,3,"Circle", 23, false, false);
        }
        private void SaveFiducialData()
        {
            try
            {
                var json = JsonSerializer.Serialize(fiducial, new JsonSerializerOptions
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

        private void Fiducial_Loaded(object sender, RoutedEventArgs e)
        {
            if (fiducial == null)
            {
                fiducial = GetDefaultFiducial();

            }
            //LoadBarcodeData();
            this.DataContext = fiducial;
        }
    }
}
