using System.Collections.Generic;

namespace Tais.API.Def
{
    public interface IDepartDef
    {
        string name { get; }

        IEnumerable<(IPopDef def, int num)> popInits { get; }
    }
}