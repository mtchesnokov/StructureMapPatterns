using System;
using Mt.CodePatterns.Adapter.Interfaces;
using NUnit.Framework;

namespace Mt.CodePatterns.Adapter.UnitTests.UseCases.Adapter.UseCase2
{
   public class UnhappyTests : UnitTestBase<IAdapter<FakeSource, FakeDestination>>
   {
      [Test]
      public void Source_Null()
      {
         //arrange
         FakeSource source = null;

         //act+assert
         Assert.Throws<ArgumentNullException>(() => SUT.Adapt(source));
      }
   }
}