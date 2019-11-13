using Mt.CodePatterns.Adapter.Interfaces;

namespace Mt.CodePatterns.Adapter.UnitTests.UseCases.Adapter.UseCase3
{
   public class FakeSource
   {
      public string Text { get; set; }
   }

   public class FakeDestination : IMapFrom<FakeSource>
   {
      public string Text { get; set; }
   }

   public class CustomAdapter : IAdapter<FakeSource, FakeDestination>
   {
      public FakeDestination Adapt(FakeSource source)
      {
         return new FakeDestination {Text = $"#{source.Text}"};
      }
   }
}