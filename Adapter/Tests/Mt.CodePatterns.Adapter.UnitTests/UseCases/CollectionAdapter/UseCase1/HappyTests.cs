using System.Linq;
using Mt.CodePatterns.Adapter.Interfaces;
using NUnit.Framework;

namespace Mt.CodePatterns.Adapter.UnitTests.UseCases.CollectionAdapter.UseCase1
{
   public class HappyTests : UnitTestBase<ICollectionAdapter<FakeSource, FakeDestination>>
   {
      [Test]
      public void Happy_Case()
      {
         //arrange
         var source1 = new FakeSource {Text = "A"};
         var source2 = new FakeSource {Text = "B"};
         var source3 = new FakeSource {Text = "C"};
         FakeSource[] sources = {source1, source2, source3};

         //act
         var destination = SUT.Adapt(sources);

         //assert
         CollectionAssert.AreEqual(new[] {"A", "B", "C"}, destination.Select(x => x.Text));
      }
   }
}