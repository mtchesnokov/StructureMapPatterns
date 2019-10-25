using Mt.CodePatterns.ObjectExtender.Interfaces;

namespace Mt.CodePatterns.ObjectExtender.UnitTests.UseCases.CanMatchObjectId.UseCase1
{
   public class FakeObject : IHaveId<int>
   {
      public int Id { get; set; }
   }
}