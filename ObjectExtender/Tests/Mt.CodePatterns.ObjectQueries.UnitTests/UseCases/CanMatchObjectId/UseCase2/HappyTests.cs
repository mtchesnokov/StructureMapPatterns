using Mt.CodePatterns.ObjectExtender.Interfaces;
using NUnit.Framework;

namespace Mt.CodePatterns.ObjectExtender.UnitTests.UseCases.CanMatchObjectId.UseCase2
{
   public class HappyTests : UnitTestBase<ICanMatchObjectId<int, FakeObject>>
   {
      [Test]
      [TestCase(1, true)]
      [TestCase(3, false)]
      public void External_Object(int objectId, bool expectedResult)
      {
         //arrange
         var obj = new FakeObject {UniqueNumber = 1};

         //act
         var actualResult = SUT.IsMatch(objectId, obj);

         //assert
         Assert.AreEqual(expectedResult, actualResult);
      }
   }
}