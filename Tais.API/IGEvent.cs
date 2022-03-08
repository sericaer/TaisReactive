using System;
using System.Collections.Generic;
using System.Text;

namespace Tais.API
{
    public interface IGEvent
    {
        string title { get; }
        string desc { get; }

        IEnumerable<IOption> options { get; }
    }

    public interface IOption
    {
        string desc { get; }

        void Do();
    }
}
