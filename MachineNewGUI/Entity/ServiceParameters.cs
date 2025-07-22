using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace MachineNewGUI.Entity
{
    class ServiceParameters : INotifyPropertyChanged
    {
        double _RobotSpeed;
        public double RobotSpeed { get { return _RobotSpeed; } set { _RobotSpeed = value; OnPropertyChanged(new PropertyChangedEventArgs("RobotSpeed")); } } 
        
        bool _IsDryRun;
        public bool IsDryRun { get { return _IsDryRun; } set { _IsDryRun = value; OnPropertyChanged(new PropertyChangedEventArgs("IsDryRun")); } }

        bool _IsSelfRun;
        public bool IsSelfRun { get { return _IsSelfRun; } set { _IsSelfRun = value; OnPropertyChanged(new PropertyChangedEventArgs("IsSelfRun")); } }


        bool _IsEmptytrayVisionRes;
        public bool IsEmptyTrayVisionResult { get { return _IsEmptytrayVisionRes; } set { _IsEmptytrayVisionRes = value; OnPropertyChanged(new PropertyChangedEventArgs("IsEmptyTrayVisionResult")); } }

        bool _IsLabelPresentVisionResult;
        public bool IsLabelPresentVisionResult { get { return _IsLabelPresentVisionResult; } set { _IsLabelPresentVisionResult = value; OnPropertyChanged(new PropertyChangedEventArgs("IsLabelPresentVisionResult")); } }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }

        public ServiceParameters()
        {
            RobotSpeed = 100;
            IsDryRun = false;
            IsSelfRun = false;
            IsLabelPresentVisionResult = false;
            IsEmptyTrayVisionResult = false;
        }
    }
}
