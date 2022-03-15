using DynamicData;
using System.ComponentModel;

namespace Tais.API
{
    public interface IPop : INotifyPropertyChanged
    {
        string name { get; }

        IDepart depart { get; }

        int num { get; set; }

        bool isRegister { get;}

        int farmTotal { get; }

        int farmAverage { get; }

        TaxLevel taxLevel { get; set; }

        IPopTaxSource taxSource { get; }

        ILiveliHood liveliHood { get; }

        void DayInc(IDate now);

        IBufferManager buffMgr { get; }
    }
}