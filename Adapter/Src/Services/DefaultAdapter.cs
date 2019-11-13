using System;
using AutoMapper;
using Mt.CodePatterns.Adapter.Interfaces;

namespace Mt.CodePatterns.Adapter.Services
{
   /// <summary>
   ///    Basic implementation of <see cref="IAdapter{TSource,TDestination}" />
   /// </summary>
   public class DefaultAdapter<TSource, TDestination> : IAdapter<TSource, TDestination> 
      where TDestination : IMapFrom<TSource>
   {
      private readonly Mapper _mapper;

      #region ctor

      public DefaultAdapter(Mapper mapper)
      {
         _mapper = mapper;
      }

      #endregion

      public TDestination Adapt(TSource source)
      {
         if (source == null)
         {
            throw new ArgumentNullException(nameof(source));
         }

         return _mapper.Map<TDestination>(source);
      }
   }
}