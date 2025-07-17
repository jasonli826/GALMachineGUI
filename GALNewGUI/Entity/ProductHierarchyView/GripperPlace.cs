using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GALNewGUI.Entity
{
    public class GripperPlace:INotifyPropertyChanged
    {
        public GripperPlace() { }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
           PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


        private string description;
        public string Description
        {
            get => description;
            set
            {
                if (description != value)
                {
                    description = value;
                    OnPropertyChanged(nameof(Description));
                }
            }
        }
        private double placeorientation;
        public double PlaceOrientation
        {
            get => placeorientation;
            set
            {
                if (placeorientation != value)
                {
                    placeorientation = value;
                    OnPropertyChanged(nameof(PlaceOrientation));
                }
            }
        }
        private double placezoffset;
        public double PlaceZOffset
        {
            get => placezoffset;
            set
            {
                if (placezoffset != value)
                {
                    placezoffset = value;
                    OnPropertyChanged(nameof(PlaceZOffset));
                }
            }
        }
        private double gripperopenoffset;
        public double GripperOpenOffset
        {
            get => gripperopenoffset;
            set
            {
                if (gripperopenoffset != value)
                {
                    gripperopenoffset = value;
                    OnPropertyChanged(nameof(GripperOpenOffset));
                }
            }
        }
        private int traypocket;
        public int TrayPocket
        {
            get => traypocket;
            set
            {
                if (traypocket != value)
                {
                    traypocket = value;
                    OnPropertyChanged(nameof(TrayPocket));
                }
            }
        }
        private bool? placetooutput2;
        public bool? PlaceOutput2
        {
            get => placetooutput2;
            set
            {
                if (placetooutput2 != value)
                {
                    placetooutput2 = value;
                    OnPropertyChanged(nameof(PlaceOutput2));
                }
            }
        }
        private bool? dustblow;
        public bool? DustBlow
        {
            get => dustblow;
            set
            {
                if (dustblow != value)
                {
                    dustblow = value;
                    OnPropertyChanged(nameof(DustBlow));
                }
            }
        }
        private bool? extraaction;
        public bool? ExtraAction
        {
            get => extraaction;
            set
            {
                if (extraaction != value)
                {
                    extraaction = value;
                    OnPropertyChanged(nameof(ExtraAction));
                }
            }
        }
        private bool? ejectboardafterplace;
        public bool? EjectBoardAfterPlace
        {
            get => ejectboardafterplace;
            set
            {
                if (ejectboardafterplace != value)
                {
                    ejectboardafterplace = value;
                    OnPropertyChanged(nameof(EjectBoardAfterPlace));
                }
            }
        }
        private bool? usepostvision;
        public bool? UsePostVision
        {
            get => usepostvision;
            set
            {
                if (usepostvision != value)
                {
                    usepostvision = value;
                    OnPropertyChanged(nameof(UsePostVision));
                }
            }
        }
        private bool? reverse;
        public bool? Reverse
        {
            get => reverse;
            set
            {
                if (reverse != value)
                {
                    reverse = value;
                    OnPropertyChanged(nameof(Reverse));
                }
            }
        }
        public GripperPlace(string description,double placeOrientation, double placeZOffset,double gripperOpenOffset,int trayPocket,bool? placeOutput2 = null,bool? dustBlow = null, bool? extraAction = null,bool? ejectBoardAfterPlace = null, bool? usePostVision = null,bool? reverse = null)
        {
            Description = description;
            PlaceOrientation = placeOrientation;
            PlaceZOffset = placeZOffset;
            GripperOpenOffset = gripperOpenOffset;
            TrayPocket = trayPocket;
            PlaceOutput2 = placeOutput2;
            DustBlow = dustBlow;
            ExtraAction = extraAction;
            EjectBoardAfterPlace = ejectBoardAfterPlace;
            UsePostVision = usePostVision;
            Reverse = reverse;
        }

    }
}
