using System.Collections.Generic;

namespace Mt.CodePatterns.Adapter.Interfaces
{
   /// <summary>
   ///    Interface that represents adapter that converts object to another
   /// </summary>
   public interface ICollectionAdapter<TSource, TDestination>
      where TDestination : IMapFrom<TSource>
   {
      IEnumerable<TDestination> Adapt(IEnumerable<TSource> source);
   }
}