using AL.Events.Dependency;
using StructureMap;

namespace AL.Events.WEB.DependencyResolution
{
    public static class IoC
    {
        private static IContainer _container;

        static IoC()
        {
            _container = new Container(c =>
            {
                c.AddRegistry<DefaultRegistry>();
                c.AddRegistry<GeneralRegistry>();
            });
        }

        public static IContainer Initialize()
        {
            return _container;
        }
    }
}