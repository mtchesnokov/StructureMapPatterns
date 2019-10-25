using Mt.CodePatterns.ObjectExtender.Interfaces;
using NUnit.Framework;

namespace Mt.CodePatterns.ObjectExtender.UnitTests.UseCases.CanMatchObjectId.UseCase1
{
   public class HappyTests : UnitTestBase<ICanMatchObjectId<int, FakeObject>>
   {
      [Test]
      [TestCase(1, true)]
      [TestCase(3, false)]
      public void Object_Has_Id(int objectId, bool expectedResult)
      {
         //arrange
         var obj = new FakeObject {Id = 1};

         //act
         var actualResult = SUT.IsMatch(objectId, obj);

         //assert
         Assert.AreEqual(expectedResult, actualResult);
      }
   }
}