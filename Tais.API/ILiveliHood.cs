using DynamicData;

namespace Tais.API
{
    public interface ILiveliHood
    {
        int value { get; }

        IObservableList<IEffect> effects { get;  }
    }
}