using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace MachineNewGUI.UserManagement
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private List<string> listUserNames = new List<string>();
        private Dictionary<string, User> dictUser;
        public int iUserLevel = 0;
        public string iCurrentUserName = "";
        public Login()
        {
            InitializeComponent();
            dictUser = UserStream.GetUsers();
            foreach (KeyValuePair<string, User> u in dictUser)
            {
                listUserNames.Add(u.Key);
            }
            UsernameBox.ItemsSource = listUserNames;
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            //validation
            if (UsernameBox.SelectedItem == null)
            {
                iUserLevel = -1;
                MessageBox.Show("Please Select Any User");
                return;
            }
            if (string.IsNullOrEmpty(PasswordBox.Password))
            { 

                MessageBox.Show("Please type the password");
                return;
            }
            //check password
            string user = (string)UsernameBox.SelectedItem;
            if (dictUser[user].Password == PasswordBox.Password)
            {//successful
                iUserLevel = dictUser[user].Level;
                iCurrentUserName = user;
                this.Close();
            }
            else//fail
            {
                MessageBox.Show("Password does not match.");
                iUserLevel = 0;
            }
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
