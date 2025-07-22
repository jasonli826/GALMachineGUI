using MachineNewGUI.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace MachineNewGUI
{
    /// <summary>
    /// Interaction logic for ProgressWindow.xaml
    /// </summary>
    public partial class ProgressWindow : Window
    {
        //ProductParameters productParameters;
        //Thread pcThread;
        public ProgressWindow(ProductParameters ProductParameters)
        {
            //productParameters = ProductParameters;
            InitializeComponent();
            //StackBar.DataContext = productParameters;

            //pcThread = new Thread(CPUThread);
            //pcThread.Start();

        }

        public ProgressWindow()
        {
            //productParameters = ProductParameters;
            InitializeComponent();
            //StackBar.DataContext = productParameters;

            //pcThread = new Thread(CPUThread);
            //pcThread.Start();

        }

        //public void CPUThread()
        //{
        //    int i = 0; ;
        //    while (i < 1)
        //    {
        //        this.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
        //        (ThreadStart)delegate()
        //        {
        //            TxtBlock.Text = productParameters.ProgressInfo;
        //            if (productParameters.ProgressInfo == "Downloading Servo Point")
        //            {
        //                i = 2;
        //            }
        //        });
        //        System.Threading.Thread.Sleep(100);
        //    }
        //}

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            //if (pcThread != null)
            //    pcThread.Abort();
        }

    }
}
