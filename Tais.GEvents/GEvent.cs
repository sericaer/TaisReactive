using System;
using System.Collections.Generic;
using Tais.API;
using Tais.GSessions;

namespace Tais.GEvents
{
    public class GEvent : IGEvent
    {
        public string title { get; private set; }
        public string desc { get; private set; }

        public IEnumerable<IOption> options => _options;

        private List<IOption> _options = new List<IOption>();

        public class Option : IOption
        {
            public string desc { get; private set; }

            public Option()
            {
                desc = "OPT_TEST";
            }

            public void Do()
            {
                GSession.inst.taxMgr.stock -= 300;
            }
        }

        public GEvent()
        {
            title = "TTTLE_TEST";
            desc = "DESC_TEST";

            _options.Add(new Option());
        }

        public bool isTrigge()
        {
            return true;
        }

    }
}
