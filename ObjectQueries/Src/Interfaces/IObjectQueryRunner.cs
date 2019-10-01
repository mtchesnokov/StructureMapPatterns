namespace Mt.CodePatterns.ObjectQueries.Interfaces
{
   internal interface IObjectQueryRunner<TObject, TResult>
   {
      TResult Query(TObject source);
   }

   /// <summary>
   ///    Service that represents simple object query
   /// </summary>
   /// <typeparam name="TObject"></typeparam>
   /// <typeparam name="TResult"></typeparam>
   public interface IObjectQueryRunner<TObjectQueryType, TObject, TResult>
      where TObjectQueryType : IObjectQueryType
   {
      TResult Query(TObject source);
   }
}