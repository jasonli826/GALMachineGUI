using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GALNewGUI.JsonEncryption
{
    public class JsonMechanism
    {
        public JsonMechanism() { }
        public string DecryptString(string encryptionString)
        {
            byte[] b;
            string decrypted;
            try
            {
                b = Convert.FromBase64String(encryptionString);
                decrypted = System.Text.ASCIIEncoding.ASCII.GetString(b);
            }
            catch (FormatException fe)
            {
                decrypted = "";
            }
            return decrypted;
        }

        public string EncryptionString(string strEncrypted)
        {
            byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(strEncrypted);
            string encrypted = Convert.ToBase64String(b);
            return encrypted;
        }
    }
}
