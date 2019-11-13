using System;
using AutoMapper;
using StructureMap;

namespace Mt.CodePatterns.Adapter.Services.Helpers
{
   internal class OwnMapperConfigurationProvider : MapperConfiguration
   {
      [DefaultConstructor]
      public OwnMapperConfigurationProvider(IContainer container) : base(new OwnMapperConfigurationExpression(container))
      {
      }

      public OwnMapperConfigurationProvider(Action<IMapperConfigurationExpression> configure) : base(configure)
      {
      }
   }
}