using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
using static GALNewGUI.Utilities.IOUtility;

namespace GALNewGUI.Utilities
{
    /// <summary>
    /// Interaction logic for IOUtility.xaml
    /// </summary>
    public partial class IOUtility : Window
    {
        #region PARAMETERS

        private String IOPath;
        private System.Windows.Threading.DispatcherTimer TimerClock;
        private int TimeInterval = 200;
        private const int InputsPerPage = 16;
        private const int OutputsPerPage = 16;
        private const int MaxPage = 20;
        private static int CurrentInputPage = 0;
        private static int CurrentOutputPage = 0;
        private int TotalInputPage = 0;
        private int TotalOutputPage = 0;
        private static InputLabel[][] InputList;
        private static OutputCheckBox[][] OutputList;
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        //public IOUtility()
        //{
        //    InitializeComponent();
        //}
        public IOUtility()
        {
            this.InitializeComponent();

            string IOPath = AppDomain.CurrentDomain.BaseDirectory + @"\System\IO.sys";

            int CurrentInputPage = 0;
            int  CurrentOutputPage = 0;


            if (LoadIOList(IOPath) == false)
            {
                MessageBox.Show("Failed to load I/O file\n" + IOPath);
                return;
            }

            DisplayInput(CurrentInputPage);
            DisplayOutput(CurrentOutputPage);
            //TimerClock = new System.Windows.Threading.DispatcherTimer();
            //TimerClock.Interval = new TimeSpan(0, 0, 0, 0, TimeInterval);
            //TimerClock.Tick += new EventHandler(TimerClock_Tick);

        }
        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        { 
        
        
        }
        private void btnReturn_Click(object sender, RoutedEventArgs e)
        { 
        
        }
        private void Bt_LeftIn_Click(object sender, RoutedEventArgs e)
        { 
        
        
        }
        private void Bt_RightIn_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Bt_LeftOut_Click(object sender, RoutedEventArgs e)
        {


        }
        private void Bt_RightOut_Click(object sender, RoutedEventArgs e)
        {


        }

        public class InputLabel : Label
        {
            public short InputID = 0;
            private StackPanel sp;
            private Rectangle rect;
            private Label lb;

            public InputLabel(short id, string InputName)
            {
                sp = new StackPanel();
                sp.Orientation = Orientation.Horizontal;
                rect = new Rectangle();
                lb = new Label();
                rect.Height = 16;
                rect.Width = 16;
                rect.Fill = new LinearGradientBrush(Colors.LightGray, Colors.White, 0);
                rect.Stroke = Brushes.DarkBlue;
                rect.RadiusX = 1;
                rect.RadiusY = 1;
                sp.Children.Add(rect);
                lb.Content = InputName;
                lb.FontSize = 14;
                lb.Foreground = Brushes.Black;
                lb.Width = 500;
                sp.Children.Add(lb);
                this.Content = sp;
                this.VerticalAlignment = VerticalAlignment.Center;
                this.HorizontalAlignment = HorizontalAlignment.Left;
                InputID = id;
            }
            public void InputOn(bool Ion)
            {
                if (Ion == true)
                {
                    rect.Fill = new LinearGradientBrush(Colors.DarkRed, Colors.LightPink, 0);
                    lb.Foreground = Brushes.Brown;
                    lb.FontWeight = FontWeights.Bold;
                }
                else
                {
                    rect.Fill = new LinearGradientBrush(Colors.LightGray, Colors.White, 0);
                    lb.Foreground = Brushes.Black;
                    lb.FontWeight = FontWeights.Normal;
                }
            }
        }

        public class OutputCheckBox : CheckBox
        {
            public short OutputID = 0;

