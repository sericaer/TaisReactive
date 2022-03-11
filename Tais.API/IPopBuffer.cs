using System.Collections.Generic;
using System.ComponentModel;

namespace Tais.API
{
    public interface IPopBuffer
    {
        IPop owner { get; }
        IEnumerable<IEffect> effects { get; }

        //int? taxEffect { get; }
        //int? liveliHoodEffect { get; }
    }
}