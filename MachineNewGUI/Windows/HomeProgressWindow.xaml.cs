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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MachineNewGUI
{
    /// <summary>
    /// Interaction logic for HomeProgressWindow.xaml
    /// </summary>
    public partial class HomeProgressWindow : Window
    {
        private Storyboard _storyboard;
        public HomeProgressWindow()
        {
            InitializeComponent();
            this.IsVisibleChanged += OnVisibleChanged;
        }

        private void OnVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (IsVisible)
            {
                StartAnimation();
            }
            else
            {
                StopAnimation();
            }
        }
        private void StartAnimation()
        {
            _storyboard = (Storyboard)FindResource("canvasAnimation");
            _storyboard.Begin(canvas, true);
        }
        private void StopAnimation()
        {
            _storyboard.Remove(canvas);
            //MainWindow.bHoming = false;
        }
    }
}
