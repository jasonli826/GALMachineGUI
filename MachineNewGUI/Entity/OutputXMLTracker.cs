using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GAL
{
    class OutBoundXMLTracker
    {     
       
        private static string strFileNameWExtension = @".xml";

        public static void MoveOutBoundXml(string strHostReadFolder, string strOutboundBackupFolder, string strPreviousFileName)
        {
            if (!Directory.Exists(strHostReadFolder))
            {
                Directory.CreateDirectory(strHostReadFolder);
            }

            if (!Directory.Exists(strOutboundBackupFolder))
            {
                Directory.CreateDirectory(strOutboundBackupFolder);
            }


            FileInfo fi1 = new FileInfo(strHostReadFolder + strPreviousFileName + strFileNameWExtension);

            if (fi1.Exists)
            {
                string FileNameTimeStamp = strPreviousFileName + "-" + DateTime.Now.ToString("HHmmss") + strFileNameWExtension;
                fi1.MoveTo(strOutboundBackupFolder + FileNameTimeStamp);
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
