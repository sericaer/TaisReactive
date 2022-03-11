using Tais.API.Def;
using Tais.Runtime.Buffers;

namespace Tais.GSessions
{
    internal class Global
    {
        public ITaxLevelDef popTaxLevelDef
        {
            get
            {
                return PopTaxLevelBuffer.def;
            }
            set
            {
                PopTaxLevelBuffer.def = value;
            }
        }

        public Global(IDefs defs)
        {
            popTaxLevelDef = defs.popTaxLevelDef;
        }
    }
}