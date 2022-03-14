using System;
using System.Collections.Generic;
using System.Text;

namespace Tais.API.Def
{
    public interface IEffectDef
    {
        int effectValue { get; }
        IEffect Generate(object from);
    }
}
