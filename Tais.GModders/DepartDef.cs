using System.Collections.Generic;
using Tais.API.Def;

namespace Tais.GModders
{
    public class DepartDef : IDepartDef
    {
        public string name { get; internal set; }

        public IEnumerable<(IPopDef def, int num)> popInits => _popInits;

        internal List<(IPopDef def, int num)> _popInits = new List<(IPopDef def, int num)>();
    }
}
