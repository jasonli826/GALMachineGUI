using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GALNewGUI.Entity
{
    public class List : INotifyPropertyChanged
    {
        public List() { }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
           PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    
        private double xref1;
        public double XRef1
        {
            get => xref1;
            set
            {
                if (xref1 != value)
                {
                    xref1 = value;
                    OnPropertyChanged(nameof(XRef1));
                }
            }
        }
        private double yref1;
        public double YRef1
        {
            get => yref1;
            set
            {
                if (yref1 != value)
                {
                    yref1 = value;
                    OnPropertyChanged(nameof(YRef1));
                }
            }
        }
        private double xlocal1;
        public double XLocal1
        {
            get => xlocal1;
            set
            {
                if (xlocal1 != value)
                {
                    xlocal1 = value;
                    OnPropertyChanged(nameof(XLocal1));
                }
            }
        }
        private double ylocal1;
        public double YLocal1
        {
            get => ylocal1;
            set
            {
                if (ylocal1 != value)
                {
                    ylocal1 = value;
                    OnPropertyChanged(nameof(YLocal1));
                }
            }
        }

        private double xref2;
        public double XRef2
        {
            get => xref2;
            set
            {
                if (xref2 != value)
                {
                    xref2 = value;
                    OnPropertyChanged(nameof(XRef2));
                }
            }
        }
        private double yref2;
        public double YRef2
        {
            get => yref2;
            set
            {
                if (yref2 != value)
                {
                    yref2 = value;
                    OnPropertyChanged(nameof(YRef2));
                }
            }
        }
        private double xlocal2;
        public double XLocal2
        {
            get => xlocal2;
            set
            {
                if (xlocal2 != value)
                {
                    xlocal2 = value;
                    OnPropertyChanged(nameof(XLocal2));
                }
            }
        }
        private double ylocal2;
        public double YLocal2
        {
            get => ylocal2;
            set
            {
                if (ylocal2 != value)
                {
                    ylocal2 = value;
                    OnPropertyChanged(nameof(YLocal2));
                }
            }
        }
        private double zoffset;
        public double ZOffset
        {
            get => zoffset;
            set
            {
                if (zoffset != value)
                {
                    zoffset = value;
                    OnPropertyChanged(nameof(ZOffset));
                }
            }
        }
        private double feedrate;
        public double FeedRate
        {
            get => feedrate;
            set
            {
                if (feedrate != value)
                {
                    feedrate = value;
                    OnPropertyChanged(nameof(FeedRate));
                }
            }
        }
        private double gridzoffset;
        public double GridZOffset
        {
            get => gridzoffset;
            set
            {
                if (gridzoffset != value)
                {
                    gridzoffset = value;
                    OnPropertyChanged(nameof(GridZOffset));
                }
            }
        }
        public List(double xRef1,double yRef1,double xLocal1,double yLocal1,double xRef2,double yRef2,double xLocal2,double yLocal2,double zOffset,double feedRate,double gridZOffset)
        {
            XRef1 = xRef1;
            YRef1 = yRef1;
            XLocal1 = xLocal1;
            YLocal1 = yLocal1;
            XRef2 = xRef2;
            YRef2 = yRef2;
            XLocal2 = xLocal2;
            YLocal2 = yLocal2;
            ZOffset = zOffset;
            FeedRate = feedRate;
            GridZOffset = gridZOffset;
        }
    }
}
