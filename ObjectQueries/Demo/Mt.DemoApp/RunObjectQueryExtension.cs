using Mt.CodePatterns.ObjectQueries.Interfaces;
using StructureMap;

namespace ConsoleApp1
{
   /// <summary>
   /// Helper class to improve readability
   /// </summary>
   public static class RunObjectQueryExtension
   {
      public static TResult RunObjectQuery<TObjectQuery, TObject, TResult>(this IContainer container, TObject source) 
         where TObjectQuery : IObjectQueryType
      {
         return container.GetInstance<IObjectQueryRuntimeService<TObjectQuery, TObject, TResult>>().Query(source);
      }
   }
}