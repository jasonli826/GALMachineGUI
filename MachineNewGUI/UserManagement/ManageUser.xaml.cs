using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MachineNewGUI.UserManagement
{
    /// <summary>
    /// Interaction logic for ManageUser.xaml
    /// </summary>
    public partial class ManageUser : Window
    {
        Dictionary<string, User> dictUsers = null;
        private List<string> listUserNames = new List<string>();
        public ManageUser()
        {
            InitializeComponent();
            Update_ComboboxName();
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            string strName = (string)cmbUserForDelete.SelectedItem;
            try
            {
                if (strName == UserAuthentication.CurrentuserName)
                {
                    MessageBox.Show("You are not allowed to delete your account");
                }
                else
                {
                    dictUsers.Remove(strName);
                }
                MessageBox.Show("Delete User Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message);
            }
            finally
            {
          
                UserStream.SaveUsers(dictUsers);
                Update_ComboboxName();
            }
        }
        void Update_ComboboxName()
        {
            dictUsers = UserStream.GetUsers();
            listUserNames.Clear();

            foreach (var u in dictUsers)
            {
                listUserNames.Add(u.Key);
            }

            cmbUserForDelete.ItemsSource = null; // Force refresh
            cmbUserForDelete.ItemsSource = listUserNames;
            cmbUserForDelete.SelectedIndex = 0; // Option
            cmbUserForPasswordChange.ItemsSource = null;
            cmbUserForPasswordChange.ItemsSource = listUserNames;
            cmbUserForPasswordChange.SelectedIndex = 0; // Option

        }
        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            string UserName = txtboxName.Text.Trim();
            string Password = txtPassword.Password;
            if (UserName.Length < 1)
            {
                MessageBox.Show("UserName cannot be empty");
                return;
            }
            dictUsers = UserStream.GetUsers();
            Dictionary<string, User> dictUserList = null;
            try
            {
                dictUserList = dictUsers;
                // Convert all keys to uppercase
                dictUserList = dictUserList.ToDictionary(
                    kvp => kvp.Key.ToUpperInvariant(),
                    kvp => kvp.Value
                );
                if (dictUserList.ContainsKey(UserName.ToUpper()))
                {
                    MessageBox.Show("This UserName Has been Used And Please Type Another one ");
                    return;
                }
                dictUsers.Add(UserName, new User(UserName, Password, comboboxLevel.SelectedIndex));
                MessageBox.Show("Add New User Successfully");
                txtboxName.Text = string.Empty;
                txtPassword.Password = string.Empty;
                comboboxLevel.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message);
            }
            finally
            {
                UserStream.SaveUsers(dictUsers);
                Update_ComboboxName();
            }
        }
        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (cmbUserForPasswordChange.SelectedIndex == -1)
            {
                MessageBox.Show("Please Select UserName.");
                return;

            }
            if (textboxPwd.Password.Length <= 0)
            {
                MessageBox.Show("Please enter password and retry.");
                return;
            }

            dictUsers[(string)cmbUserForPasswordChange.SelectedItem].Password = textboxPwd.Password;
            UserStream.SaveUsers(dictUsers);
            MessageBox.Show("Change Password Successfully");
            Update_ComboboxName();
        }
    }
}
