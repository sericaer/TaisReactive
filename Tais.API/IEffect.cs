using System;
using System.ComponentModel;

namespace Tais.API
{
    public interface IEffect
    {
        object from { get; }

        int value { get; }

        string desc { get; }

        Action<object> SetTarget { get; }
    }
}
