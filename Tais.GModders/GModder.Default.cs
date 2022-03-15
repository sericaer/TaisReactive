using System;
using System.Linq;
using Tais.API.Def;
using Tais.GModders.Effects;

namespace Tais.GModders
{
    public partial class GModder
    {
        public static GModder Default 
        { 
            get
            {
                var rslt = new GModder();

                var defs = new Defs();
                rslt.defs = defs;

                defs.popTaxLevelDef = TaxLevelDef.Default;
                
                for(int i=0; i<4; i++)
                {
                    var popDef = new PopDef();
                    popDef.name = $"POP_{i}";
                    popDef.taxLevelEffect = TaxLevelDef.Default.dict;

                    popDef.GetFarmAverageEffectLevel = (average) =>
                    {
                        return new IEffectDef[] { (new PopLiveliHoodEffectDef(average * 10)) };
                    };

                    if(i==1)
                    {
                        popDef.CalcConvert = (pop) =>
                        {
                            return new (string to, float thousandth)[] { ($"POP_0", 0.1f), ($"POP_2", 0.2f), ($"POP_3", 0.3f) };
                        };
                    }

                    if (i != 3)
                    {
                        popDef.isRegister = true;
                    }


                    defs._popDefs.Add(popDef);
                }

                for(int i=0; i<3; i++)
                {
                    var departDef = new DepartDef();
                    departDef.name = $"DEPART_{i}";

                    for (int j = 0; j < 4; j++)
                    {
                        departDef._popInits.Add(new PopInit()
                        {
                            pop = defs.popDefs.ElementAt(j),
                            num = (j + 1) * 10000,
                            farmAverage = (10 - j * j)
                        });
                    }

                    defs._departDefs.Add(departDef);
                }

                return rslt;
            }
        }
    }
}
