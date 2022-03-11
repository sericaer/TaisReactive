using System;
using System.Collections.Generic;
using System.Text;
using Tais.API;
using Tais.Runtime;
using Tais.API.Def;

namespace Tais.GSessions
{
    public partial class GSession
    {
        public static class Builder
        {
            public static void Build(IDefs defs)
            {
                inst = new GSession();

                inst.global = new Global(defs);

                inst.date = new Date();
                inst.player = new Person("Person0");

                var taxMgr = new TaxManager(100);
                inst.taxMgr = taxMgr;

                inst.popMgr = new PopManager();

                var departs = new List<IDepart>();
                inst.departs = departs;

                foreach(var departDef in defs.departDefs)
                {
                    var depart = new Depart(departDef.name);
                    departs.Add(depart);

                    foreach(var popInit in departDef.popInits)
                    {
                        var pop = inst.popMgr.Create(popInit.def, popInit.num);
                        depart.AddPop(pop);
                    }

                    taxMgr.AddTaxSourcePerMonth(depart.taxSource);
                }
            }
        }
    }
}
