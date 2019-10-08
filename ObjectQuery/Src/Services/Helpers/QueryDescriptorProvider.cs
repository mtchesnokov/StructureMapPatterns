using System;
using System.Collections.Generic;
using System.Linq;
using Mt.CodePatterns.ObjectQueries.Domain.Helpers;
using Mt.CodePatterns.ObjectQueries.Interfaces;
using Mt.CodePatterns.ObjectQueries.Interfaces.Helpers;
using StructureMap;

namespace Mt.CodePatterns.ObjectQueries.Services.Helpers
{
   /// <summary>
   ///    Implementation of <see cref="IQueryDescriptorProvider" />
   /// </summary>
   internal class QueryDescriptorProvider : IQueryDescriptorProvider
   {
      private readonly IContainer _container;

      #region ctor

      public QueryDescriptorProvider(IContainer container)
      {
         _container = container;
      }

      #endregion

      public IEnumerable<QueryDescriptor> GetQueryDescriptors<TObject>(params Type[] queryTypes)
      {
         var result = new List<QueryDescriptor>();

         var queryBodyTypes = _container.Model.PluginTypes
            .Where(t => t.PluginType.IsGenericType && t.PluginType.GetGenericTypeDefinition() == typeof(IQueryBody<,,>))
            .Where(t => typeof(INeedInput<TObject>).IsAssignableFrom(t.PluginType))
            .Select(x => x.PluginType).ToArray();

         foreach (var queryBodyType in queryBodyTypes)
         {
            var queryType = queryBodyType.GenericTypeArguments[0];
            var objectType = queryBodyType.GenericTypeArguments[1];
            var resultType = queryBodyType.GenericTypeArguments[2];

            if (queryTypes.Any() && !queryTypes.Contains(queryType))
            {
               continue;
            }

            var queryBodyDescriptor = new QueryDescriptor
            {
               QueryBodyType = queryBodyType,
               QueryType = queryType,
               ObjectType = objectType,
               ResultType = resultType
            };

            result.Add(queryBodyDescriptor);
         }

         return result;
      }
   }
}