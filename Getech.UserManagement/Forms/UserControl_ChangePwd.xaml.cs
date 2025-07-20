using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Getech.UserManagement
{
    /// <summary>
    /// Interaction logic for UserControl_ChangePwd.xaml
    /// </summary>
    public partial class UserControl_ChangePwd : UserControl
    {
        Dictionary<string, User> dictUsers = null;

        public UserControl_ChangePwd()
        {
            InitializeComponent();            
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            dictUsers = UserStream.GetUsers();
            while(comboboxName.Items.Count != 0)
            {
                comboboxName.Items.RemoveAt(0);
            }
            
            foreach (KeyValuePair<string, User> kv in dictUsers)
            {
                if ((kv.Value.Level == 4) || (kv.Value.Level > UserAthentication.CurrentuserLevel))
                    continue;
                comboboxName.Items.Add(kv.Key);
            }

            comboboxName.SelectedIndex = -1;
            textboxPwd.Text = String.Empty;
        }

        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (textboxPwd.Text.Length <= 0)
            {
                MessageBox.Show("Please enter password and retry.");
                return;
            }
                
            dictUsers[(string)comboboxName.SelectedItem].Password = textboxPwd.Text;
            UserStream.SaveUsers(dictUsers);
        }

        private void comboboxName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboboxName.SelectedIndex < 0)
                return;
        }        
    }
}
