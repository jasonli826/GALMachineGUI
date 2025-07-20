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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Getech.UserManagement
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class FormLogin : Window
    {
        private List<string> listUserNames = new List<string>();
        private Dictionary<string, User> dictUser;
        public int iUserLevel = 0;
        public string iCurrentUserName = "";

        public FormLogin()
        {
            InitializeComponent();

            //load users from file here
            dictUser = UserStream.GetUsers();
            foreach (KeyValuePair<string, User> u in dictUser)
            {
                listUserNames.Add(u.Key);
            }
            comboboxUser.ItemsSource = listUserNames;
        }

        private void buttonLogin_Click(object sender, RoutedEventArgs e)
        {
            LoginCheck();
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            iUserLevel = -1;
            this.Close();
        }

        private void passwordBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                LoginCheck();
            }
        }

        void LoginCheck()
        {
            //validation
            if (comboboxUser.SelectedItem == null)
                iUserLevel = -1;

            //check password
            string user = (string)comboboxUser.SelectedItem;
            if (dictUser[user].Password == passwordBox.Password)
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

       
    }
}
