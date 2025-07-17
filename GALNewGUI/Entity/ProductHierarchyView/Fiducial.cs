using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GALNewGUI.Entity
{
    public class Fiducial : INotifyPropertyChanged
    {
        public Fiducial() { }
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
        private double x;
        public double X
        {
            get => x;
            set
            {
                if (x != value)
                {
                    x = value;
                    OnPropertyChanged(nameof(X));
                }
            }
        }

        private double y;
        public double Y
        {
            get => y;
            set
            {
                if (y != value)
                {
                    y = value;
                    OnPropertyChanged(nameof(Y));
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
        private double xsize;
        public double XSize
        {
            get => xsize;
            set
            {
                if (xsize != value)
                {
                    xsize = value;
                    OnPropertyChanged(nameof(XSize));
                }
            }
        }

        private double ysize;
        public double YSize
        {
            get => ysize;
            set
            {
                if (ysize != value)
                {
                    ysize = value;
                    OnPropertyChanged(nameof(YSize));
                }
            }
        }


        private double errTol;
        public double ErrTol
        {
            get => errTol;
            set
            {
                if (errTol != value)
                {
                    errTol = value;
                    OnPropertyChanged(nameof(ErrTol));
                }
            }
        }

        private double posTol;
        public double PosTol
        {
            get => posTol;
            set
            {
                if (posTol != value)
                {
                    posTol = value;
                    OnPropertyChanged(nameof(PosTol));
                }
            }
        }


        private string type;
        public string Type
        {
            get => type;
            set
            {
                if (type != value)
                {
                    type = value;
                    OnPropertyChanged(nameof(Type));
                }
            }
        }
        private int maxthr;
        public int MaxThr
        {
            get => maxthr;
            set
            {
                if (maxthr != value)
                {
                    maxthr = value;
                    OnPropertyChanged(nameof(MaxThr));
                }
            }
        }
        private bool? isBadMark;
        public bool? IsBadMark
        {
            get => isBadMark;
            set
            {
                if (isBadMark != value)
                {
                    isBadMark = value;
                    OnPropertyChanged(nameof(isBadMark));
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
        public Fiducial(string description,double x,double y,double z,double u,double xsize,double ysize,double errTol,double posTol,string type,int maxThr,bool? isBadMark = null,bool? isSkip = null)
        {
            Description = description;
            X = x;
            Y = y;
            Z = z;
            U = u;
            XSize = xsize;
            YSize = ysize;
            ErrTol = errTol;
            PosTol = posTol;
            Type = type;
            MaxThr = maxThr;
            IsBadMark = isBadMark;
            IsSkip = isSkip;
        }

        public void SaveFiducialData(string filePath, Entity.Fiducial fiducial)
        {
            try
            {
                if (File.Exists(filePath))
                    File.Delete(filePath);

                 var json = JsonConvert.SerializeObject(fiducial);
    
                File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Save Failed: " + ex.Message);
            }
        }
    }
}
