using System;
using Tais.API.Def;

namespace Tais.GModders
{
    public partial class GModder
    {
        public static GModder inst { get; private set; }

        public IDefs defs { get; private set; }

        public GModder()
        {

        }
    }
}
