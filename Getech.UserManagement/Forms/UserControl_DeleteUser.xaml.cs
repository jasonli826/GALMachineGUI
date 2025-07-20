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
    /// Interaction logic for UserControl_DeleteUser.xaml
    /// </summary>
    public partial class UserControl_DeleteUser : UserControl
    {
        Dictionary<string, User> dictUsers = null;

        public UserControl_DeleteUser()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            dictUsers = UserStream.GetUsers();
            Update_ComboboxName();           
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            string strName = (string)comboboxName.SelectedItem;
            try
            {
                if (strName == UserAthentication.CurrentuserName)
                {
                    MessageBox.Show("You are not allowed to delete your account");
                }
                else
                {
                    dictUsers.Remove(strName);
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message);
            }
            finally
            {
                Update_ComboboxName();
                UserStream.SaveUsers(dictUsers);
            }
        }  
        
        void Update_ComboboxName()
        {
            if (dictUsers == null)
                return;
            while(comboboxName.Items.Count > 0)
            {
                comboboxName.Items.RemoveAt(0);
            }

            foreach (KeyValuePair<string, User> kv in dictUsers)
            {
                if ((kv.Value.Level == 4) || (kv.Value.Level > UserAthentication.CurrentuserLevel))
                    continue;
                comboboxName.Items.Add(kv.Key);
            } 
        }
    }
}
