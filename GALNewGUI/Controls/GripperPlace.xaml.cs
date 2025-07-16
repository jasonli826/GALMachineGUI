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

namespace GALNewGUI.Controls
{
    /// <summary>
    /// Interaction logic for GripperPlace.xaml
    /// </summary>
    public partial class GripperPlace : UserControl
    {
        public Entity.GripperPlace gripper = null;
        private string SavePath = "gripperplace";
        private string GripperName = string.Empty;
        public GripperPlace()
        {
            InitializeComponent();
        }
        public GripperPlace(string name,int num)
        {
            InitializeComponent();
            txtDesc.Text = name;
            GripperName = name;
            for (int i = 1; i <= 4; i++)
            {
                cmbTray.Items.Add(i);

            }
            cmbTray.SelectedValue = 1;
            LoadGripperData(num);
        }
        private void LoadGripperData(int num)
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

                if (!string.IsNullOrEmpty(GripperName))
                    SavePath = table + SavePath + "_" + GripperName + ".json";
                else
                    SavePath = table + SavePath + ".json";
                if (File.Exists(SavePath))
                {
                    var json = File.ReadAllText(SavePath);
                    gripper = JsonConvert.DeserializeObject<Entity.GripperPlace>(json);
                }

                if (gripper == null)
                {
                    gripper = GetDefaultGripper();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load Failure: " + ex.Message);
                gripper = GetDefaultGripper();
            }

            // ✅ Attach change event so every update triggers Save
            gripper.PropertyChanged += (_, __) => SaveGripperData();
        }

        private Entity.GripperPlace GetDefaultGripper()
        {
            return new Entity.GripperPlace("Gripper Place 1",0,0,1,1,false,false,false,false,false,false);
        }
        private void SaveGripperData()
        {
            try
            {
                if (gripper != null)
                {
                    var json = JsonConvert.SerializeObject(gripper);
                    File.WriteAllText(SavePath, json);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Save Failure: " + ex.Message);
            }
        }
        private void GripperPlace_Loaded(object sender, RoutedEventArgs e)
        {
            if (gripper == null)
            {
                gripper = GetDefaultGripper();

            }

            this.DataContext = gripper;
        }
    }
}
