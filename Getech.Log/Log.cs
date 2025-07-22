using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Getech.IO
{
    public class Log
    {
        private static string strFolder = @".\Log\GUILog";
        private static string strFileNameWExtension = @"\Log.txt";
        private static string strBackupFileNameWExtention = @"\Log1.txt";
        private static string strBackupFileNameWExtention2 = @"\Log2.txt";

        private static string strTraceFileNameWExtension = @"\HIKTCPTraceLog.txt";
        private static string strTraceBackupFileNameWExtention = @"\HIKTCPTraceLog1.txt";
        private static string strTraceBackupFileNameWExtention2 = @"\HIKTCPTraceLog2.txt";


        private static string strAlarmlogFileExtension = @"\AlarmLog.txt";
        private static string strAlarmlogFileWExtension = @"\AlarmLog1.txt";
        private static string strAlarmlogFileWExtension2 = @"\AlarmLog2.txt";

        private static string strRobotlogFileExtension = @"\RobotLog.txt";
        private static string strRobotlogFileWExtension = @"\RobotLog1.txt";
        private static string strRobotlogFileWExtension2 = @"\RobotLog2.txt";

        static public void WriteToFile(string strLine)
        {
            string FileDate = System.DateTime.Now.ToString("ddMMMyyyy");

            if (!Directory.Exists(strFolder + @"\" + FileDate))
            {
                DirectoryDelete(strFolder, 365);
                Directory.CreateDirectory(strFolder + @"\" + FileDate);
            }


            string strPath = strFolder + @"\" + FileDate + strFileNameWExtension;
            string strBackupPath = strFolder + @"\" + FileDate + strBackupFileNameWExtention;
            string strBackupPath2 = strFolder + @"\" + FileDate + strBackupFileNameWExtention2;

            FileInfo fi = new FileInfo(strPath);
            FileInfo fi1 = new FileInfo(strBackupPath);
            FileInfo fi2 = new FileInfo(strBackupPath2);

            if (fi.Exists)
            {
                if (fi.Length > 10742880)
                {
                    if (fi2.Exists)
                    {
                        fi2.Delete();
                    }

                    if (fi1.Exists)
                    {
                        fi1.MoveTo(strBackupPath2);
                    }

                    fi.MoveTo(strBackupPath);
                }
            }

            try
            {
                using (FileStream fs = new FileStream(strPath, FileMode.Append, FileAccess.Write))
                {
                    TextWriter writer = new StreamWriter(fs);
                    DateTime dt = DateTime.Now;
                    writer.WriteLine(DateTime.Now.ToString("dd-MM-yy, HH:mm:ss.fff> ") + strLine);
                    writer.Flush();
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                //
            }
        }

        static public void WriteToTracelog(string strLine)
        {
            string FileDate = System.DateTime.Now.ToString("ddMMMyyyy");

            if (!Directory.Exists(strFolder + @"\" + FileDate))
            {
                DirectoryDelete(strFolder, 365);
                Directory.CreateDirectory(strFolder + @"\" + FileDate);
            }


            string strPath = strFolder + @"\" + FileDate + strTraceFileNameWExtension;
            string strBackupPath = strFolder + @"\" + FileDate + strTraceBackupFileNameWExtention;
            string strBackupPath2 = strFolder + @"\" + FileDate + strTraceBackupFileNameWExtention2;

            FileInfo fi = new FileInfo(strPath);
            FileInfo fi1 = new FileInfo(strBackupPath);
            FileInfo fi2 = new FileInfo(strBackupPath2);

            if (fi.Exists)
            {
                if (fi.Length > 10742880)
                {
                    if (fi2.Exists)
                    {
                        fi2.Delete();
                    }

                    if (fi1.Exists)
                    {
                        fi1.MoveTo(strBackupPath2);
                    }

                    fi.MoveTo(strBackupPath);
                }
            }

            try
            {
                using (FileStream fs = new FileStream(strPath, FileMode.Append, FileAccess.Write))
                {
                    TextWriter writer = new StreamWriter(fs);
                    DateTime dt = DateTime.Now;
                    writer.WriteLine(DateTime.Now.ToString("dd-MM-yy, HH:mm:ss.fff> ") + strLine);
                    writer.Flush();
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                //
            }
        }

        static public void WriteToAlarmFile(string strLine)
        {
            string FileDate = System.DateTime.Now.ToString("ddMMMyyyy");

            if (!Directory.Exists(strFolder + @"\" + FileDate))
            {
                DirectoryDelete(strFolder, 365);
                Directory.CreateDirectory(strFolder + @"\" + FileDate);
            }

            string strPath = strFolder + @"\" + FileDate + strAlarmlogFileExtension;
            string strBackupPath = strFolder + @"\" + FileDate + strAlarmlogFileWExtension;
            string strBackupPath2 = strFolder + @"\" + FileDate + strAlarmlogFileWExtension2;

            FileInfo fi = new FileInfo(strPath);
            FileInfo fi1 = new FileInfo(strBackupPath);
            FileInfo fi2 = new FileInfo(strBackupPath2);
            if (fi.Exists)
            {
                if (fi.Length > 10742880)
                {
                    if (fi2.Exists)
                    {
                        fi2.Delete();
                    }

                    if (fi1.Exists)
                    {
                        fi1.MoveTo(strBackupPath2);
                    }

                    fi.MoveTo(strBackupPath);
                }
            }

            try
            {
                using (FileStream fs = new FileStream(strPath, FileMode.Append, FileAccess.Write))
                {
                    TextWriter writer = new StreamWriter(fs);
                    DateTime dt = DateTime.Now;
                    writer.WriteLine(DateTime.Now.ToString("dd-MM-yy, HH:mm:ss.fff> ") + strLine);
                    writer.Flush();
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                //
            }
        }

        static public void WriteToRobotFile(string strLine)
        {
            string FileDate = System.DateTime.Now.ToString("ddMMMyyyy");

            if (!Directory.Exists(strFolder + @"\" + FileDate))
            {
                DirectoryDelete(strFolder, 365);
                Directory.CreateDirectory(strFolder + @"\" + FileDate);
            }

            string strPath = strFolder + @"\" + FileDate + strRobotlogFileExtension;
            string strBackupPath = strFolder + @"\" + FileDate + strRobotlogFileWExtension;
            string strBackupPath2 = strFolder + @"\" + FileDate + strRobotlogFileWExtension2;

            FileInfo fi = new FileInfo(strPath);
            FileInfo fi1 = new FileInfo(strBackupPath);
            FileInfo fi2 = new FileInfo(strBackupPath2);
            if (fi.Exists)
            {
                if (fi.Length > 10742880)
                {
                    if (fi2.Exists)
                    {
                        fi2.Delete();
                    }

                    if (fi1.Exists)
                    {
                        fi1.MoveTo(strBackupPath2);
                    }

                    fi.MoveTo(strBackupPath);
                }
            }

            try
            {
                using (FileStream fs = new FileStream(strPath, FileMode.Append, FileAccess.Write))
                {
                    TextWriter writer = new StreamWriter(fs);
                    DateTime dt = DateTime.Now;
                    writer.WriteLine(DateTime.Now.ToString("dd-MM-yy, HH:mm:ss.fff> ") + strLine);
                    writer.Flush();
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                //
            }
        }

        public static void DirectoryDelete(string Path, int Days)
        {
            try
            {
                foreach (string file in Directory.GetDirectories(Path))
                {
                    DateTime fileDate = Directory.GetCreationTime(file);

                    if (Directory.GetCreationTime(file) < DateTime.Now.AddDays(-Days))
                    {
                        Directory.Delete(file, true);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
