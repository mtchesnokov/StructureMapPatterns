using Mt.CodePatterns.Adapter.Interfaces;

namespace Mt.CodePatterns.Adapter.UnitTests.UseCases.Adapter.UseCase1
{
   public class FakeSource
   {
      public string Text { get; set; }
   }

   public class FakeDestination : IMapFrom<FakeSource>
   {
      public string Text { get; set; }
   }
}