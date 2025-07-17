using System.ComponentModel;

namespace GALNewGUI.Entity
{
    public class ProductParameters : INotifyPropertyChanged
    {
        public ProductParameters() { }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private string _productFileName;
        public string ProductFileName
        {
            get => _productFileName;
            set { _productFileName = value; OnPropertyChanged(nameof(ProductFileName)); }
        }

        private string _name;
        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(nameof(Name)); }
        }

        private string _productName;
        public string ProductName
        {
            get => _productName;
            set { _productName = value; OnPropertyChanged(nameof(ProductName)); }
        }

        private string _length;
        public string Length
        {
            get => _length;
            set { _length = value; OnPropertyChanged(nameof(Length)); }
        }

        private string _height;
        public string Height
        {
            get => _height;
            set { _height = value; OnPropertyChanged(nameof(Height)); }
        }

        private string _width;
        public string Width
        {
            get => _width;
            set { _width = value; OnPropertyChanged(nameof(Width)); }
        }

        private string _preInspectionNeeded;
        public string PreInspectionNeeded
        {
            get => _preInspectionNeeded;
            set { _preInspectionNeeded = value; OnPropertyChanged(nameof(PreInspectionNeeded)); }
        }

        private Options _options;
        public Options Options
        {
            get => _options;
            set { _options = value; OnPropertyChanged(nameof(Options)); }
        }

        private string _progressInfo;
        public string ProgressInfo
        {
            get => _progressInfo;
            set { _progressInfo = value; OnPropertyChanged(nameof(ProgressInfo)); }
        }

        private InputTray _inputTray;
        public InputTray InputTray
        {
            get => _inputTray;
            set { _inputTray = value; OnPropertyChanged(nameof(InputTray)); }
        }

        private string _trayBarcodePrefix;
        public string TrayBarcodePrefix
        {
            get => _trayBarcodePrefix;
            set { _trayBarcodePrefix = value; OnPropertyChanged(nameof(TrayBarcodePrefix)); }
        }

        private string _trayBarcode;
        public string TrayBarcode
        {
            get => _trayBarcode;
            set { _trayBarcode = value; OnPropertyChanged(nameof(TrayBarcode)); }
        }

        private string _midBarcodeSkip;
        public string MidBarcodeSkip
        {
            get => _midBarcodeSkip;
            set { _midBarcodeSkip = value; OnPropertyChanged(nameof(MidBarcodeSkip)); }
        }

        private AdaptorPallet _adaptorPallet;
        public AdaptorPallet AdaptorPallet
        {
            get => _adaptorPallet;
            set { _adaptorPallet = value; OnPropertyChanged(nameof(AdaptorPallet)); }
        }

        private string _palletBarcode;
        public string PalletBarcode
        {
            get => _palletBarcode;
            set { _palletBarcode = value; OnPropertyChanged(nameof(PalletBarcode)); }
        }

        private string _palletLength;
        public string PalletLength
        {
            get => _palletLength;
            set { _palletLength = value; OnPropertyChanged(nameof(PalletLength)); }
        }

        private string _palletHeight;
        public string PalletHeight
        {
            get => _palletHeight;
            set { _palletHeight = value; OnPropertyChanged(nameof(PalletHeight)); }
        }

        private string _palletWidth;
        public string PalletWidth
        {
            get => _palletWidth;
            set { _palletWidth = value; OnPropertyChanged(nameof(PalletWidth)); }
        }

        private string _palletConveyorAxisClampStrokeGAL;
        public string PalletConveyorAxisClampStrokeGAL
        {
            get => _palletConveyorAxisClampStrokeGAL;
            set { _palletConveyorAxisClampStrokeGAL = value; OnPropertyChanged(nameof(PalletConveyorAxisClampStrokeGAL)); }
        }

        private string _finger1OffsetX;
        public string Finger1OffsetX
        {
            get => _finger1OffsetX;
            set { _finger1OffsetX = value; OnPropertyChanged(nameof(Finger1OffsetX)); }
        }

        private string _finger1OffsetY;
        public string Finger1OffsetY
        {
            get => _finger1OffsetY;
            set { _finger1OffsetY = value; OnPropertyChanged(nameof(Finger1OffsetY)); }
        }

        private string _finger1OffsetZ;
        public string Finger1OffsetZ
        {
            get => _finger1OffsetZ;
            set { _finger1OffsetZ = value; OnPropertyChanged(nameof(Finger1OffsetZ)); }
        }

        private string _finger1OffsetU;
        public string Finger1OffsetU
        {
            get => _finger1OffsetU;
            set { _finger1OffsetU = value; OnPropertyChanged(nameof(Finger1OffsetU)); }
        }

        private string _finger1Barcode;
        public string Finger1Barcode
        {
            get => _finger1Barcode;
            set { _finger1Barcode = value; OnPropertyChanged(nameof(Finger1Barcode)); }
        }

        private string _finger2OffsetX;
        public string Finger2OffsetX
        {
            get => _finger2OffsetX;
            set { _finger2OffsetX = value; OnPropertyChanged(nameof(Finger2OffsetX)); }
        }

        private string _finger2OffsetY;
        public string Finger2OffsetY
        {
            get => _finger2OffsetY;
            set { _finger2OffsetY = value; OnPropertyChanged(nameof(Finger2OffsetY)); }
        }

        private string _finger2OffsetZ;
        public string Finger2OffsetZ
        {
            get => _finger2OffsetZ;
            set { _finger2OffsetZ = value; OnPropertyChanged(nameof(Finger2OffsetZ)); }
        }

        private string _finger2OffsetU;
        public string Finger2OffsetU
        {
            get => _finger2OffsetU;
            set { _finger2OffsetU = value; OnPropertyChanged(nameof(Finger2OffsetU)); }
        }

        private string _finger2Barcode;
        public string Finger2Barcode
        {
            get => _finger2Barcode;
            set { _finger2Barcode = value; OnPropertyChanged(nameof(Finger2Barcode)); }
        }

        private string _axis3ServoTraySingulatePos2GAL;
        public string Axis3ServoTraySingulatePos2GAL
        {
            get => _axis3ServoTraySingulatePos2GAL;
            set { _axis3ServoTraySingulatePos2GAL = value; OnPropertyChanged(nameof(Axis3ServoTraySingulatePos2GAL)); }
        }

        private GALTimer _galTimer;
        public GALTimer GALTimer
        {
            get => _galTimer;
            set { _galTimer = value; OnPropertyChanged(nameof(GALTimer)); }
        }
        private LeftTable _lefttable;
        public LeftTable LeftTable
        {
            get => _lefttable;
            set { _lefttable = value; OnPropertyChanged(nameof(LeftTable)); }
        }
        private RightTable _righttable;
        public RightTable RightTable
        {
            get => _righttable;
            set { _righttable = value; OnPropertyChanged(nameof(RightTable)); }
        }

        public ProductParameters ShallowCopy()
        {
            return (ProductParameters)this.MemberwiseClone();

        }

    }
}