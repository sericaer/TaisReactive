using System;
using System.Collections.Generic;
using System.Text;
using Tais.API;

namespace Tais.Runtime
{
    public partial class GSession
    {
        public static GSession inst { get; private set; }

        public IPerson player { get; set; }
    }
}
