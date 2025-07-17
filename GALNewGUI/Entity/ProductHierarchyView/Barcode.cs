using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media.Media3D;

namespace GALNewGUI.Entity
{
    public class Barcode: INotifyPropertyChanged
    {
        public Barcode() { }
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

        public Barcode(string desc,double xstart,double xend,double ystart,double yend,double z1,double u1) 
        {
            Description = desc;
            X_Start = xstart;
            X_End = xend;
            Y_Start = ystart;
            Y_End = yend;
            Z = z1;
            U = u1;
           
          }

        public void SaveBarcodeData(string filePath, Entity.Barcode Barcode)
        {
            try
            {
                if (File.Exists(filePath))
                    File.Delete(filePath);

                //var json = J(Barcode, new JsonSerializerOptions
                //{
                //    WriteIndented = true
                //});
                var json = JsonConvert.SerializeObject(Barcode);
                File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Save Failed: " + ex.Message);
            }
        }
    }
}
