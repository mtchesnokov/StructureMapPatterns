using System;
using Newtonsoft.Json;

namespace Mt.CodePatterns.ServiceLookup.UnitTests.TestExtensions
{
   /// <summary>
   /// Handy extension to print object to console
   /// </summary>
   public static class PrintExtension
   {
      public static void Print(this UnitTestBase test, object obj)
      {
         Console.WriteLine(JsonConvert.SerializeObject(obj, Formatting.Indented));
      }
   }
}