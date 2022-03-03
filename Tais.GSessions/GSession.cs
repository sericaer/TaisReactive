﻿using System;
using System.Collections.Generic;
using System.Text;
using Tais.API;

namespace Tais.GSessions
{
    public partial class GSession
    {
        public static GSession inst { get; private set; }

        public IDate date { get; set; }

        public IPerson player { get; set; }

        public void OnDayInc()
        {
            date.DayInc();
        }
    }
}
