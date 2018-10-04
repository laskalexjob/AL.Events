using AL.Events.Business.Dependencies;
using AL.Events.Common.Dependencies;
using AL.Events.DAL.Dependencies;
using StructureMap;

namespace AL.Events.Dependency
{
    public class GeneralRegistry : Registry
    {
        public GeneralRegistry()
        {
            Scan(s =>
            {
                s.AssemblyContainingType<BusinessRegistry>();
                s.AssemblyContainingType<CommonRegistry>();
                s.AssemblyContainingType<DALRegistry>();
                s.LookForRegistries();
            });
        }
    }
}
