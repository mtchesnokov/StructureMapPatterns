namespace Mt.CodePatterns.ObjectQueries.Interfaces
{
   /// <summary>
   ///    Service that represents simple object query
   /// </summary>
   public interface IQueryRuntime
   {
      TResult Query<TQuery, TObject, TResult>(TObject source) where TQuery : IQuery<TObject, TResult>;
   }
}