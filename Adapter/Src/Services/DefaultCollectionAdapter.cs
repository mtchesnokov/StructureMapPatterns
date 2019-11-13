using System;
using System.Collections.Generic;
using System.Linq;
using Mt.CodePatterns.Adapter.Interfaces;

namespace Mt.CodePatterns.Adapter.Services
{
   /// <summary>
   ///    Basic implementation of <see cref="ICollectionAdapter{TSource,TDestination}" />
   /// </summary>
   public class DefaultCollectionAdapter<TSource, TDestination> : ICollectionAdapter<TSource, TDestination>
      where TDestination : IMapFrom<TSource>
   {
      private readonly IAdapter<TSource, TDestination> _singleAdapter;

      #region ctor

      public DefaultCollectionAdapter(IAdapter<TSource, TDestination> singleAdapter)
      {
         _singleAdapter = singleAdapter;
      }

      #endregion

      public IEnumerable<TDestination> Adapt(IEnumerable<TSource> source)
      {
         if (source == null)
         {
            throw new ArgumentNullException(nameof(source));
         }

         var result = new List<TDestination>(source.Count());

         foreach (var s in source)
         {
            var destination = _singleAdapter.Adapt(s);

            result.Add(destination);
         }

         return result;
      }
   }
}