using System;

namespace Mt.CodePatterns.ObjectQueries.Interfaces
{
   /// <summary>
   /// Service to send messages to app log
   /// </summary>
   public interface IAppLogService
   {
      void LogInfo(string message, object context = null);

      void LogError(string message, Exception e, object context = null);
   }
}