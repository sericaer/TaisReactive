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

        IPop Create(IPopDef def, int count);
        void DayInc(IDate now);
    }
}
