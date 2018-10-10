using AL.Events.Common.Logger;
using StructureMap;

namespace AL.Events.Common.Dependencies
{
    public class CommonRegistry : Registry
    {
        public CommonRegistry()
        {
            For<ICustomLogger>().Use<CustomLogger>();
        }
    }
}
