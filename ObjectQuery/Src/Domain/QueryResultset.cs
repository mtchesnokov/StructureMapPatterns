using System;
using System.Collections.Generic;
using System.Linq;
using Mt.CodePatterns.ObjectQueries.Interfaces;

namespace Mt.CodePatterns.ObjectQueries.Domain
{
   internal class QueryResultset : IQueryResultset
   {
      private readonly List<Tuple<Type, Type, object>> _list;

      internal QueryResultset(List<Tuple<Type, Type, object>> list)
      {
         _list = list;
      }

      public TResult GetQueryResult<TQuery, TResult>()
         where TQuery : IHaveResult<TResult>
      {
         var queryType = typeof(TQuery);
         var resultType = typeof(TResult);
         var result = _list.FirstOrDefault(x => x.Item1 == queryType && x.Item2 == resultType);

         if (result == null)
         {
            throw new ArgumentException("Query not found");
         }

         return (TResult) result.Item3;
      }
   }
}