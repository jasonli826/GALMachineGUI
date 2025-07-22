using System;
using System.Collections.Generic;
using System.IO;
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
using Getech.IO;
using MachineNewGUI.Entity;
using RobotController;


namespace MachineNewGUI
{
    /// <summary>
    /// Interaction logic for ErrorMessageWindow.xaml
    /// </summary>
    public partial class ErrorMessageWindow : Window
    {
        public int iOperatorResponse; //For ReplyType=1, GUI make sure RespNum>0: RespNum = 1 -> YES button click, RespNum = 2 -> NO button click
        public EpsonRobotController robotController_Loader;
        public RobotError rbtError;
        public bool bCloseValid = false;
        public string ErrorDescriptionPath = MainWindow.ErrorDescriptionPath;
        public bool IsManualLoadButtonClicked = false;
        
        public ErrorMessageWindow(RobotError robotError, EpsonRobotController epsonRbt_Loader)
        {
            try
            {
                InitializeComponent();
                textblockErrorCode.Text = robotError.ErrorCode.ToString();
                textboxErrorMessage.Text = robotError.ErrorMsg;
                robotController_Loader = epsonRbt_Loader;
               
                rbtError = robotError;
                textboxErrorDescription.Visibility = Visibility.Visible;

                //Find if error description exists
                string Error_Description = Read_ErrorDescription(robotError.ErrorCode.ToString());
                if(Error_Description != null && Error_Description != "")
                {
                    textboxErrorDescription.Text = Error_Description;
                   // textboxErrorDescription.Visibility = Visibility.Visible;
                }

                //Special case
                //If ErrorCode is 28 (The tray pocket is empty, the pallet is not full), we need to add a manual load button to send stopproduction to controller. Then they will trigger another alarm for us to load parts manually into pallet.
                if(robotError.ErrorCode == 28)
                {
                    buttonManualLoad.Visibility = Visibility.Visible;
                }

                if (robotError.ErrorCode == 29)
                {
                    buttonRetry.Content = "OK";
                }

                if (robotError.ErrorCode == 30)
                {
                    buttonManualLoad.Visibility = Visibility.Visible;
                    buttonManualLoad.Content = "STOP";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception in ErrorMessageWindow: " + ex.Message);
            }
        }

        private string Read_ErrorDescription(string errorcode)
        {
            try
            {
                string errorDescription = "";
                if (!File.Exists(ErrorDescriptionPath))
                {
                    return "";
                }
                else
                {
                    using (FileStream fs = new FileStream(ErrorDescriptionPath, FileMode.Open, FileAccess.Read))
                    {
                        using (StreamReader sr = new StreamReader(fs))
                        {
                            while (!sr.EndOfStream)
                            {
                                string txt = sr.ReadLine();
                                string[] error1 = txt.Split(',');
                                if (error1.Length < 2)
                                    continue;
                                if (error1[0].Trim() == errorcode.Trim())
                                {
                                    for (int i = 1; i <= error1.Length - 1; i++)
                                    {
                                        if (errorDescription != "")
                                            errorDescription += ", ";
                                        errorDescription += error1[i].Trim();

                                        //Replace \\r\\n into \r\n
                                        errorDescription = errorDescription.Replace("\\r\\n", "\r\n");
                                    }
                                    return errorDescription;
                                }
                            }
                            sr.Close();
                            return "";
                        }
                        
                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "";
            }
        }

        private void buttonRetry_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                iOperatorResponse = 1;
             
                if (robotController_Loader.IsConnected)
                {
                    robotController_Loader.ReplyErrorResponse2Robot(rbtError.ErrId, 0, 1);
                }
                
                bCloseValid = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception in Error Retry: " + ex.Message);
            }
        }

        private void buttonSkip_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                iOperatorResponse = 2;
                if (robotController_Loader.IsConnected)
                {
                    robotController_Loader.ReplyErrorResponse2Robot(rbtError.ErrId, 0, 2);
                }

                bCloseValid = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception in Error Skip: " + ex.Message);
            }
        }

        private void buttonSkip_Loaded(object sender, RoutedEventArgs e)
        {
            if (rbtError.ReplyType == 1)
                buttonSkip.Visibility = System.Windows.Visibility.Visible;
            else
                buttonSkip.Visibility = System.Windows.Visibility.Hidden;
        }

        private void buttonBuzzerOff_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (robotController_Loader.IsConnected)
                {
                    robotController_Loader.SendCmd2Robot(0, 0, RobotCommandConst.VOffBuzzer);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception in Error Buzzer Off: " + ex.Message);
            }
        }

        private void buttonManualLoad_Click(object sender, RoutedEventArgs e)
        {
            //Send stop production to controller
            try
            {
                if (robotController_Loader.IsConnected)
                {
                    robotController_Loader.SendCmd2Robot(0, 0, RobotCommandConst.VStopProduction);

                    if(rbtError.ErrorCode == 28)
                        Log.WriteToFile("Manual Loading is triggered. StopProduction sent to robot");
                    else if(rbtError.ErrorCode == 30)
                        Log.WriteToFile("STOP is triggered. StopProduction sent to robot");

                    Thread.Sleep(100);
                    robotController_Loader.ReplyErrorResponse2Robot(rbtError.ErrId, 0, 1);
                    IsManualLoadButtonClicked = true;
                }
                bCloseValid = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception in Error Manual Load: " + ex.Message);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(!bCloseValid)
                e.Cancel = true;//To prevent a window from closing, you can set the Cancel property of the CancelEventArgs argument to true.
        }

        
    }
}
