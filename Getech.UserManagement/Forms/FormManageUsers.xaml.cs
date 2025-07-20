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
    /// Interaction logic for ManageUsers.xaml
    /// </summary>
    public partial class FormManageUsers : Window
    {
        UserControl_AddUser ucAddUser = new UserControl_AddUser();
        UserControl_DeleteUser ucDeleteUser = new UserControl_DeleteUser();
        UserControl_ChangePwd ucChangePwd = new UserControl_ChangePwd();
        
        public FormManageUsers()
        {
            InitializeComponent();
        }

        private void menuAddUser_Click(object sender, RoutedEventArgs e)
        {
            RemoveUserControls();           
            gridClientArea.Children.Add(ucAddUser);
        }

        private void menuDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            RemoveUserControls();
            gridClientArea.Children.Add(ucDeleteUser);
        }

        private void menuChangePwd_Click(object sender, RoutedEventArgs e)
        {
            RemoveUserControls();
            gridClientArea.Children.Add(ucChangePwd);
        }
        
        void RemoveUserControls()
        {
            while(gridClientArea.Children.Count > 0)
            {
                gridClientArea.Children.RemoveAt(0);
            }
        }                     
    }
}
