using System;
using System.Collections.Generic;
using System.Linq;
using Mt.CodePatterns.ObjectQueries.Domain.Exceptions;
using Mt.CodePatterns.ObjectQueries.Domain.Objects;
using Mt.CodePatterns.ObjectQueries.Interfaces;
using Mt.CodePatterns.ObjectQueries.Interfaces.Helpers;
using StructureMap;

namespace Mt.CodePatterns.ObjectQueries.Services
{
   public class QueryRuntime : IQueryRuntime
   {
      private readonly IContainer _container;
      private readonly IQueryDescriptorProvider _queryDescriptorProvider;

      #region ctor

      public QueryRuntime(IContainer container)
      {
         _container = container;
         _queryDescriptorProvider = container.GetInstance<IQueryDescriptorProvider>();
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

      public IQueryResultset RunAllQueries<TObject>(TObject source)
      {
         var queryDescriptors = _queryDescriptorProvider.GetQueryDescriptors<TObject>();

         var list = new List<Tuple<Type, Type, object>>(queryDescriptors.Count());

         foreach (var queryDescriptor in queryDescriptors)
         {
            var queryBody = (IQueryBody) _container.GetInstance(queryDescriptor.QueryBodyType);

            var canStart = queryBody.CanStart(source);

            if (!string.IsNullOrEmpty(canStart))
            {
               throw new QueryCannotStartException(canStart, queryDescriptor);
            }

            var queryResult = queryBody.Query(source);

            list.Add(new Tuple<Type, Type, object>(queryDescriptor.QueryType, queryDescriptor.ResultType, queryResult));
         }

         return new QueryResultset(list);
      }

      public TResult RunComplexQuery<TComplexQuery, TObject, TResult>(TObject source) where TComplexQuery : IComplexQuery<TObject, TResult>
      {
         var complexQueryInstance = _container.GetInstance<TComplexQuery>();
         var subQueryTypes = complexQueryInstance.SubQueries.Select(x => x.GetType()).ToArray();
         var queryDescriptors = _queryDescriptorProvider.GetQueryDescriptors<TObject>(subQueryTypes);
         var queryBodyTypes = queryDescriptors.Select(x => x.QueryBodyType).ToArray();

         var list = new List<Tuple<Type, Type, object>>(queryBodyTypes.Length);

         foreach (var queryDescriptor in queryDescriptors)
         {
            var queryBody = (IQueryBody) _container.GetInstance(queryDescriptor.QueryBodyType);
            var canStart = queryBody.CanStart(source);

            if (!string.IsNullOrEmpty(canStart))
            {
               throw new QueryCannotStartException(canStart, queryDescriptor);
            }

            var result = queryBody.Query(source);
            list.Add(new Tuple<Type, Type, object>(queryDescriptor.QueryType, queryDescriptor.ResultType, result));
         }

         var queryResult = new QueryResultset(list);
         return complexQueryInstance.Execute(queryResult);
      }
   }
}