using System;
using Mt.CodePatterns.ObjectQueries.Interfaces;
using Mt.CodePatterns.ObjectQueries.Interfaces.Helpers;

namespace Mt.CodePatterns.ObjectQueries.Services
{
   /// <summary>
   ///    Basic implementation of <see cref="IQueryBody{TQuery,TObject,TResult}" />
   /// </summary>
   /// <typeparam name="TObject"></typeparam>
   /// <typeparam name="TResult"></typeparam>
   /// <typeparam name="TQuery"></typeparam>
   public abstract class QueryBodyBase<TQuery, TObject, TResult> : IQueryBody<TQuery, TObject, TResult>
      where TQuery : IQuery<TObject, TResult>
   {
      private readonly IAppLogService _appLogService;

      #region ctor

      protected QueryBodyBase(IAppLogService appLogService)
      {
         _appLogService = appLogService;
      }

      #endregion

      public virtual string CanStart(TObject source)
      {
         return string.Empty;
      }

      public TResult Query(TObject source)
      {
         if (source == null)
         {
            throw new ArgumentNullException(nameof(source));
         }

         var logEventName = "Running object query";
         var logData = new {QueryType = typeof(TQuery), ObjectType = typeof(TObject)};

         TResult result;

         try
         {
            _appLogService.LogInfo($"Start {logEventName}", logData);

            result = QueryImpl(source);

            _appLogService.LogInfo($"Finished {logEventName}", logData);
         }
         catch (Exception e)
         {
            _appLogService.LogError(logEventName, e, logData);

            throw;
         }

         return result;
      }

      protected abstract TResult QueryImpl(TObject source);
   }
}