using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Windows;
using System.Configuration;
using MachineNewGUI.UserManagement.Authentication;

namespace MachineNewGUI.UserManagement
{
    public class UserAuthentication
    {
        public static int CurrentuserLevel=0;
        public static string CurrentuserName = "";
        public static int Login()
        {
            MachineNewGUI.UserManagement.Login form = new MachineNewGUI.UserManagement.Login();
            form.ShowDialog();
            CurrentuserLevel = form.iUserLevel;
            CurrentuserName = form.iCurrentUserName;
            return form.iUserLevel;
        }
        public static void ManageUser()
        {
            ManageUser form = new ManageUser();
            form.ShowDialog();
        }
    }

    
    
    [Serializable]
    class User
    {
        public string Name{get; set;}
        public string Password { get; set; }
        public int Level { get; set; }

        public User(string name, string password, int level)
        {
            Name = name;
            Password = password;
            Level = level;//0 - operator, 1 - technician, 2 - engineer, 3 - service, 4 - developer
        }
    }

    class UserStream
    {
        private static string MachineGUIDirectroy = ConfigurationManager.AppSettings["Directory"].ToString();
        static string path = MachineGUIDirectroy+ @"\System\User List.bin";

        public static Dictionary<string, User> GetUsers()
        {
            Dictionary<string, User> dictUsers = new Dictionary<string, User>();
         
            //create folder
            if (!Directory.Exists(System.IO.Path.GetDirectoryName(path)))
            {
                Directory.CreateDirectory(System.IO.Path.GetDirectoryName(path));                
            }
            
            //save file if not exists
            if(!File.Exists(path))
            {
                dictUsers.Add("Developer", new User("Developer", "-1", 4));
                dictUsers.Add("Service", new User("Service", "1", 3));
                dictUsers.Add("Engineer", new User("Engineer", "engineer", 2));
                dictUsers.Add("Techician", new User("Technician", "technician", 1));
                dictUsers.Add("Operator", new User("Operator", "operator", 0));
                SaveUsers(dictUsers);
                return dictUsers;
            }
                
            //opens existing file
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fstream = null;
            try
            {
                using ( fstream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    formatter = new BinaryFormatter();
                    formatter.Binder = new VersionRedirectBinder(); // Add this line
                    dictUsers = (Dictionary<string, User>)formatter.Deserialize(fstream);
                }
            }
            catch (SerializationException ex)
            {
                MessageBox.Show("Corrupted user file. Regenerating default users.\n" + ex.Message);
                dictUsers = CreateDefaultUsers();
                SaveUsers(dictUsers);
            }
            return dictUsers;
        }

        public static void SaveUsers(Dictionary<string, User> dictUsers)
        {
            //create folder
            if (!Directory.Exists(System.IO.Path.GetDirectoryName(path)))
            {
                Directory.CreateDirectory(System.IO.Path.GetDirectoryName(path));
            }


            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fstream = null;

            try
            {
                fstream = new FileStream(path, FileMode.Create, FileAccess.Write);
                formatter.Serialize(fstream, dictUsers);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (fstream != null)
                    fstream.Close();
            }
        }
        private static Dictionary<string, User> CreateDefaultUsers()
        {
            return new Dictionary<string, User>
            {
                {"Developer", new User("Developer", "-1", 4)},
                {"Service", new User("Service", "1", 3)},
                {"Engineer", new User("Engineer", "engineer", 2)},
                {"Technician", new User("Technician", "technician", 1)},
                {"Operator", new User("Operator", "operator", 0)},
            };
        }
    }
}


