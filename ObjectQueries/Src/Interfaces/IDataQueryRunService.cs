namespace Mt.CodePatterns.ObjectQueries.Interfaces
{
   /// <summary>
   ///    Service that represents simple object query
   /// </summary>
   /// <typeparam name="TObject"></typeparam>
   /// <typeparam name="TResult"></typeparam>
   public interface IDataQueryRunService<TDataQuery, TObject, TResult>
      where TDataQuery : IDataQuery<TObject, TResult>
   {
      TResult Query(TObject source);
   }
}