using Mt.Demo.Lib.Interfaces;
using Mt.Demo.Lib.Services;
using StructureMap;

namespace Mt.Demo.Lib
{
   public class MasterRegistry : Registry
   {
      public MasterRegistry()
      {
         Scan(a =>
         {
            a.TheCallingAssembly();
            a.AddAllTypesOf(typeof(IObjectProvider<>));
         });

         For(typeof(IObjectProviderExt<,>)).Use(typeof(ObjectProviderExt<,>));
      }
   }
}