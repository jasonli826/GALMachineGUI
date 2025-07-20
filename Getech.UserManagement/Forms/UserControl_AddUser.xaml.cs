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
    /// Interaction logic for UserControl_AddUser.xaml
    /// </summary>
    public partial class UserControl_AddUser : UserControl
    {
        public UserControl_AddUser()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (textboxName.Text.Length < 1)
                return;
            Dictionary<string, User> dictUsers = UserStream.GetUsers();
            try
            {
                dictUsers.Add(textboxName.Text, new User(textboxName.Text, textboxPwd.Text, comboboxLevel.SelectedIndex));
            }
            catch(Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message);
            }
            finally
            {
                UserStream.SaveUsers(dictUsers);
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            comboboxLevel.Items.Clear();
            comboboxLevel.Items.Add("Operator");
            comboboxLevel.Items.Add("Technician");
            comboboxLevel.Items.Add("Engineer");
            comboboxLevel.Items.Add("Service");

            if (UserAthentication.CurrentuserLevel < 3)
            {
                comboboxLevel.Items.RemoveAt(3);
            }
            textboxName.Text = String.Empty;
            textboxPwd.Text = String.Empty;
            comboboxLevel.SelectedIndex = -1;
        }
    }
}
