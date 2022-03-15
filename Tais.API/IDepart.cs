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

        int farmTotal { get; }
        TaxLevel taxLevel { get; set; }

        IDepartTaxSource taxSource { get; }

        IObservableList<IPop> pops { get; set; }

        void DayInc();
    }

    public enum DepartTaxLevel
    {
        VeryLow,
        Low,
        Mid,
        High,
        VeryHigh
    }
}
