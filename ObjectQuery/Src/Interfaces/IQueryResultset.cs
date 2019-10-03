namespace Mt.CodePatterns.ObjectQueries.Interfaces
{
   public interface IQueryResultset
   {
      TResult GetQueryResult<TQuery, TResult>() where TQuery : IHaveResult<TResult>;
   }
}