using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Getech.GS.RobotController
{    
    public class ErrorListStream
    {
        string strPath = @"C:/GAL/system/ErrList.inc";
 
        public void LoadFromFile(out Dictionary<int, string> dict)
        {
            dict = new Dictionary<int, string>();
            using (FileStream fs = new FileStream(strPath, FileMode.OpenOrCreate))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    string str = String.Empty;
                    int key;

                    while (!sr.EndOfStream)
                    {
                        str = sr.ReadLine();
                        string[] strArray = str.Split(' ');//str.Split('=');
                        if (strArray.Length < 3 || !strArray[0].Equals("#define"))
                            continue;
                        if(int.TryParse(strArray[2].Trim(), out key))
                        {
                            try
                            {
                                dict.Add(key, strArray[1].Trim());
                            }
                            catch(Exception ex)
                            {
                                MessageBox.Show("Exception in loading ErrList.inc: @key "+ key.ToString() + ex.Message);
                            }
                        }                        
                    }
                }
            }
        }
    }
}
