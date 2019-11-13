using AutoMapper;
using Mt.CodePatterns.Adapter.Interfaces;
using Mt.CodePatterns.Adapter.Services;
using Mt.CodePatterns.Adapter.Services.Helpers;
using StructureMap;

namespace Mt.CodePatterns.Adapter
{
   public class MasterRegistry : Registry
   {
      public MasterRegistry()
      {
         Scan(s =>
         {
            s.AssembliesAndExecutablesFromApplicationBaseDirectory();
            s.AddAllTypesOf(typeof(IAdapter<,>));
            s.AddAllTypesOf(typeof(IMapFrom<>));
         });

         For<IConfigurationProvider>().Use<OwnMapperConfigurationProvider>();
         For(typeof(ICollectionAdapter<,>)).Use(typeof(DefaultCollectionAdapter<,>));
      }
   }
}