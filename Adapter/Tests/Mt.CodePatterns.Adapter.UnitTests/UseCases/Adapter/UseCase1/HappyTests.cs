using Mt.CodePatterns.Adapter.Interfaces;
using NUnit.Framework;

namespace Mt.CodePatterns.Adapter.UnitTests.UseCases.Adapter.UseCase1
{
   public class HappyTests : UnitTestBase<IAdapter<FakeSource, FakeDestination>>
   {
      [Test]
      public void Happy_Case()
      {
         //arrange
         var source = new FakeSource {Text = "Hello"};

         //act
         var destination = SUT.Adapt(source);

         //assert

         Assert.AreEqual("Hello", destination.Text);
      }
   }
}