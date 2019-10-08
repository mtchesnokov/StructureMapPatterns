using System.Collections.Generic;

namespace Mt.CodePatterns.ObjectQueries.Interfaces
{
   public interface IComplexQuery<TSource, TResult> : INeedInput<TSource>, IHaveResult<TResult>
   {
      IEnumerable<INeedInput<TSource>> SubQueries { get; }

      TResult Execute(IQueryResultset queryResultset);
   }
}