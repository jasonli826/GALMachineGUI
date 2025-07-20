using MachineNewGUI.Entity;
using System;
using System.ComponentModel;

public class InputTray : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string name) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    public InputTray ShallowCopy()
    {
        return (InputTray)this.MemberwiseClone();

    }

    public InputTray() {
        BarcodeOffsetPoints = new BarcodeOffsetPoints();
        ModuleBarcodePoints = new ModuleBarcodePoints();
        CheckSpot1Offset = new CheckSpot1Offset();
        CheckSpot2Offset = new CheckSpot2Offset();
        CheckSpot3Offset = new CheckSpot3Offset();
        CheckSpot4Offset = new CheckSpot4Offset();
        CheckSpotEnable = new CheckSpotEnable();
        CheckSpotPosOnOff = new CheckSpotPosOnOff();
        FlyCheckSpot1Offset = new FlyCheckSpot1Offset();
        FlyCheckSpot2Offset = new FlyCheckSpot2Offset();
        FlyCheckSpot3Offset = new FlyCheckSpot3Offset();
        FlyCheckSpot4Offset = new FlyCheckSpot4Offset();
    }
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

    private BarcodeOffsetPoints _barcodeOffset_Points;
    public BarcodeOffsetPoints BarcodeOffsetPoints
    {
        get => _barcodeOffset_Points;
        set { _barcodeOffset_Points = value; OnPropertyChanged(nameof(BarcodeOffsetPoints)); }
    }

    private ModuleBarcodePoints _moduleBarcode_Points;
    public ModuleBarcodePoints ModuleBarcodePoints
    {
        get => _moduleBarcode_Points;
        set { _moduleBarcode_Points = value; OnPropertyChanged(nameof(ModuleBarcodePoints)); }
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

    private CheckSpot1Offset _checkSpot1Offset;
    public CheckSpot1Offset CheckSpot1Offset
    {
        get => _checkSpot1Offset;
        set { _checkSpot1Offset = value; OnPropertyChanged(nameof(CheckSpot1Offset)); }
    }

    private CheckSpot2Offset _checkSpot2Offset;
    public CheckSpot2Offset CheckSpot2Offset
    {
        get => _checkSpot2Offset;
        set { _checkSpot2Offset = value; OnPropertyChanged(nameof(CheckSpot2Offset)); }
    }

    private CheckSpot3Offset _checkSpot3Offset;
    public CheckSpot3Offset CheckSpot3Offset
    {
        get => _checkSpot3Offset;
        set { _checkSpot3Offset = value; OnPropertyChanged(nameof(CheckSpot3Offset)); }
    }

    private CheckSpot4Offset _checkSpot4Offset;
    public CheckSpot4Offset CheckSpot4Offset
    {
        get => _checkSpot4Offset;
        set { _checkSpot4Offset = value; OnPropertyChanged(nameof(CheckSpot4Offset)); }
    }

    private CheckSpotEnable _checkSpotEnable;
    public CheckSpotEnable CheckSpotEnable
    {
        get => _checkSpotEnable;
        set { _checkSpotEnable = value; OnPropertyChanged(nameof(CheckSpotEnable)); }
    }

    private CheckSpotPosOnOff _checkSpotPosOnOff;
    public CheckSpotPosOnOff CheckSpotPosOnOff
    {
        get => _checkSpotPosOnOff;
        set { _checkSpotPosOnOff = value; OnPropertyChanged(nameof(CheckSpotPosOnOff)); }
    }

    private string _thicknessDiffMM;
    public string ThicknessDiffMM
    {
        get => _thicknessDiffMM;
        set { _thicknessDiffMM = value; OnPropertyChanged(nameof(ThicknessDiffMM)); }
    }

    private FlyCheckSpot1Offset _flyCheckSpot1Offset;
    public FlyCheckSpot1Offset FlyCheckSpot1Offset
    {
        get => _flyCheckSpot1Offset;
        set { _flyCheckSpot1Offset = value; OnPropertyChanged(nameof(FlyCheckSpot1Offset)); }
    }

    private FlyCheckSpot2Offset _flyCheckSpot2Offset;
    public FlyCheckSpot2Offset FlyCheckSpot2Offset
    {
        get => _flyCheckSpot2Offset;
        set { _flyCheckSpot2Offset = value; OnPropertyChanged(nameof(FlyCheckSpot2Offset)); }
    }

    private FlyCheckSpot3Offset _flyCheckSpot3Offset;
    public FlyCheckSpot3Offset FlyCheckSpot3Offset
    {
        get => _flyCheckSpot3Offset;
        set { _flyCheckSpot3Offset = value; OnPropertyChanged(nameof(FlyCheckSpot3Offset)); }
    }

    private FlyCheckSpot4Offset _flyCheckSpot4Offset;
    public FlyCheckSpot4Offset FlyCheckSpot4Offset
    {
        get => _flyCheckSpot4Offset;
        set { _flyCheckSpot4Offset = value; OnPropertyChanged(nameof(FlyCheckSpot4Offset)); }
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

    private PlacementOffset _placementOffset;
    public PlacementOffset PlacementOffset
    {
        get => _placementOffset;
        set { _placementOffset = value; OnPropertyChanged(nameof(PlacementOffset)); }
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
}
