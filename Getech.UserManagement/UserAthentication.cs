using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Windows;

namespace Getech.UserManagement
{
    public class UserAthentication
    {
        public static int CurrentuserLevel=0;
        public static string CurrentuserName = "";
        public static int Login()
        {
            FormLogin form = new FormLogin();
            form.ShowDialog();
            CurrentuserLevel = form.iUserLevel;
            CurrentuserName = form.iCurrentUserName;
            return form.iUserLevel;
        }

        public static int Logout()
        {
            return 0;//default operator level
        }

        public static void ManageUser()
        {
            FormManageUsers form = new FormManageUsers();
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
        static string path = @"C:/GAL/System/User List.bin";

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
                fstream = new FileStream(path, FileMode.Open, FileAccess.Read);
                dictUsers = (Dictionary<string, User>)formatter.Deserialize(fstream);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (fstream != null)
                    fstream.Close();
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
    }
}
