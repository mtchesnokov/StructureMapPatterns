using Mt.CodePatterns.Adapter.Interfaces;

namespace ConsoleApp1.Services
{
   public class SourceObject1
   {
      public string Text { get; set; }
   }

   public class DestinationObject1 : IMapFrom<SourceObject1>
   {
      public string Text { get; set; }
   }
}