using DynamicData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Tais.API
{
    public interface IPopManager : INotifyPropertyChanged
    {
        int totalCount { get; }

        IObservableList<IPop> pops { get; }

        IPop Create(string name, int count);
        void DayInc(IDate now);
    }
}
