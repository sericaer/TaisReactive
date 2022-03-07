using System.IO;

namespace Tais.GModders
{

    public partial class Defs
    {
        public static class Builder
        {
            public static Defs Build()
            {
                var defs = new Defs();

                //foreach(var file in Directory.EnumerateFiles(ModPath.DepartDef, "*.txt"))
                //{
                //    var def = DefConvertor<DepartDef>.Convert(File.ReadAllText(file));
                //    defs._departDefs.Add(def);
                //}

                return defs;
            }
        }
    }
}
