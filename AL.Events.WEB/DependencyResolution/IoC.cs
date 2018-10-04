using AL.Events.Dependency;
using StructureMap;

namespace AL.Events.WEB.DependencyResolution
{
    public static class IoC
    {
        public static IContainer Initialize()
        {
            return new Container(c =>
            {
                c.AddRegistry<DefaultRegistry>();
                c.AddRegistry<GeneralRegistry>();
            });
        }
    }
}