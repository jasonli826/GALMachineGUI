using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GALNewGUI.Entity
{
    public class RightTable : ICloneable
    {
        public RightTable() { }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
        public RightTable ShallowCopy()
        {
            return (RightTable)this.MemberwiseClone();

        }
        public ObservableCollection<TreeItem> Items { get; set; }
    }
}
