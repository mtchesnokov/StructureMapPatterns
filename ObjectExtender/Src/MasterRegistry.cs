using Mt.CodePatterns.ObjectExtender.Interfaces;
using Mt.CodePatterns.ObjectExtender.Services;
using StructureMap;

namespace Mt.CodePatterns.ObjectExtender
{
   public class MasterRegistry : Registry
   {
      public MasterRegistry()
      {
         Scan(s =>
         {
            s.AssembliesAndExecutablesFromApplicationBaseDirectory();
            s.AddAllTypesOf(typeof(IHaveId<>));
            s.AddAllTypesOf(typeof(IKnowObjectId<,>));
         });

         For(typeof(ICanMatchObjectId<,>)).Use(typeof(CanMatchObjectId<,>));
      }
   }
}