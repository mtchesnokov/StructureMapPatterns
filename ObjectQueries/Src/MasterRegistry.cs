using Mt.CodePatterns.ObjectQueries.Interfaces;
using Mt.CodePatterns.ObjectQueries.Services;
using StructureMap;

namespace Mt.CodePatterns.ObjectQueries
{
   public class MasterRegistry : Registry
   {
      public MasterRegistry()
      {
         Scan(s =>
         {
            s.AssembliesAndExecutablesFromApplicationBaseDirectory();
            s.AddAllTypesOf(typeof(IObjectQueryRunner<,,>));
         });

         For<IAppLogService>().Use<AppLogService>();
         For(typeof(IObjectQueryRuntimeService<,,>)).Use(typeof(ObjectQueryRuntimeService<,,>));
      }
   }
}