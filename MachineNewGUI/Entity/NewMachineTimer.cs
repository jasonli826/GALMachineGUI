using MachineNewGUI.Entity;
using System;
using System.ComponentModel;

public class NewMachineTimer : INotifyPropertyChanged
{
    public NewMachineTimer() { }
    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


    public NewMachineTimer ShallowCopy()
    {
        return (NewMachineTimer)this.MemberwiseClone();

    }
    private int _index;
    public int Index
    {
        get => _index;
        set { _index = value; OnPropertyChanged(nameof(Index)); }
    }

    private double _x;
    public double X
    {
        get => _x;
        set { _x = value; OnPropertyChanged(nameof(X)); }
    }

    private double _y;
    public double Y
    {
        get => _y;
        set { _y = value; OnPropertyChanged(nameof(Y)); }
    }

    private double _z;
    public double Z
    {
        get => _z;
        set { _z = value; OnPropertyChanged(nameof(Z)); }
    }

    private double _u;
    public double U
    {
        get => _u;
        set { _u = value; OnPropertyChanged(nameof(U)); }
    }

    private double _v;
    public double V
    {
        get => _v;
        set { _v = value; OnPropertyChanged(nameof(V)); }
    }

    private double _w;
    public double W
    {
        get => _w;
        set { _w = value; OnPropertyChanged(nameof(W)); }
    }

    private double _zOff;
    public double ZOff
    {
        get => _zOff;
        set { _zOff = value; OnPropertyChanged(nameof(ZOff)); }
    }

    private bool _hand;
    public bool Hand
    {
        get => _hand;
        set { _hand = value; OnPropertyChanged(nameof(Hand)); }
    }

    private bool _wrist;
    public bool Wrist
    {
        get => _wrist;
        set { _wrist = value; OnPropertyChanged(nameof(Wrist)); }
    }

    private bool _elbow;
    public bool Elbow
    {
        get => _elbow;
        set { _elbow = value; OnPropertyChanged(nameof(Elbow)); }
    }

    private bool _local;
    public bool Local
    {
        get => _local;
        set { _local = value; OnPropertyChanged(nameof(Local)); }
    }

    private string _pointNum;
    public string PointNum
    {
        get => _pointNum;
        set { _pointNum = value; OnPropertyChanged(nameof(PointNum)); }
    }

    private string _axesPoint;
    public string AxesPoint
    {
        get => _axesPoint;
        set { _axesPoint = value; OnPropertyChanged(nameof(AxesPoint)); }
    }

    private string _name;
    public string Name
    {
        get => _name;
        set { _name = value; OnPropertyChanged(nameof(Name)); }
    }
}
