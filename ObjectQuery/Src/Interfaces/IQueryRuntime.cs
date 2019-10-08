namespace Mt.CodePatterns.ObjectQueries.Interfaces
{
   /// <summary>
   ///    Service that executes the query/quries
   /// </summary>
   public interface IQueryRuntime
   {
      TResult RunQuery<TQuery, TObject, TResult>(TObject source) where TQuery : IQuery<TObject, TResult>;

      IQueryResultset RunAllQueries<TObject>(TObject source);

      TResult RunComplexQuery<TComplexQuery, TObject, TResult>(TObject source) where TComplexQuery : IComplexQuery<TObject, TResult>;
   }
}