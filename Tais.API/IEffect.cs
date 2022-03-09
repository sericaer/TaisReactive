using System.ComponentModel;

namespace Tais.API
{
    public interface IEffect : INotifyPropertyChanged
    {
        object key { get; }
        int value { get; set; }
    }
}
