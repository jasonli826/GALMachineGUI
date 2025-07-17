using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GALNewGUI.Entity
{
    public  class Root:ICloneable
    {
        public ProductParameters ProductParameters { get; set; }

        public object Clone()
        {
            var clone = (Root)this.MemberwiseClone();



            return clone;
        }

 
    }
}
