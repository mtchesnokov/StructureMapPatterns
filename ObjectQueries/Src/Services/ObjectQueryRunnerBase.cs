using System;
using Mt.CodePatterns.ObjectQueries.Interfaces;

namespace Mt.CodePatterns.ObjectQueries.Services
{
   /// <summary>
   ///    Basic implementation of <see cref="IObjectQueryRunner{TObjectQueryType, TObject,TResult}" />
   /// </summary>
   /// <typeparam name="TObject"></typeparam>
   /// <typeparam name="TResult"></typeparam>
   /// <typeparam name="TObjectQueryType"></typeparam>
   public abstract class ObjectQueryRunnerBase<TObjectQueryType, TObject, TResult> : IObjectQueryRunner<TObjectQueryType, TObject, TResult>, IObjectQueryRunner<TObject, TResult>
      where TObjectQueryType : IObjectQueryType
   {
      private readonly IAppLogService _appLogService;

      #region ctor

      protected ObjectQueryRunnerBase(IAppLogService appLogService)
      {
         _appLogService = appLogService;
      }

      #endregion

      public TResult Query(TObject source)
      {
         if (source == null)
         {
            throw new ArgumentNullException(nameof(source));
         }

         var eventName = "Running query of object";
         var eventData = new {QueryType = typeof(TObjectQueryType), ObjectType = typeof(TObject)};

         TResult result;

         try
         {
            _appLogService.LogInfo($"Start {eventName}", eventData);

            result = QueryImpl(source);

            _appLogService.LogInfo($"Finished {eventName}", eventData);
         }
         catch (Exception e)
         {
            _appLogService.LogError(eventName, e, eventData);

            throw;
         }

         return result;
      }

      protected abstract TResult QueryImpl(TObject source);
   }
}