﻿using System;
using System.Collections.Generic;
using System.Text;
using Tais.API;

namespace Tais.Runtime
{
    public partial class GSession
    {
        public static class Builder
        {
            public static void Build()
            {
                var session = new GSession();
                GSession.inst = session;

                session.player = new Person("Person0");
            }
        }
    }
}
