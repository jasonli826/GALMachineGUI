using System.ComponentModel;

namespace GALNewGUI.Entity
{
    public class AdaptorPallet : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private string _rows;
        public string Rows
        {
            get => _rows;
            set { _rows = value; OnPropertyChanged(nameof(Rows)); }
        }

        private string _columns;
        public string Columns
        {
            get => _columns;
            set { _columns = value; OnPropertyChanged(nameof(Columns)); }
        }

        private string _rowPitch;
        public string RowPitch
        {
            get => _rowPitch;
            set { _rowPitch = value; OnPropertyChanged(nameof(RowPitch)); }
        }

        private string _columnPitch;
        public string ColumnPitch
        {
            get => _columnPitch;
            set { _columnPitch = value; OnPropertyChanged(nameof(ColumnPitch)); }
        }

        private string _rowOffset;
        public string RowOffset
        {
            get => _rowOffset;
            set { _rowOffset = value; OnPropertyChanged(nameof(RowOffset)); }
        }

        private string _columnOffset;
        public string ColumnOffset
        {
            get => _columnOffset;
            set { _columnOffset = value; OnPropertyChanged(nameof(ColumnOffset)); }
        }

        private string _moduleZOffset;
        public string ModuleZOffset
        {
            get => _moduleZOffset;
            set { _moduleZOffset = value; OnPropertyChanged(nameof(ModuleZOffset)); }
        }

        private string _moduleOrientation;
        public string ModuleOrientation
        {
            get => _moduleOrientation;
            set { _moduleOrientation = value; OnPropertyChanged(nameof(ModuleOrientation)); }
        }

        private string _barcodeOffsetX;
        public string BarcodeOffsetX
        {
            get => _barcodeOffsetX;
            set { _barcodeOffsetX = value; OnPropertyChanged(nameof(BarcodeOffsetX)); }
        }

        private string _barcodeOffsetY;
        public string BarcodeOffsetY
        {
            get => _barcodeOffsetY;
            set { _barcodeOffsetY = value; OnPropertyChanged(nameof(BarcodeOffsetY)); }
        }

        private string _barcodeOffsetZ;
        public string BarcodeOffsetZ
        {
            get => _barcodeOffsetZ;
            set { _barcodeOffsetZ = value; OnPropertyChanged(nameof(BarcodeOffsetZ)); }
        }

        private string _barcodeOffsetU;
        public string BarcodeOffsetU
        {
            get => _barcodeOffsetU;
            set { _barcodeOffsetU = value; OnPropertyChanged(nameof(BarcodeOffsetU)); }
        }

        private string _thicknessDiffMM;
        public string ThicknessDiffMM
        {
            get => _thicknessDiffMM;
            set { _thicknessDiffMM = value; OnPropertyChanged(nameof(ThicknessDiffMM)); }
        }

        private string _flyCheckSpotEnable;
        public string FlyCheckSpotEnable
        {
            get => _flyCheckSpotEnable;
            set { _flyCheckSpotEnable = value; OnPropertyChanged(nameof(FlyCheckSpotEnable)); }
        }

        private string _flyCheckSpeed;
        public string FlyCheckSpeed
        {
            get => _flyCheckSpeed;
            set { _flyCheckSpeed = value; OnPropertyChanged(nameof(FlyCheckSpeed)); }
        }

        private string _checkDelta;
        public string CheckDelta
        {
            get => _checkDelta;
            set { _checkDelta = value; OnPropertyChanged(nameof(CheckDelta)); }
        }

        private string _gripperPickOffsetX;
        public string GripperPickOffsetX
        {
            get => _gripperPickOffsetX;
            set { _gripperPickOffsetX = value; OnPropertyChanged(nameof(GripperPickOffsetX)); }
        }

        private string _gripperPickOffsetY;
        public string GripperPickOffsetY
        {
            get => _gripperPickOffsetY;
            set { _gripperPickOffsetY = value; OnPropertyChanged(nameof(GripperPickOffsetY)); }
        }

        private string _gripperPickOffsetZ;
        public string GripperPickOffsetZ
        {
            get => _gripperPickOffsetZ;
            set { _gripperPickOffsetZ = value; OnPropertyChanged(nameof(GripperPickOffsetZ)); }
        }

        private string _gripperPickOffsetU;
        public string GripperPickOffsetU
        {
            get => _gripperPickOffsetU;
            set { _gripperPickOffsetU = value; OnPropertyChanged(nameof(GripperPickOffsetU)); }
        }

        // Complex child objects (implement INotifyPropertyChanged inside those classes too)
        public BarcodeOffsetPoints BarcodeOffset_Points { get; set; }
        public ModuleBarcodePoints ModuleBarcode_Points { get; set; }
        public CheckSpot1Offset CheckSpot1Offset { get; set; }
        public CheckSpot2Offset CheckSpot2Offset { get; set; }
        public CheckSpot3Offset CheckSpot3Offset { get; set; }
        public CheckSpot4Offset CheckSpot4Offset { get; set; }
        public CheckSpotEnable CheckSpotEnable { get; set; }
        public CheckSpotPosOnOff CheckSpotPosOnOff { get; set; }
        public FlyCheckSpot1Offset FlyCheckSpot1Offset { get; set; }
        public FlyCheckSpot2Offset FlyCheckSpot2Offset { get; set; }
        public FlyCheckSpot3Offset FlyCheckSpot3Offset { get; set; }
        public FlyCheckSpot4Offset FlyCheckSpot4Offset { get; set; }
        public PlacementOffset PlacementOffset { get; set; }
    }
}
