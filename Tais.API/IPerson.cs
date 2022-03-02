using System;
using System.ComponentModel;

namespace Tais.API
{
    public interface IPerson : INotifyPropertyChanged
    {
        string name { get; }
    }
}
