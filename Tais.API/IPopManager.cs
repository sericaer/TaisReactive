using DynamicData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Tais.API.Def;

namespace Tais.API
{
    public interface IPopManager : INotifyPropertyChanged
    {
        int registerCount { get; }

        IObservableList<IPop> pops { get; }

        void DayInc(IDate now);
        IPop Create(IDepart depart, PopInit popInit);
    }
}
