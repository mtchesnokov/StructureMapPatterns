using System.Linq;
using AutoMapper.Configuration;
using Mt.CodePatterns.Adapter.Interfaces;
using StructureMap;

namespace Mt.CodePatterns.Adapter.Services.Helpers
{
   internal class OwnMapperConfigurationExpression : MapperConfigurationExpression
   {
      public OwnMapperConfigurationExpression(IContainer container)
      {
         var model = container.Model;

         foreach (var instanceRef in model.AllInstances)
         {
            var pluginType = instanceRef.PluginType;

            if (pluginType.IsGenericType && pluginType.GetGenericTypeDefinition() == typeof(IMapFrom<>))
            {
               var destinationType = instanceRef.ReturnedType;
               var sourceType = pluginType.GetGenericArguments().First();
               CreateMap(sourceType, destinationType);
            }
         }
      }
   }
}