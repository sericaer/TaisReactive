using System;
using System.Collections.Generic;
using System.Text;
using Tais.API;
using Tais.API.Def;

namespace Tais.GModders
{
    class PopDef : IPopDef
    {
        public string name { get; internal set; }

        public Dictionary<TaxLevel, IEnumerable<IEffectDef>> taxLevelEffect { get; internal set; }

        public Func<int, IEnumerable<IEffectDef>> GetFarmAverageEffectLevel { get; internal set; }
    }
}
