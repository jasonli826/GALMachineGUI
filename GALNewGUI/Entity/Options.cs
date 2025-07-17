using System;
using System.Collections.Generic;
using System.ComponentModel;

public class Options : INotifyPropertyChanged
{

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string name) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    public Options ShallowCopy()
    {
        return (Options)this.MemberwiseClone();

    }

    private List<string> _boolean;
    public List<string> boolean
    {
        get => _boolean;
        set
        {
            _boolean = value;
            OnPropertyChanged(nameof(boolean));
        }
    }
}
