namespace Mt.CodePatterns.ObjectQueries.Interfaces
{
   /// <summary>
   ///    Service that represents simple object query
   /// </summary>
   /// <typeparam name="TObject"></typeparam>
   /// <typeparam name="TResult"></typeparam>
   public interface IQueryBody<TQuery, TObject, TResult>
      where TQuery : IQuery<TObject, TResult>
   {
      string CanStart(TObject source);

      TResult Query(TObject source);
   }
}