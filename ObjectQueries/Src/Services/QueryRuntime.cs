using Mt.CodePatterns.ObjectQueries.Interfaces;
using StructureMap;

namespace Mt.CodePatterns.ObjectQueries.Services
{
   public class QueryRuntime : IQueryRuntime
   {
      private readonly IContainer _container;

      #region ctor

      public QueryRuntime(IContainer container)
      {
         _container = container;
      }

      #endregion

      public TResult Query<TQuery, TObject, TResult>(TObject source) where TQuery : IQuery<TObject, TResult>
      {
         var queryBody = _container.GetInstance<IQueryBody<TQuery, TObject, TResult>>();

         var canStart = queryBody.CanStart(source);

         if (!string.IsNullOrEmpty(canStart))
         {
            throw new QueryCannotStartException
            {
               FailureReason = canStart,
               QueryType = typeof(TQuery),
               ObjectType = typeof(TObject),
               ResultType = typeof(TResult)
            };
         }

         var result = queryBody.Query(source);

         return result;
      }
   }
}