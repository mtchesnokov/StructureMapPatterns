using System;
using System.Diagnostics;
using Mt.CodePatterns.ObjectQueries.Interfaces;
using Newtonsoft.Json;

namespace Mt.CodePatterns.ObjectQueries.Services
{
   public class AppLogService : IAppLogService
   {
      public void LogInfo(string message, object context)
      {
         Debug.WriteLine($"INFO {message} {JsonConvert.SerializeObject(context)}");
      }

      public void LogError(string message, Exception e, object context)
      {
         Debug.WriteLine($"ERROR {message} {JsonConvert.SerializeObject(context)}");
         Debug.WriteLine(JsonConvert.SerializeObject(e));
      }
   }
}