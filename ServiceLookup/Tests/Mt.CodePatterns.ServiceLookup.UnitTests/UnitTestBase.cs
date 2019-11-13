using NUnit.Framework;
using StructureMap;

namespace Mt.CodePatterns.ServiceLookup.UnitTests
{
   /// <summary>
   /// Base class for all unit tests
   /// </summary>
   [TestFixture]
   public abstract class UnitTestBase
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
   }

   /// <summary>
   /// Handy class to simplify writing new unit tests
   /// </summary>
   /// <typeparam name="TSUT">Type of system under test</typeparam>
   public abstract class UnitTestBase<TSUT> : UnitTestBase
   {
      protected TSUT SUT => Container.GetInstance<TSUT>();
   }
}