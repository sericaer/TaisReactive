using System;
using System.Collections.Generic;

namespace Tais.API.Def
{
    public interface IPopDef
    {
        string name { get; }

        bool isRegister { get; }

        Dictionary<TaxLevel, IEnumerable<IEffectDef>> taxLevelEffect { get; }

        Func<int, IEnumerable<IEffectDef>> GetFarmAverageEffectLevel { get; }

        Func<IPop, IEnumerable<(string to, float thousandth)>> CalcConvert { get; }
    }
}