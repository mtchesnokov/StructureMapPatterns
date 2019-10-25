using Mt.CodePatterns.ObjectExtender.Interfaces;

namespace Mt.CodePatterns.ObjectExtender.UnitTests.UseCases.CanMatchObjectId.UseCase2
{
   public class FakeObject
   {
      public int UniqueNumber { get; set; }
   }

   public class FakeObjectExtender : IKnowObjectId<FakeObject, int>
   {
      public int GetId(FakeObject obj)
      {
         return obj.UniqueNumber;
      }
   }
}