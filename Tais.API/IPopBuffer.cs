using System.ComponentModel;

namespace Tais.API
{
    public interface IPopBuffer : INotifyPropertyChanged
    {
        int? taxEffect { get; }
    }
}