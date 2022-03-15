using System.Collections.Generic;

namespace Tais.API.Def
{
    public interface IDepartDef
    {
        string name { get; }

        IEnumerable<PopInit> popInits { get; }
    }

    public class PopInit
    {
        public IPopDef pop;

        public int num;
        public int? farmAverage;
    }
}