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

namespace MachineNewGUI.Entity
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

        public Barcode(string desc,double x1,double y1,double z1,double u1) 
        {
            Description = desc;
            X = x1;
            Y = y1;
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
