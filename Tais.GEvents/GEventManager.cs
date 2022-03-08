using System;
using System.Collections.Generic;
using System.Text;
using Tais.API;
using Tais.GSessions;

namespace Tais.GEvents
{
    public class GEventManager
    {
        public static GEventManager inst = new GEventManager();

        private List<GEvent> gEvents = new List<GEvent>();

        public GEventManager()
        {
            gEvents.Add(new GEvent());
        }

        public IEnumerable<IGEvent> OnDayInc(GSession session)
        {
            foreach (var gEvent in gEvents)
            {
                if (gEvent.isTrigge())
                {
                    yield return gEvent;
                }
            }

            yield break;
        }
    }
}
