namespace Mt.CodePatterns.ObjectQueries.Interfaces
{
   /// <summary>
   /// Service that represents simple object query
   /// </summary>
   /// <typeparam name="TObject"></typeparam>
   /// <typeparam name="TResult"></typeparam>
   public interface IDataQuery<TObject, TResult>
   {
      TResult Query(TObject source);
   }
}