using Mt.CodePatterns.ObjectExtender.Domain.Exceptions;
using Mt.CodePatterns.ObjectExtender.Interfaces;
using Mt.CodePatterns.ObjectExtender.UnitTests.TestExtensions;
using NUnit.Framework;

namespace Mt.CodePatterns.ObjectExtender.UnitTests.UseCases.CanMatchObjectId.UseCase3
{
   public class UnhappyTests : UnitTestBase<ICanMatchObjectId<int, FakeObject>>
   {
      [Test]
      public void Id_Cannot_Be_Inferred()
      {
         //arrange
         var obj = new FakeObject {UniqueNumber = 1};

         //act+assert
         var exception = Assert.Throws<OperationNotSupportedException>(() => SUT.IsMatch(1, obj));

         //print 
         this.Print(exception);
      }
   }
}