using DynamicData;
using System.Collections.Generic;
using System.ComponentModel;

namespace Tais.API
{
    public interface ITaxManager : INotifyPropertyChanged
    {
        int stock { get; }

        int taxPerMonth { get; }

        IObservableList<ITaxSource> taxSourcesPerMonth { get; }

        void DayInc(int year, int month, int day);
    }

    public enum TaxLevel
    {
        VeryLow,
        Low,
        Mid,
        High,
        VeryHigh
    }
}