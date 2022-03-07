using System.IO;

namespace Tais.GModders
{
    static class ModPath
    {
        public  static string DepartDef => Path.Combine(root, "defs", "depart");

        private static string root;

        public static void Init(string modRootPath)
        {
            root = modRootPath;
        }
    }
}