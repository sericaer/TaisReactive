using DynamicData;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tais.API
{
    public interface IDepart
    {
        string name { get; }
        ITaxSourcePerMonth taxSource { get; }

        IObservableList<IPop> pops { get; }

        void DayInc();
    }
}
