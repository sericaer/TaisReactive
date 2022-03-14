using System;
using System.Collections.Generic;

namespace Tais.API.Def
{
    public interface IPopDef
    {
        string name { get; }

        Dictionary<TaxLevel, IEnumerable<IEffectDef>> taxLevelEffect { get; }

        Func<int, IEnumerable<IEffectDef>> GetFarmAverageEffectLevel { get; }
    }
}