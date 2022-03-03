using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Tais.API
{
    public interface IDate : INotifyPropertyChanged
    {
        int year { get; }
        int month { get; }
        int day { get; }

        void DayInc();
    }
}
