using System;
using System.Collections.Generic;
using System.Text;

namespace Tais.API.Def
{
    public interface IDefs
    {
        IEnumerable<IDepartDef> departDefs { get; }
        ITaxLevelDef popTaxLevelDef { get; }
    }
}
