using DynamicData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Tais.API
{
    public interface IDepart : INotifyPropertyChanged
    {
        string name { get; }

        int popCount { get; }

        ITaxSourcePerMonth taxSource { get; }

        IObservableList<IPop> pops { get; }

        void DayInc();
    }
}
