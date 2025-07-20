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

namespace MachineNewGUI.Utilities
{
    /// <summary>
    /// Interaction logic for MannualUtilities.xaml
    /// </summary>
    public partial class MannualUtilities : Window
    {
        public MannualUtilities()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            #region POPULATING COMBOBOX (INPUT)
            List<int> listInputTrayRows = new List<int>();
            List<int> listInputTrayCols = new List<int>();
            for (int i = 1; i <= 4; i++)
            {
                listInputTrayRows.Add(i);
            }
            for (int i = 1; i <= 2; i++)
            {
                listInputTrayCols.Add(i);
            }
            comboBoxShuttlePalletCol.ItemsSource = listInputTrayCols;
            comboBoxShuttlePalletRow.ItemsSource = listInputTrayRows;
            #endregion

            #region POPULATING COMBOBOX (OUTPUT)
            List<int> listOutputTrayRows = new List<int>();
            List<int> listOutputTrayCols = new List<int>();
            for (int i = 1; i <= 4; i++)
            {
                listOutputTrayRows.Add(i);
            }
            for (int i = 1; i <= 2; i++)
            {
                listOutputTrayCols.Add(i);
            }
            comboBoxOutputPalletCol.ItemsSource = listOutputTrayCols;
            comboBoxOutputPalletRow.ItemsSource = listOutputTrayRows;
            #endregion

            #region FLUSH INPUT TRAY
            Rectangle[,] rectFlushTrayArray = new Rectangle[4,2];
            double dSsdColPitch = canvasInTray.Width / 2;
            double dSsdRowPitch = canvasInTray.Height / 4;
            double dSsdWidth = dSsdColPitch * 0.6;
            double dSsdHeight = dSsdRowPitch * 0.6;
            for (int r = 0; r < 4; r++)
            {
                for (int c = 0; c < 2; c++)
                {
                    rectFlushTrayArray[r, c] = new Rectangle() { Width = dSsdWidth, Height = dSsdHeight, Fill = Brushes.Green };
                    canvasInTray.Children.Add(rectFlushTrayArray[r, c]);
                    Canvas.SetLeft(rectFlushTrayArray[r, c], dSsdColPitch / 2 + (dSsdColPitch * c) - dSsdWidth / 2);
                    Canvas.SetTop(rectFlushTrayArray[r, c], dSsdRowPitch / 2 + (dSsdRowPitch * r) - dSsdHeight / 2);
                }
            }
            Canvas.SetZIndex(polygonInTray, 1);//bring to top. to enable mouse down event catch         
            #endregion

            #region FLUSH OUTPUT PALLET
            Rectangle[,] rectFlushPalletArray = new Rectangle[6, 2];
            double dPalletColPitch = canvasOutTray.Width /2;
            double dPalletRowPitch = canvasOutTray.Height / 6;
            double dPalletWidth = dPalletColPitch * 0.6;
            double dPalletHeight = dPalletRowPitch * 0.6;
            for (int r = 0; r < 6; r++)
            {
                for (int c = 0; c < 2; c++)
                {
                    rectFlushPalletArray[r, c] = new Rectangle() { Width = dPalletWidth, Height = dPalletHeight, Fill = Brushes.SteelBlue };
                    canvasOutTray.Children.Add(rectFlushPalletArray[r, c]);
                    Canvas.SetLeft(rectFlushPalletArray[r, c], dPalletColPitch / 2 + (dPalletColPitch * c) - dPalletWidth / 2);
                    Canvas.SetTop(rectFlushPalletArray[r, c], dPalletRowPitch / 2 + (dPalletRowPitch * r) - dPalletHeight / 2);
                }
            }
            Canvas.SetZIndex(polygonOutTray, 1);//bring to top. to enable mouse down event catch         
            #endregion
        }
        private void buttonFlip0_Click(object sender, RoutedEventArgs e)
        { 
        
        
        }
        private void buttonFlip90_Click(object sender, RoutedEventArgs e)
        {


        }
        private void buttonInputMove2Bcd_Click(object sender, RoutedEventArgs e)
        {


        }
        private void buttonInputTrayBcd_Click(object sender, RoutedEventArgs e)
        {


        }
        private void buttonOutPalletMoveToBcd_Click(object sender, RoutedEventArgs e)
        {


        }
        private void buttonJumptoZero_Click(object sender, RoutedEventArgs e)
        {


        }
        private void buttonCleartip1_Click(object sender, RoutedEventArgs e)
        {


        }
        private void buttonLoaderAxis_Click(object sender, RoutedEventArgs e)
        {


        }
        private void buttonFixedScanner_Click(object sender, RoutedEventArgs e)
        { 
        
        }
        private void buttonRbtEFScanner_Click(object sender, RoutedEventArgs e)
        { 
        
        }
        private void buttonInputTrayPick_Click(object sender, RoutedEventArgs e)
        { 
        
        
        }

        private void buttonInputTraytMove_Click(object sender, RoutedEventArgs e)
        {


        }
        private void buttonLoadTray_Click(object sender, RoutedEventArgs e)
        { 
        
        }
        private void buttonUnloadTray_Click(object sender, RoutedEventArgs e)
        {

        }
        private void buttonLoadPos_Click(object sender, RoutedEventArgs e)
        {

        }
        private void buttonPickPos_Click(object sender, RoutedEventArgs e)
        {

        }
        private void buttonUnLoadPos_Click(object sender, RoutedEventArgs e)
        {

        }
        private void polygonInTray_MouseLeftButtonDown(object sender, RoutedEventArgs e)
        { 
        
        
        }
        private void buttonOutPalletMove_Click(object sender, RoutedEventArgs e)
        { 
        
        
        }
        private void polygonOutputPallet_MouseLeftButtonDown(object sender, RoutedEventArgs e)
        {


        }
        private void buttonOutPalletPlace_Click(object sender, RoutedEventArgs e)
        {


        }
        private void buttonSpotCheck_Click(object sender, RoutedEventArgs e)
        { 
        
        
        }
        private void buttonOutPalletSend_Click(object sender, RoutedEventArgs e)
        {


        }
        private void buttonOutPalletReceive_Click(object sender, RoutedEventArgs e)
        { 
        
        
        }
    }
}
