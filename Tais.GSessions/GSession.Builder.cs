using System;
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
            }
        }
    }
}
