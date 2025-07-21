using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Getech.GS.RobotController
{
    public class RobotPoint : INotifyPropertyChanged
    {
        private uint _number;
        public uint PointNumber
        {
            get { return _number; }
            set
            {
                _number = value;
                OnPropertyChanged(new PropertyChangedEventArgs("PointNumber"));
            }
        }

        private string _name;
        public string PointName
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(new PropertyChangedEventArgs("PointName"));
            }
        }

        private double _x;
        public double X
        {
            get { return _x; }
            set
            {
                _x = value;
                OnPropertyChanged(new PropertyChangedEventArgs("X"));
            }
        }

        private double _y;
        public double Y
        {
            get { return _y; }
            set
            {
                _y = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Y"));
            }
        }

        private double _z;
        public double Z
        {
            get { return _z; }
            set
            {
                _z = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Z"));
            }
        }

        private double _u;
        public double U
        {
            get { return _u; }
            set
            {
                _u = value;
                OnPropertyChanged(new PropertyChangedEventArgs("U"));
            }
        }

        private double _v;
        public double V
        {
            get { return _v; }
            set
            {
                _v = value;
                OnPropertyChanged(new PropertyChangedEventArgs("V"));
            }
        }

        private double _w;
        public double W
        {
            get { return _w; }
            set
            {
                _w = value;
                OnPropertyChanged(new PropertyChangedEventArgs("W"));
            }
        }

        private bool _hand;
        public bool Hand
        {
            get { return _hand; }
            set
            {
                _hand = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Hand"));
            }
        }

        private bool _elbow;
        public bool Elbow
        {
            get { return _elbow; }
            set
            {
                _elbow = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Elbow"));
            }
        }
        
        private bool _wrist;
        public bool Wrist
        {
            get { return _wrist; }
            set
            {
                _wrist = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Wrist"));
            }
        }

        private double _zoffset;
        public double ZOffset
        {
            get { return _zoffset; }
            set
            {
                _zoffset = value;
                OnPropertyChanged(new PropertyChangedEventArgs("ZOffset"));
            }
        }

        private int _Local;
        public int Local
        {
            get { return _Local; }
            set
            {
                _Local = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Local"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }

        public RobotPoint()
        {
            _number = 0;
            _name = "0";
            _x = 0;
            _y = 0;
            _z = 0;
            _u = 0;
            _v = 0;
            _w = 0;
            _hand = false;
            _elbow = false;
            _wrist = false;
            _zoffset = 0;
            _Local = 0;
        }

        public RobotPoint(uint num, string name, double x, double y, double z, double u, double v, double w, bool hand, bool elbow, bool wrist)
        {
            _number = num;
            _name = name; 
            _x = x; 
            _y = y; 
            _z = z; 
            _u = u;
            _v = v;
            _w = w;
            _hand = hand;
            _elbow = elbow;
            _wrist = wrist;
            _zoffset = 0;
        }

        public RobotPoint(uint num, string name, double x, double y, double z, double u, double v, double w, bool hand, bool elbow, bool wrist, double ZOffset)
        {
            _number = num;
            _name = name;
            _x = x;
            _y = y;
            _z = z;
            _u = u;
            _v = v;
            _w = w;
            _hand = hand;
            _elbow = elbow;
            _wrist = wrist;
            _zoffset = ZOffset;
        }

        public RobotPoint(uint num, string name, double x, double y, double z, double u, double v, double w, bool hand, bool elbow, bool wrist, double ZOffset, int Local)
        {
            _number = num;
            _name = name;
            _x = x;
            _y = y;
            _z = z;
            _u = u;
            _v = v;
            _w = w;
            _hand = hand;
            _elbow = elbow;
            _wrist = wrist;
            _zoffset = ZOffset;
            _Local = Local;
        }
    }
}
