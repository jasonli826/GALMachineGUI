using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace GALNewGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private StringBuilder logBuilder = new StringBuilder();
        private Thread logThread;
        private bool keepRunning = true;
        public ObservableCollection<string> LogEntries { get; set; } = new ObservableCollection<string>();
        public MainWindow()
        {
            InitializeComponent();
            StartLoggingThread();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {



        }
        private void MenuEditProduct_Click(object sender, RoutedEventArgs e)
        {
            var EditProductWindow = new GALNewGUI.Product.EditProduct(); // Use the correct namespace if needed
            EditProductWindow.Owner = this;
            EditProductWindow.ShowDialog(); // Or use Show() if you don’t want modal

        }
        private void menuManageUser_Click(object sender, RoutedEventArgs e)
        {
            var manageUserWindow = new GALNewGUI.UserManagement.ManageUser(); // Use the correct namespace if needed
            manageUserWindow.Owner = this;
            manageUserWindow.ShowDialog(); // Or use Show() if you don’t want modal

        }
        private void menuUserMgmt_Click(object sender, RoutedEventArgs e)
        {
            var loginWindow = new GALNewGUI.UserManagement.Login(); // Use the correct namespace if needed
            loginWindow.Owner = this;
            loginWindow.ShowDialog(); // Or use Show() if you don’t want modal
        }
        private void StartLoggingThread()
        {
            logThread = new Thread(() =>
            {
                while (keepRunning)
                {
                    string logEntry = $"{DateTime.Now:HH:mm:ss.fff}> " +
                                      "InitEpsonSoftware exAn error occurred trying to start process " +
                                      "'C:\\EpsonRC70\\exe\\erc70.exe' with working directory " +
                                      "'D:\\Project\\Projects\\MachineGUI\\GAL MACHINE GUI 3\\GAL MACHINE GUI\\GAL MACHINE GUI 4\\GAL MACHINE GUI\\GAL\\GAL\\bin\\Debug\\net8.0-windows7.0'. " +
                                      "The system cannot find the file specified.\n" +
                                      $"{DateTime.Now:HH:mm:ss.fff}> Application started\n" +
                                      $"{DateTime.Now:HH:mm:ss.fff}> Getech Automatic Loader  -  Version: 1.0.0.1\n" +
                                      $"{DateTime.Now:HH:mm:ss.fff}> Exception in COM open: Could not find file 'COM1'.";

                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        textboxLog.Text = logEntry + "\n" + textboxLog.Text; // Append new log at the top
                        textboxLog.CaretIndex = 0;  // Move caret to the start
                        textboxLog.ScrollToHome();  // Ensure scrollbar stays at the top
                    });

                    Thread.Sleep(5000);
                }
            });

            logThread.IsBackground = true;
            logThread.Start();
        }


    }
}