            public OutputCheckBox(short id, string name)
            {
                this.Margin = new Thickness(16);
                this.Content = name;
                this.FontSize = 14;
                this.Click += new RoutedEventHandler(OutputCheckBox_Click);
                this.VerticalAlignment = VerticalAlignment.Center;
                this.HorizontalAlignment = HorizontalAlignment.Left;
                OutputID = id;
                this.IsChecked = false;
            }
            public void OutputIsOn(bool IsOn)
            {
                if (IsOn == true)
                {
                    this.IsChecked = false;
                    this.Foreground = Brushes.DarkCyan;
                    this.FontWeight = FontWeights.Bold;
                }
                else if (IsOn == false)
                {
                    this.IsChecked = false;
                    this.Foreground = Brushes.Black;
                    this.FontWeight = FontWeights.Normal;
                }
            }
            void OutputCheckBox_Click(object sender, RoutedEventArgs e)
            {
                if (this.IsChecked == true)
                {
                    this.Foreground = Brushes.DarkCyan;
                    this.FontWeight = FontWeights.Bold;
                    try
                    {
                      //  MyController.Set_Output(OutputID, true);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }
                }
                else
                {
                    this.Foreground = Brushes.Black;
                    this.FontWeight = FontWeights.Normal;
                    try
                    {
                     //   MyController.Set_Output(OutputID, false);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }
                }
                try
                {
                    refreshIO();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private static void refreshIO()
        {
            RefreshIn();
            RefreshOut();
        }

        private static void RefreshIn()
        {
            short InNo = 0;
            bool IsOn = true;
            //MyController.ClearRefreshedInputNode();
            for (int i = 0; i < InputsPerPage; i++)
            {
                if (InputList[CurrentInputPage][i] != null)
                {
                    InNo = InputList[CurrentInputPage][i].InputID;

                  //  IsOn = MyController.ReadRefreshedInput(InNo);

                    InputList[CurrentInputPage][i].InputOn(IsOn);

                }
                else
                {
                    break;
                }
            }
        }

        private static void RefreshOut()
        {
            short OutNo = 0;
            bool IsOn = true;
           // MyController.ClearRefreshedOutputNode();
            for (int i = 0; i < OutputsPerPage; i++)
            {
                if (OutputList[CurrentOutputPage][i] != null)
                {
                    OutNo = OutputList[CurrentOutputPage][i].OutputID;

                    //IsOn = MyController.ReadRefreshedOutput(OutNo);

                    OutputList[CurrentOutputPage][i].OutputIsOn(IsOn);
                }
                else
                {
                    break;
                }
            }
        }
        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            //TimerClock.IsEnabled = false;
        }
        private bool LoadIOList(string path)
        {
            StreamReader srd;
            try
            {
                srd = new StreamReader(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

            string IOInfo;
            int InorOut = 0;

            InputList = new InputLabel[MaxPage][];
            InputList[0] = new InputLabel[InputsPerPage];
            OutputList = new OutputCheckBox[MaxPage][];
            OutputList[0] = new OutputCheckBox[OutputsPerPage];

            int InItemNo = 0;
            int OutItemNo = 0;

            short InID = 0;
            short OutID = 0;

            int Line = 0;

            bool isEnabled = true;

            while (srd.EndOfStream == false)
            {
                IOInfo = srd.ReadLine();
                Line++;
                if (IOInfo.Contains("#Input"))
                {
                    InorOut = 0;
                }
                else if (IOInfo.Contains("#Output"))
                {
                    InorOut = 1;
                }
                else if (IOInfo.Contains(@"//") || IOInfo.Contains(@"\\"))
                {
                }
                else if (IOInfo.Contains(","))
                {
                    //save IO info
                    if (InorOut == 0)
                    {
                        String[] InInfo = IOInfo.Split(',');
                        String InNo = InInfo[0];
                        while (InNo.Length < 3)
                        {
                            InNo = "0" + InNo;
                        }
                        InNo = InNo + " - ";
                        try
                        {
                            InID = Convert.ToInt16(InInfo[0]);
                        }
                        catch
                        {
                            MessageBox.Show("Invalid File Format at Line " + Convert.ToString(Line));
                        }
                        if (InItemNo >= InputsPerPage)
                        {
                            InItemNo = 0;
                            TotalInputPage++;
                            InputList[TotalInputPage] = new InputLabel[InputsPerPage];
                        }

                        InputList[TotalInputPage][InItemNo] = new InputLabel(InID, InNo + IOInfo.Substring(InInfo[0].Length + 1).Trim());
                        InItemNo++;
                    }
                    else if (InorOut == 1)
                    {
                        if (IOInfo[0] == '~')
                        {
                            IOInfo = IOInfo.Substring(1);
                            isEnabled = false;
                        }
                        String[] OutInfo = IOInfo.Split(',');
                        String OutNo = OutInfo[0];
                        while (OutNo.Length < 3)
                        {
                            OutNo = "0" + OutNo;
                        }
                        OutNo = OutNo + " - ";
                        if (OutInfo[0].Contains("Relay"))
                        {
                            OutID = 999;
                        }
                        else
                        {
                            try
                            {
                                OutID = Convert.ToInt16(OutInfo[0]);
                            }
                            catch
                            {
                                MessageBox.Show("Invalid File Format at Line " + Convert.ToString(Line));
                            }
                        }
                        if (OutItemNo >= OutputsPerPage)
                        {
                            OutItemNo = 0;
                            TotalOutputPage++;
                            OutputList[TotalOutputPage] = new OutputCheckBox[OutputsPerPage];
                        }

                        OutputList[TotalOutputPage][OutItemNo] = new OutputCheckBox(OutID, OutNo + IOInfo.Substring(OutInfo[0].Length + 1).Trim());
                        if (isEnabled == false)
                        {
                            isEnabled = true;
                            OutputList[TotalOutputPage][OutItemNo].IsEnabled = false;
                        }
                        OutItemNo++;
                    }
                    if (TotalInputPage > 0)
                    {
                        Bt_RightIn.IsEnabled = true;
                        Img_RightIn.Opacity = 1;
                    }
                    else
                    {
                        Bt_RightIn.IsEnabled = false;
                        Img_RightIn.Opacity = 0.1;
                    }

                    Bt_LeftIn.IsEnabled = false;
                    Img_LeftIn.Opacity = 0.1;

                    if (TotalOutputPage > 0)
                    {
                        Bt_RightOut.IsEnabled = true;
                        Img_RihtOut.Opacity = 1;
                    }
                    else
                    {
                        Bt_RightOut.IsEnabled = false;
                        Img_RihtOut.Opacity = 0.1;
                    }

                    Bt_LeftOut.IsEnabled = false;
                    Img_LeftOut.Opacity = 0.1;

                    UpdateInputTile();
                    UpdateOutputTile();
                }
            }
            return true;
        }
        private void DisplayInput(int PageNumber)
        {
            for (int i = 0; i < InputsPerPage; i++)
            {
                if (InputList[PageNumber][i] != null)
                {
                    InputPanel.Children.Add(InputList[PageNumber][i]);
                }
                else break;
            }
        }

        private void DisplayOutput(int PageNumber)
        {
            for (int i = 0; i < OutputsPerPage; i++)
            {
                if (OutputList[PageNumber][i] != null)
                {
                    OutputPanel.Children.Add(OutputList[PageNumber][i]);
                }
                else break;
            }
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                refreshIO();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
         //   TimerClock.IsEnabled = true;
        }
        private void UpdateInputTile()
        {
            InputTextBox.Text = "Input List (Page " + Convert.ToString(CurrentInputPage + 1) + @"/" + Convert.ToString(TotalInputPage + 1) + ")";
        }

        private void UpdateOutputTile()
        {
           OutputTextBox.Text = "Output List (Page " + Convert.ToString(CurrentOutputPage + 1) + @"/" + Convert.ToString(TotalOutputPage + 1) + ")";

        }
    }
}
