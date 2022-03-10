using DynamicData;
using System.ComponentModel;

namespace Tais.API
{
    public interface ILiveliHood : INotifyPropertyChanged
    {
        int value { get; }

        ISourceList<IEffect> effects { get;  }
    }
}