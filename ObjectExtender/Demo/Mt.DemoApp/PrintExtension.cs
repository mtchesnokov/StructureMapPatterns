using System;
using Newtonsoft.Json;

namespace ConsoleApp1
{
   public static class PrintExtension
   {
      public static void Print(this object obj)
      {
         Console.WriteLine(JsonConvert.SerializeObject(obj, Formatting.Indented));
      }
   }
}