using Mt.CodePatterns.ObjectQueries.Interfaces;
using StructureMap;

namespace Mt.CodePatterns.ObjectQueries.Services
{
   public class ObjectQueryRuntimeService<TObjectQueryType, TObject, TResult> : IObjectQueryRuntimeService<TObjectQueryType, TObject, TResult> 
      where TObjectQueryType : IObjectQueryType
   {
      private readonly IContainer _container;

      #region ctor

      public ObjectQueryRuntimeService(IContainer container)
      {
         _container = container;
      }

      #endregion

      public TResult Query(TObject source)
      {
         var objectQueryRunnerType = typeof(IObjectQueryRunner<,,>).MakeGenericType(typeof(TObjectQueryType), typeof(TObject), typeof(TResult));
         var service = (IObjectQueryRunner<TObject, TResult>) _container.GetInstance(objectQueryRunnerType);
         var result = service.Query(source);
         return result;
      }
   }
}