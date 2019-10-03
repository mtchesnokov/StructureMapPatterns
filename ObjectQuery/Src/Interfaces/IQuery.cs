namespace Mt.CodePatterns.ObjectQueries.Interfaces
{
   public interface IQuery<TSource, TResult> : INeedInput<TSource>, IHaveResult<TResult>
   {
   }
}