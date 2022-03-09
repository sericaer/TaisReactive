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

        DepartTaxLevel taxLevel { get; set; }

        IDepartTaxSource taxSource { get; }

        IObservableList<IPop> pops { get; }

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
