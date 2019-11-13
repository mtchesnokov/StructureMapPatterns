using Mt.CodePatterns.Adapter.Interfaces;

namespace ConsoleApp1.Services
{
   public class SourceObject2
   {
      public string Text { get; set; }
   }

   public class DestinationObject2 : IMapFrom<SourceObject2>
   {
      public string Text { get; set; }
   }

   public class CustomAdapter : IAdapter<SourceObject2, DestinationObject2>
   {
      public DestinationObject2 Adapt(SourceObject2 source)
      {
         return new DestinationObject2 {Text = "#" + source.Text};
      }
   }
}