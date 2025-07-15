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
    /// Interaction logic for Fiducial.xaml
    /// </summary>
    public partial class Fiducial : UserControl
    {
        public ProductViewHierarchy.Entity.Fiducial fiducial = null;
        private string SavePath = "fiducial";
        private string Name = string.Empty;
        public Fiducial()
        {
            InitializeComponent();
        }
        public Fiducial(string name)
        {
            InitializeComponent();
            txtFiducial.Text = name;
            Name = name;
            LoadFiducialData();
            cmbType.Items.Add("Circle");
            cmbType.Items.Add("Square");

        }
        private void LoadFiducialData()
        {
            try
            {
                if (!string.IsNullOrEmpty(Name))
                    SavePath = SavePath + "_" + Name + ".json";
                else
                    SavePath = SavePath + ".json";
                if (File.Exists(SavePath))
                {
                    string json = File.ReadAllText(SavePath);
                    fiducial = JsonConvert.DeserializeObject<Entity.Fiducial>(json);
                }

                if (fiducial == null)
                {
                    fiducial = GetDefaultFiducial();
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
            return new Entity.Fiducial(Name,0,0,1,1,0.2,2.2,"Circle",23,false,false);
        }
        private void SaveFiducialData()
        {
            try
            {
                var json = JsonConvert.SerializeObject(fiducial);
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
