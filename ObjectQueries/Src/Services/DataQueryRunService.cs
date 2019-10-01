using Mt.CodePatterns.ObjectQueries.Interfaces;
using StructureMap;

namespace Mt.CodePatterns.ObjectQueries.Services
{
   public class DataQueryRunService<TDataQuery, TObject, TResult> : IDataQueryRunService<TDataQuery, TObject, TResult> where TDataQuery : IDataQuery<TObject, TResult>
   {
      private readonly IContainer _container;

      #region ctor

      public DataQueryRunService(IContainer container)
      {
         _container = container;
      }

      #endregion

      public TResult Query(TObject source)
      {
         var service = (IDataQuery<TObject, TResult>) _container.GetInstance(typeof(TDataQuery));
         var result = service.Query(source);
         return result;
      }
   }
}