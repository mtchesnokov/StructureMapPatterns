using NUnit.Framework;
using StructureMap;

namespace Mt.CodePatterns.ObjectExtender.UnitTests
{
   [TestFixture]
   public abstract class UnitTestBase<TSUT>
   {
      protected IContainer Container { get; set; }

      [SetUp]
      public void SetUp()
      {
         Container = new Container(cfg => cfg.Scan(s =>
         {
            s.AssembliesAndExecutablesFromApplicationBaseDirectory();
            s.LookForRegistries();
         }));
      }

      [TearDown]
      public void TearDown()
      {
         Container?.Dispose();
      }

      protected TSUT SUT => Container.GetInstance<TSUT>();
   }
}