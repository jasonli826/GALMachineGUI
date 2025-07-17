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
    public class Pallet : INotifyPropertyChanged
    {
        public Pallet() { }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        private int row;
        public int Row
        {
            get => row;
            set
            {
                if (row != value)
                {
                    row = value;
                    OnPropertyChanged(nameof(Row));
                }
            }
        }

        private int column;

        public int Column
        {
            get => column;
            set
            {
                if (column != value)
                {
                    column = value;
                    OnPropertyChanged(nameof(Column));
                }
            }
        }
        private double pt1x;

        public double PT1X
        {
            get => pt1x;
            set
            {
                if (pt1x != value)
                {
                    pt1x = value;
                    OnPropertyChanged(nameof(PT1X));
                }
            }
        }
        private double pt1y;

        public double PT1Y
        {
            get => pt1y;
            set
            {
                if (pt1y != value)
                {
                    pt1y = value;
                    OnPropertyChanged(nameof(PT1Y));
                }
            }
        }

        private double pt2x;

        public double PT2X
        {
            get => pt2x;
            set
            {
                if (pt2x != value)
                {
                    pt2x = value;
                    OnPropertyChanged(nameof(PT2X));
                }
            }
        }
        private double pt2y;

        public double PT2Y
        {
            get => pt2y;
            set
            {
                if (pt2y != value)
                {
                    pt2y = value;
                    OnPropertyChanged(nameof(PT2Y));
                }
            }
        }

        private double pt3x;

        public double PT3X
        {
            get => pt2x;
            set
            {
                if (pt3x != value)
                {
                    pt3x = value;
                    OnPropertyChanged(nameof(PT3X));
                }
            }
        }
        private double pt3y;

        public double PT3Y
        {
            get => pt3y;
            set
            {
                if (pt3y != value)
                {
                    pt3y = value;
                    OnPropertyChanged(nameof(PT3Y));
                }
            }
        }

        private bool? isCustomPallet;
        public bool? IsCustomPallet
        {
            get => isCustomPallet;
            set
            {
                if (isCustomPallet != value)
                {
                    isCustomPallet = value;
                    OnPropertyChanged(nameof(IsCustomPallet));
                }
            }
        }
        public Pallet(int row, int column,
              double pt1x, double pt1y,
              double pt2x, double pt2y,
              double pt3x, double pt3y,
              bool? isCustomPallet = null)
        {
            Row = row;
            Column = column;
            PT1X = pt1x;
            PT1Y = pt1y;
            PT2X = pt2x;
            PT2Y = pt2y;
            PT3X = pt3x;
            PT3Y = pt3y;
            IsCustomPallet = isCustomPallet;
        }
        public void SavePalletData(string filePath, Entity.Pallet Pallet)
        {
            try
            {
                if (File.Exists(filePath))
                    File.Delete(filePath);

                var json = JsonConvert.SerializeObject(Pallet);
                File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Save Failed: " + ex.Message);
            }
        }
    }
}
