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

namespace GALNewGUI.Controls
{
    /// <summary>
    /// Interaction logic for Line.xaml
    /// </summary>
    public partial class Line : UserControl
    {
        public Entity.Line line = null;
        private string SavePath = "line";
        private string LineName = string.Empty;
        public Line()
        {
            InitializeComponent();
        }
        public Line(string name,int i)
        {

            InitializeComponent();
            LineName = name;
            LoadLineData(i);
            cmbToolCompensation.Items.Add("LEFT");
            cmbToolCompensation.Items.Add("NONE");
            cmbToolCompensation.Items.Add("RIGHT");
            cmbZPosToNext.Items.Add("Default");
            cmbZPosToNext.Items.Add("Custom1");
            cmbZPosToNext.Items.Add("Custom2");
        }

        private void LoadLineData(int i)
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

                if (!string.IsNullOrEmpty(LineName))
                    SavePath = table + SavePath + "_" + LineName + ".json";
                else
                    SavePath = table + SavePath + ".json";
                if (File.Exists(SavePath))
                {
                    var json = File.ReadAllText(SavePath);
                    line = JsonConvert.DeserializeObject<Entity.Line>(json);
                }

                if (line == null)
                {
                    line = GetDefaultLine();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load Failure: " + ex.Message);
                line = GetDefaultLine();
            }

            // ✅ Attach change event so every update triggers Save
            line.PropertyChanged += (_, __) => SaveLineData();
        }

        private Entity.Line GetDefaultLine()
        {
            return new Entity.Line(Name, -196.96, -196.96, 77.61, 77.61,11,11,0, "LEFT", "Default", false);
        }
        private void SaveLineData()
        {
            try
            {
                if (line != null)
                {
                    var json = JsonConvert.SerializeObject(line);
                    File.WriteAllText(SavePath, json);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Save Failure: " + ex.Message);
            }
        }
        private void Line_Loaded(object sender, RoutedEventArgs e)
        {
            if (line == null)
            {
                line = GetDefaultLine();

            }
        
            this.DataContext = line;
            if (string.IsNullOrEmpty(txtDescription.Text.Trim()))
                txtDescription.Text = LineName;
        }

    }
}
