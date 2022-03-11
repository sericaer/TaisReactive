using System.Collections.Generic;
using Tais.API;
using Tais.API.Def;

namespace Tais.GModders
{
    public partial class GModder
    {
        public class TaxLevelDef : ITaxLevelDef
        {
            public Dictionary<DepartTaxLevel, Dictionary<EffectEnum, int>> dict { get; private set; }

            public static TaxLevelDef Default = new TaxLevelDef()
            {
                dict = new Dictionary<DepartTaxLevel, Dictionary<EffectEnum, int>>()
                {
                    { DepartTaxLevel.VeryLow,  new Dictionary<EffectEnum, int>(){ { EffectEnum.PopTax, -80 }, { EffectEnum.PopLiveliHood, -1} } },
                    { DepartTaxLevel.Low,      new Dictionary<EffectEnum, int>(){ { EffectEnum.PopTax, -30 }, { EffectEnum.PopLiveliHood, -5} } },
                    { DepartTaxLevel.Mid,      new Dictionary<EffectEnum, int>(){ { EffectEnum.PopTax, 00 },  { EffectEnum.PopLiveliHood, -15} } },
                    { DepartTaxLevel.High,     new Dictionary<EffectEnum, int>(){ { EffectEnum.PopTax, 20 },  { EffectEnum.PopLiveliHood, -35} } },
                    { DepartTaxLevel.VeryHigh, new Dictionary<EffectEnum, int>(){ { EffectEnum.PopTax, 60 },  { EffectEnum.PopLiveliHood, -60} } }
                }
            };
        }
    }
}
