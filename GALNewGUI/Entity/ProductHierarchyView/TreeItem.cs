using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace GALNewGUI.Entity
{
    public class TreeItem : INotifyPropertyChanged
    {
        public TreeItem() { }
        public Entity.Barcode BarcodeData { get; set; }
        public Entity.InterfaceResult InterfaceResultData { get; set; }

        public Entity.List List { get; set; }
        public Entity.Pallet Pallet { get; set; }

        public Entity.Fiducial Fiducial { get; set; }
        public Entity.Line Line { get; set; }

        public Entity.GripperPlace GripperPlace { get; set; }

        private string _type;
        public string Type
        {
            get => _type;
            set
            {
                if (_type != value)
                {
                    _type = value;
                    OnPropertyChanged(nameof(Type));
                    // OnPropertyChanged(nameof(IconPath)); // Optional: Refresh icon if name change affects it
                }
            }
        }
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                    // OnPropertyChanged(nameof(IconPath)); // Optional: Refresh icon if name change affects it
                }
            }
        }

        public ObservableCollection<TreeItem> Children { get; set; } = new ObservableCollection<TreeItem>();

        public TreeItem(string name,string type)
        {
            Name = name;
            Type = type;
        }


        public string IconPath
        {
            get
            {
                if (Name.ToUpper().StartsWith("LINE"))
                    return "../Images/line.png";
                if (Name.ToUpper().StartsWith("PALLET"))
                    return "../Images/pallet.png";
                if (Name.ToUpper().StartsWith("LIST"))
                    return "../Images/list.png";
                if (Name.ToUpper().StartsWith("BARCODE")||Name.ToUpper().Contains("BARCODE"))
                    return "../Images/barcode.png";
                if (Name.ToUpper().StartsWith("FIDUCIAL"))
                    return "../Images/fiducial.png";
                if (Name.ToUpper().StartsWith("INTERFACERESULT"))
                    return "../Images/interface.png";
                if (Name.ToUpper().StartsWith("TABLE"))
                    return "../Images/table.png";
                if (Name.ToUpper().StartsWith("GRIPPERPLACE"))
                    return "../Images/gripperplace.png";
                

                return "../Images/line.png"; // fallback icon
            }
        }
        public TreeItem DeepClone()
        {
            var clone = new TreeItem
            {
                Name = this.Name,
                Type = this.Type,
                BarcodeData = this.BarcodeData, // Or .Clone() if needed
                InterfaceResultData = this.InterfaceResultData,
                List = this.List,
                Pallet = this.Pallet,
                Fiducial = this.Fiducial,
                Line = this.Line,
                GripperPlace = this.GripperPlace,
                Children = new ObservableCollection<TreeItem>(this.Children.Select(c => c.DeepClone()))
            };

            return clone;
        }
        // ✅ Only one declaration of INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
}
