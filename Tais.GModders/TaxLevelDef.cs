using System.Collections.Generic;
using Tais.API;
using Tais.API.Def;
using Tais.GModders.Effects;

namespace Tais.GModders
{
    public partial class GModder
    {
        public class TaxLevelDef : ITaxLevelDef
        {
            public Dictionary<TaxLevel, IEnumerable<IEffectDef>> dict { get; private set; }

            public static TaxLevelDef Default = new TaxLevelDef()
            {
                dict = new Dictionary<TaxLevel, IEnumerable<IEffectDef>>()
                {
                    { TaxLevel.VeryLow,  new IEffectDef[]{ new PopTaxEffectDef(-80), new PopLiveliHoodEffectDef(-1)} },
                    { TaxLevel.Low,      new IEffectDef[]{ new PopTaxEffectDef(-30), new PopLiveliHoodEffectDef(-5)} },
                    { TaxLevel.Mid,      new IEffectDef[]{ new PopTaxEffectDef(00), new PopLiveliHoodEffectDef(-15)} },
                    { TaxLevel.High,     new IEffectDef[]{ new PopTaxEffectDef(20), new PopLiveliHoodEffectDef(-35)} },
                    { TaxLevel.VeryHigh, new IEffectDef[]{ new PopTaxEffectDef(60), new PopLiveliHoodEffectDef(-60)} }
                }
            };
        }
    }
}
