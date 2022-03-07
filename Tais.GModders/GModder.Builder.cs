namespace Tais.GModders
{
    public partial class GModder
    {
        public static class Builder
        {
            public static void Build(string modRootPath)
            {
                ModPath.Init(modRootPath);

                inst = new GModder();

                inst.defs = Defs.Builder.Build();
            }
        }
    }
}
