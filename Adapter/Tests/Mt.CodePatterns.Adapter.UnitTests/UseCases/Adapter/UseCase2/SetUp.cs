using Mt.CodePatterns.Adapter.Interfaces;

namespace Mt.CodePatterns.Adapter.UnitTests.UseCases.Adapter.UseCase2
{
   public class FakeSource 
   {
   }

   public class FakeDestination : IMapFrom<FakeSource>
   {
   }
}