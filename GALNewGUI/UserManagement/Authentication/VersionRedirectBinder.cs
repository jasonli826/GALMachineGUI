using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MachineNewGUI.UserManagement.Authentication
{
    sealed class VersionRedirectBinder : SerializationBinder
    {
        public override Type BindToType(string assemblyName, string typeName)
        {
            // Redirect from the old Getech.UserManagement to the current assembly
            if (assemblyName.StartsWith("Getech.UserManagement"))
            {
                assemblyName = Assembly.GetExecutingAssembly().FullName;
            }

            return Type.GetType($"{typeName}, {assemblyName}");
        }
    }
}
