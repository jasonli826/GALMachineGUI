using System.ComponentModel;

public class CheckSpot3Offset : INotifyPropertyChanged
{
    public CheckSpot3Offset() { }
    public CheckSpot3Offset ShallowCopy()
    {
        return (CheckSpot3Offset)this.MemberwiseClone();

    }
    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string name) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    private string _index;
    public string Index { get => _index; set { _index = value; OnPropertyChanged(nameof(Index)); } }

    private string _x;
    public string X { get => _x; set { _x = value; OnPropertyChanged(nameof(X)); } }

    private string _y;
    public string Y { get => _y; set { _y = value; OnPropertyChanged(nameof(Y)); } }

    private string _z;
    public string Z { get => _z; set { _z = value; OnPropertyChanged(nameof(Z)); } }

    private string _u;
    public string U { get => _u; set { _u = value; OnPropertyChanged(nameof(U)); } }

    private string _v;
    public string V { get => _v; set { _v = value; OnPropertyChanged(nameof(V)); } }

    private string _w;
    public string W { get => _w; set { _w = value; OnPropertyChanged(nameof(W)); } }

    private string _zOff;
    public string ZOff { get => _zOff; set { _zOff = value; OnPropertyChanged(nameof(ZOff)); } }

    private string _hand;
    public string Hand { get => _hand; set { _hand = value; OnPropertyChanged(nameof(Hand)); } }

    private string _wrist;
    public string Wrist { get => _wrist; set { _wrist = value; OnPropertyChanged(nameof(Wrist)); } }

    private string _elbow;
    public string Elbow { get => _elbow; set { _elbow = value; OnPropertyChanged(nameof(Elbow)); } }

    private string _local;
    public string Local { get => _local; set { _local = value; OnPropertyChanged(nameof(Local)); } }

    private string _pointNum;
    public string PointNum { get => _pointNum; set { _pointNum = value; OnPropertyChanged(nameof(PointNum)); } }

    private string _axesPoint;
    public string AxesPoint { get => _axesPoint; set { _axesPoint = value; OnPropertyChanged(nameof(AxesPoint)); } }

    private string _name;
    public string Name { get => _name; set { _name = value; OnPropertyChanged(nameof(Name)); } }
}
