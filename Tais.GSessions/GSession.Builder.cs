﻿using System;
using System.Collections.Generic;
using System.Text;
using Tais.API;
using Tais.Runtime;

namespace Tais.GSessions
{
    public partial class GSession
    {
        public static class Builder
        {
            public static void Build()
            {
                var session = new GSession();
                GSession.inst = session;

                session.date = new Date();
                session.player = new Person("Person0");

                var taxMgr = new TaxManager(100);
                session.taxMgr = taxMgr;

                var departs = new List<IDepart>();
                session.departs = departs;
                for(int i=0; i<3; i++)
                {
                    departs.Add(new Depart($"DEPART{i}"));
                }

                foreach(var depart in session.departs)
                {
                    taxMgr.AddTaxSourcePerMonth(depart.taxSource);
                }

            }
        }
    }
}