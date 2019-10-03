using Mt.CodePatterns.ObjectQueries.Interfaces;
using Mt.CodePatterns.ObjectQueries.Interfaces.Helpers;
using Mt.CodePatterns.ObjectQueries.Services;
using Mt.CodePatterns.ObjectQueries.Services.Helpers;
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
            s.AddAllTypesOf(typeof(IQueryBody<,,>));
         });

         For<IAppLogService>().Use<AppLogService>();
         For(typeof(IQueryRuntime)).Use(typeof(QueryRuntime));
      }
   }
}