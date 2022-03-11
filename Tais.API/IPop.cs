using DynamicData;
using System.ComponentModel;

namespace Tais.API
{
    public interface IPop : INotifyPropertyChanged
    {
        string name { get; }

        int num { get; }

        int farmTotal { get; }

        int farmAverage { get; }

        IPopTaxSource taxSource { get; }

        ILiveliHood liveliHood { get; }

        void DayInc(IDate now);

        IBufferManager buffMgr { get; }
    }
}