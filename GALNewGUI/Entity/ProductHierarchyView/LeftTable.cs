using MachineNewGUI.Entity;
using System.Collections.ObjectModel;
using System;
using System.Linq;

public class LeftTable : ICloneable
{
    public LeftTable() { }
    public ObservableCollection<TreeItem> Items { get; set; } = new ObservableCollection<TreeItem>();

    public object Clone()
    {
        var clone = (LeftTable)this.MemberwiseClone();

        // Deep clone the Items collection
        clone.Items = new ObservableCollection<TreeItem>(
            this.Items.Select(item => item.DeepClone())
        );

        return clone;
    }

    public LeftTable ShallowCopy()
    {
        return (LeftTable)this.MemberwiseClone();
    }
}
