using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GALNewGUI.Entity
{

    public  class InterfaceResult: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        private string program;
        public string Program
        {
            get => program;
            set
            {
                if (program != value)
                {
                    program = value;
                    OnPropertyChanged(nameof(Program));
                }
            }
        }

        private string function;
        public string Function
        {
            get => function;
            set
            {
                if (function != value)
                {
                    function = value;
                    OnPropertyChanged(nameof(Function));
                }
            }
        }
        private string paramString;
        public string Param_String
        {
            get => paramString;
            set
            {
                if (paramString != value)
                {
                    paramString = value;
                    OnPropertyChanged(nameof(Param_String));
                }
            }
        }
        private bool? isSendParameter;
        public bool? IsSendParameter
        {
            get => isSendParameter;
            set
            {
                if (isSendParameter != value)
                {
                    isSendParameter = value;
                    OnPropertyChanged(nameof(IsSendParameter));
                }
            }
        }

        private int numberOfSendParameters;
        public int NumberOfSendParameters
        {
            get => numberOfSendParameters;
            set
            {
                if (numberOfSendParameters != value)
                {
                    numberOfSendParameters = value;
                    OnPropertyChanged(nameof(NumberOfSendParameters));
                }
            }
        }
        private bool? callStyleReturn;
        public bool? CallStyleReturn
        {
            get => callStyleReturn;
            set
            {
                if (callStyleReturn != value)
                {
                    callStyleReturn = value;
                    OnPropertyChanged(nameof(CallStyleReturn));
                }
            }
        }
        private bool? isGripperSide;
        public bool? IsGripperSide
        {
            get => isGripperSide;
            set
            {
                if (isGripperSide != value)
                {
                    isGripperSide = value;
                    OnPropertyChanged(nameof(IsGripperSide));
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
        public InterfaceResult() { }

        public InterfaceResult(string progm, string fn, string param, bool sendingParam, int numOfParam, bool callStyle, bool gripper, bool skip)
        {
            Program = progm;
            Function = fn;
            Param_String = param;
            IsSendParameter = sendingParam;
            NumberOfSendParameters = numOfParam;
            CallStyleReturn = callStyle;
            IsGripperSide = gripper;
            IsSkip = skip;

        }
    }
}
