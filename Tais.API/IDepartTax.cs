﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Tais.API
{
    public interface IDepartTax : ITaxSource
    {
    }

    public interface ITaxSource: INotifyPropertyChanged
    {
        string label { get; }
        int value { get; }
    }
}
