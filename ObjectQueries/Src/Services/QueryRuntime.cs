using System;
using System.Collections.Generic;
using System.Linq;
using Mt.CodePatterns.ObjectQueries.Domain;
using Mt.CodePatterns.ObjectQueries.Interfaces;
using StructureMap;

namespace Mt.CodePatterns.ObjectQueries.Services
{
   public class QueryRuntime : IQueryRuntime
   {
      private readonly IContainer _container;

      #region ctor

      public QueryRuntime(IContainer container)
      {
         _container = container;
      }

      #endregion

      public TResult RunQuery<TQuery, TObject, TResult>(TObject source) where TQuery : IQuery<TObject, TResult>
      {
         var queryBody = _container.GetInstance<IQueryBody<TQuery, TObject, TResult>>();

         var canStart = queryBody.CanStart(source);

         if (!string.IsNullOrEmpty(canStart))
         {
            throw new QueryCannotStartException
            {
               FailureReason = canStart,
               QueryType = typeof(TQuery),
               ObjectType = typeof(TObject),
               ResultType = typeof(TResult)
            };
         }

         var result = queryBody.Query(source);

         return result;
      }

      public QueryResultset RunAllQueries<TObject>(TObject source)
      {
         var queryBodyTypes = _container.Model.PluginTypes
            .Where(t => t.PluginType.IsGenericType && t.PluginType.GetGenericTypeDefinition() == typeof(IQueryBody<,,>))
            .Where(t => typeof(INeedInput<TObject>).IsAssignableFrom(t.PluginType))
            .Select(x => x.PluginType).ToArray();

         var list = new List<Tuple<Type, Type, object>>(queryBodyTypes.Length);

         foreach (var queryBodyType in queryBodyTypes)
         {
            var queryType = queryBodyType.GenericTypeArguments[0];
            var resultType = queryBodyType.GenericTypeArguments[2];

            var queryBody = _container.GetInstance(queryBodyType) as IQueryBody;

            var canStart = queryBody.CanStart(source);

            if (!string.IsNullOrEmpty(canStart))
            {
               throw new QueryCannotStartException
               {
                  FailureReason = canStart,
                  QueryType = queryType,
                  ObjectType = typeof(TObject),
                  ResultType = resultType
               };
            }

            var result = queryBody.Query(source);
            list.Add(new Tuple<Type, Type, object>(queryType, resultType, result));
         }

         return new QueryResultset(list);
      }
   }
}