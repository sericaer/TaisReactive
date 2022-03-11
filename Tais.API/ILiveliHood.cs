using DynamicData;
using System.ComponentModel;

namespace Tais.API
{
    public interface ILiveliHood : INotifyPropertyChanged
    {
        int value { get; }

        ISourceCache<IEffect, object> effects { get;  }
    }
}