using DynamicData;
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

                //inst.global = new Global(defs);

                inst.date = new Date();
                inst.player = new Person("Person0");

                var taxMgr = new TaxManager(100);
                inst.taxMgr = taxMgr;

                inst.popMgr = new PopManager();

                var departs = new List<IDepart>();
                inst.departs = departs;

                foreach(var departDef in defs.departDefs)
                {
                    IDepart depart = new Depart(departDef.name, inst.popMgr.pops.Connect().Filter(x => x.depart.name == departDef.name).AsObservableList());
                    departs.Add(depart);


                    foreach (var popInit in departDef.popInits)
                    {
                        var pop = inst.popMgr.Create(depart, popInit);
                    }

                    taxMgr.AddTaxSourcePerMonth(depart.taxSource);
                }
            }
        }
    }
}
