using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GALNewGUI.Entity
{
    public class Line : INotifyPropertyChanged
    {
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
        private double xStart;
        public double X_Start
        {
            get => xStart;
            set
            {
                if (xStart != value)
                {
                    xStart = value;
                    OnPropertyChanged(nameof(X_Start));
                }
            }
        }

        private double xEnd;
        public double X_End
        {
            get => xEnd;
            set
            {
                if (xEnd != value)
                {
                    xEnd = value;
                    OnPropertyChanged(nameof(X_End));
                }
            }
        }

        private double yStart;
        public double Y_Start
        {
            get => yStart;
            set
            {
                if (yStart != value)
                {
                    yStart = value;
                    OnPropertyChanged(nameof(Y_Start));
                }
            }
        }

        private double yEnd;
        public double Y_End
        {
            get => yEnd;
            set
            {
                if (yEnd != value)
                {
                    yEnd = value;
                    OnPropertyChanged(nameof(Y_End));
                }
            }
        }

        private double z;
        public double Z
        {
            get => z;
            set
            {
                if (z != value)
                {
                    z = value;
                    OnPropertyChanged(nameof(Z));
                }
            }
        }

        private double u;
        public double U
        {
            get => u;
            set
            {
                if (u != value)
                {
                    u = value;
                    OnPropertyChanged(nameof(U));
                }
            }
        }

        private double approach;
        public double Approach
        {
            get => approach;
            set
            {
                if (approach != value)
                {
                    approach = value;
                    OnPropertyChanged(nameof(Approach));
                }
            }
        }

        private string toolCompensation;
        public string ToolCompensation
        {
            get => toolCompensation;
            set
            {
                if (toolCompensation != value)
                {
                    toolCompensation = value;
                    OnPropertyChanged(nameof(ToolCompensation));
                }
            }
        }
        private string zpostonext;
        public string ZPosToNext
        {
            get => zpostonext;
            set
            {
                if (zpostonext != value)
                {
                    zpostonext = value;
                    OnPropertyChanged(nameof(ZPosToNext));
                }
            }
        }
        private bool? isSkip;
        public bool? IsSkip
        {
            get => isSkip;
            set
            {
                if (isSkip != value)
                {
                    isSkip = value;
                    OnPropertyChanged(nameof(IsSkip));
                }
            }
        }
        public Line() { }

        public Line(string description, double xstart, double xend, double ystart, double yend, double z, double u, double apporach, string compension, string zpositionToNext, bool isSkip)
        {
            Description = description;
            X_Start = xstart;
            X_End = xend;
            Y_Start = ystart;
            Y_End = yend;
            Z = z;
            U = u;
            Approach = apporach;
            ToolCompensation = compension;
            ZPosToNext = zpositionToNext;
            IsSkip = isSkip;


        }
    }
}
