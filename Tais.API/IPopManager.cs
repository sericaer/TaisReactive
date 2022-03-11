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
        int totalCount { get; }

        IObservableList<IPop> pops { get; }

        void DayInc(IDate now);
        IPop Create(PopInit popInit);
    }
}
