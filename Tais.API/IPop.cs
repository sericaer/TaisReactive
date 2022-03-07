using System.ComponentModel;

namespace Tais.API
{
    public interface IPop : INotifyPropertyChanged
    {
        string name { get; }
        int num { get; }

        ITaxSource taxSource { get; }

        void DayInc(IDate now);
    }
}