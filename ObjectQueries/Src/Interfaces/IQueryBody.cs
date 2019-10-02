namespace Mt.CodePatterns.ObjectQueries.Interfaces
{
   internal interface IQueryBody
   {
      string CanStart(object source);

      object Query(object source);
   }

   /// <summary>
   ///    Service that represents simple object query
   /// </summary>
   /// <typeparam name="TObject"></typeparam>
   /// <typeparam name="TResult"></typeparam>
   public interface IQueryBody<TQuery, TObject, TResult> : INeedInput<TObject>, IHaveOutput<TResult>
      where TQuery : IQuery<TObject, TResult>
   {
      string CanStart(TObject source);

      TResult Query(TObject source);
   }
}