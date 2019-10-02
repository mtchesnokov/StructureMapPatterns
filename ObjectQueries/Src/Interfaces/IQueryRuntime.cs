using Mt.CodePatterns.ObjectQueries.Domain;

namespace Mt.CodePatterns.ObjectQueries.Interfaces
{
   /// <summary>
   ///    Service that executes the query/quries
   /// </summary>
   public interface IQueryRuntime
   {
      TResult RunQuery<TQuery, TObject, TResult>(TObject source) where TQuery : IQuery<TObject, TResult>;

      QueryResultset RunAllQueries<TObject>(TObject source);
   }
}