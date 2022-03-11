using System;
using System.Collections.Generic;
using System.Text;

namespace Tais.API.Def
{
    public interface ITaxLevelDef
    {
        Dictionary<DepartTaxLevel, Dictionary<EffectEnum, int>> dict { get; }
    }
}
