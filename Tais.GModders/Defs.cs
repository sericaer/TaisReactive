using System.Collections.Generic;
using Tais.API.Def;

namespace Tais.GModders
{
    public partial class Defs : IDefs
    {
        public IEnumerable<IDepartDef> departDefs => _departDefs;
        public IEnumerable<IPopDef> popDefs => _popDefs;

        public ITaxLevelDef popTaxLevelDef { get; internal set; }

        internal List<IDepartDef> _departDefs = new List<IDepartDef>();
        internal List<IPopDef> _popDefs = new List<IPopDef>();
    }
}
