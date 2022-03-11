using System;
using System.Linq;

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
                
                for(int i=0; i<3; i++)
                {
                    var popDef = new PopDef();
                    popDef.name = $"POP_{i}";

                    defs._popDefs.Add(popDef);
                }

                for(int i=0; i<3; i++)
                {
                    var departDef = new DepartDef();
                    departDef.name = $"DEPART_{i}";

                    for(int j=0; j<3; j++)
                    {
                        departDef._popInits.Add((defs.popDefs.ElementAt(j), (j+1)*10000));
                    }

                    defs._departDefs.Add(departDef);
                }

                return rslt;
            }
        }
    }
}
