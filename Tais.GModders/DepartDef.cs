using System.Collections.Generic;
using Tais.API.Def;

namespace Tais.GModders
{
    public class DepartDef : IDepartDef
    {
        public string name { get; internal set; }

        public IEnumerable<PopInit> popInits => _popInits;

        internal List<PopInit> _popInits = new List<PopInit>();
    }
}
