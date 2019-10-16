using StructureMap;

namespace Mt.CodePatterns.ObjectExtender
{
   public class MasterRegistry : Registry
   {
      public MasterRegistry()
      {
         Scan(s => { s.AssembliesAndExecutablesFromApplicationBaseDirectory(); });
      }
   }
}