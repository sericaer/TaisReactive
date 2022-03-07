using System;
using System.Collections.Generic;
using System.Text;
using Tais.API;

namespace Tais.GSessions
{
    public partial class GSession
    {
        public static GSession inst { get; private set; }

        public IDate date { get; private set; }

        public IPerson player { get; private set; }

        public ITaxManager taxMgr { get; private set; }

        public IPopManager popMgr { get; private set; }

        public IEnumerable<IDepart> departs { get; private set; }

        public void OnDayInc()
        {
            date.DayInc();

            taxMgr.DayInc(date.year, date.month, date.day);
            popMgr.DayInc(date);

            foreach(var depart in departs)
            {
                depart.DayInc();
            }
        }
    }
}
