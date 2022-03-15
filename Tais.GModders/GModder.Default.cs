using System;
using System.Collections.Generic;
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

                defs._popDefs = new List<IPopDef>()
                {
                    new PopDef()
                    {
                        name = $"POP_0",
                        isRegister = true,
                        taxLevelEffect = TaxLevelDef.Default.dict,
                        GetFarmAverageEffectLevel = (average) =>
                        {
                            return new IEffectDef[] { (new PopLiveliHoodEffectDef(average * 10)) };
                        }
                    },
                    new PopDef()
                    {
                        name = $"POP_1",
                        isRegister = true,
                        taxLevelEffect = TaxLevelDef.Default.dict,
                        GetFarmAverageEffectLevel = (average) =>
                        {
                            return new IEffectDef[] { (new PopLiveliHoodEffectDef(average * 10)) };
                        },
                        CalcConvert = (pop) =>
                        {
                            return new (string to, float thousandth)[] { ($"POP_0", 0.1f), ($"POP_2", 0.2f), ($"POP_3", 0.3f) };
                        }
                    },
                    new PopDef()
                    {
                        name = $"POP_2",
                        isRegister = false,
                        taxLevelEffect = TaxLevelDef.Default.dict,
                    },
                    new PopDef()
                    {
                        name = $"POP_3",
                        isRegister = false,
                        taxLevelEffect = TaxLevelDef.Default.dict,
                    },
                };

                defs._departDefs = new List<IDepartDef>()
                {
                    new DepartDef()
                    {
                        name = $"DEPART_0",

                        _popInits = new List<PopInit>()
                        {
                            new PopInit()
                            {
                                pop = defs.popDefs.Single(x=>x.name == "POP_0"),
                                num = 1000,
                                farmAverage = 100
                            },

                            new PopInit()
                            {
                                pop = defs.popDefs.Single(x=>x.name == "POP_1"),
                                num = 30000,
                                farmAverage = 7
                            },

                            new PopInit()
                            {
                                pop = defs.popDefs.Single(x=>x.name == "POP_2"),
                                num = 20000
                            },

                            new PopInit()
                            {
                                pop = defs.popDefs.Single(x=>x.name == "POP_3"),
                                num = 2000
                            }
                        }
                    }
                };

                return rslt;
            }
        }
    }
}
