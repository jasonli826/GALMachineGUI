using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace GAL
{
    class OutputTrayTracker
    {
        static string strCurrentBatchFolder = @"C:/GAL/Current Batch/";
        static string strPreviousBatchFolder = @"C:/GAL/Previous Batch/";
        static public string LastError;

        static public bool SaveTray(string serial)
        {
            LastError = String.Empty;
            //validation
            if (serial.Length == 0)
            {
                LastError = String.Format("Argument empty");
                return false;
            }

            string strPath = strCurrentBatchFolder + serial + ".txt";

            //create folder
            if (!Directory.Exists(System.IO.Path.GetDirectoryName(strPath)))
                Directory.CreateDirectory(System.IO.Path.GetDirectoryName(strPath));

            //save 
            try
            {
                File.Create(strPath);
                return true;
            }
            catch (Exception ex)
            {
                LastError = String.Format("Exception creating tray {0} file:  {1}", serial, ex.Message);
                return false;
            }
        }

        static public bool IsTrayAlreadyUsedInCurrentBatch(string serial)
        {
            LastError = String.Empty;
            if (Directory.Exists(System.IO.Path.GetDirectoryName(strCurrentBatchFolder)))
            {
                string strPath = strCurrentBatchFolder + serial + ".txt";
                if (File.Exists(strPath))
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }

        static public bool IsTrayFromPreviousBatch(string serial)
        {
            LastError = String.Empty;
            if (Directory.Exists(System.IO.Path.GetDirectoryName(strPreviousBatchFolder)))
            {
                string strPath = strPreviousBatchFolder + serial + ".txt";
                if (File.Exists(strPath))
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }

        static public bool ChangeBatch()
        {
            LastError = String.Empty;
            try
            {
                if (Directory.Exists(System.IO.Path.GetDirectoryName(strPreviousBatchFolder)))
                    Directory.Delete(strPreviousBatchFolder, true);
                
                if (Directory.Exists(System.IO.Path.GetDirectoryName(strCurrentBatchFolder)))
                    Directory.Move(strCurrentBatchFolder, strPreviousBatchFolder);
                
                return true;
            }
            catch(Exception ex)
            {
                LastError = String.Format("Exception BatchEnd() :  {0}", ex.Message);
                return false;
            }
        }
    }
}
