using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Getech.IO;
namespace MachineNewGUI
{
    public class HIKScannerTCP
    {
        public TcpClient HIKSocketClient;
        bool tracelog;
        MachineConfiguration machineParameters;

        public string TCPIntialize(int ScannerPos, MachineConfiguration machine)
        {
            string IP = "";
            int Port = 3001;
            int TimeOut = 6000;
            bool TraceLog = true;
            string BarcodeData = "";
            machineParameters = machine;
            try
            {
                #region LMS
                switch (ScannerPos)
                {
                    case 1://SC1
                        {
                            #region "END EFFECTOR 1 SCANNER"                                      
                            IP = machineParameters.ComSetting.IP_SC1;
                            Port = machineParameters.ComSetting.Port_SC1;
                            break;

                            #endregion
                        }

                    case 2://SC2
                        {
                            #region "FIXED SCANNER" 
                            IP = machineParameters.ComSetting.IP_SC2;
                            Port = machineParameters.ComSetting.Port_SC2;
                            break;

                            #endregion
                        }
                }

                #endregion

                if (ConnectSocket(IP, Port, TimeOut, TraceLog))
                {
                    BarcodeData = SendMsg("start");
                }
                else
                {
                    // TCP SOCKET NOT ESTABLISHED.
                    // Log.WriteToFile(String.Format("TCP SOCKET CONNECTION NOT ESTABLISHED Exception:{0}", ex.Message));
                    BarcodeData = "";
                }
            }
            catch (Exception ex)
            {
                Log.WriteToFile(String.Format("TCPInitialize Exception:{0}", ex.Message));
                MessageBox.Show(String.Format("TCPInitialize Exception:{0}", ex.Message));
            }
            return BarcodeData;
        }

        public bool ConnectSocket(string IP, Int32 Port, int TimeOut, bool HasTracelog)
        {
            try
            {
                tracelog = HasTracelog;
                if (HIKSocketClient != null)
                {
                    HIKSocketClient.Close();
                    HIKSocketClient = null;
                }
            }
            catch (Exception ex)
            {
                Log.WriteToFile("TCPIP Connection Close Error: " + ex.ToString());
            }

            try
            {
                HIKSocketClient = new TcpClient();
                HIKSocketClient.Connect(IP, Port);
                HIKSocketClient.ReceiveTimeout = TimeOut;
                Log.WriteToFile(String.Format("IP Address{0},Port Number {1},TimeOut {2} and TCP IP  Connected", IP, Port, TimeOut));
            }
            catch (Exception ex)
            {

                Log.WriteToFile(String.Format("IP Address {0}, Port Number {1},TimeOut {2},Exception:{3}", IP, Port, TimeOut, ex.Message));
                throw new Exception("TCPIP connection Open Error : " + ex.Message);
            }
            return true;
        }

        public bool SocketDisconnect()
        {
            bool reply = false;
            try
            {
                if (HIKSocketClient != null)
                {
                    HIKSocketClient.Close();
                    HIKSocketClient = null;
                    reply = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error:102,TCPIP Connection Close Error:" + ex.Message);
                reply = false;
            }
            return reply;
        }


        public string SendMsg(string Msg)
        {
            Log.WriteToFile(String.Format("Data Send >> {0}", Msg));
            Byte[] data = System.Text.Encoding.ASCII.GetBytes(Msg);

            return SendData(data);
        }

        private string SendData(Byte[] datas)
        {
            string Retval = "";
            bool DataRead = true;
            try
            {
                NetworkStream stream = HIKSocketClient.GetStream();
                stream.Write(datas, 0, datas.Length);
                Thread.Sleep(20);
                StringBuilder sb = new StringBuilder();
                string text = "";
                while (DataRead)
                {
                    text = "";
                    Byte[] data = new Byte[2048];
                    stream.Read(data, 0, data.Length);
                    byte[] newarray = new byte[data.Length];
                    Buffer.BlockCopy(data, 0, newarray, 0, newarray.Length);

                    text = Encoding.ASCII.GetString(newarray).TrimEnd('\0');
                    sb.Append(text);

                    if (tracelog)
                    {
                        Log.WriteToTracelog(String.Format("DataReceived << {0}", text.TrimEnd('\0')));
                    }

                    string Content = string.Empty;
                    Content = sb.ToString();
                    //if (Content.IndexOf("<EOT>") > -1)
                    //{
                    //if (Content.ToLower().Contains(Barcode.ToString().ToLower()))
                    //{
                    DataRead = false;
                    Retval = Content;
                    Log.WriteToFile(String.Format("DataReceived << {0}", Content.TrimEnd('\0')));
                    //}
                    //else
                    //{
                    //    Log.WriteToFile(String.Format("Data ignored because actual Barcode was {0} but Received as {1}", Barcode.ToString(), para1.ToString()));
                    //    Thread.Sleep(500);
                    //}
                    //}
                }

                HIKSocketClient.Close();
            }
            catch (Exception ex)
            {
                DataRead = false;
                //Log.WriteToFile(String.Format("Data Send/Receive Exception: {0}", ex.Message));
                throw new Exception("Error:TCP ACK time out" + ex.Message);
            }
            return Retval;
        }
    }
}
