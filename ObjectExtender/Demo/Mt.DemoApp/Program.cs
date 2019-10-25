using Mt.Demo.Lib.Domain;
using Mt.Demo.Lib.Interfaces;
using StructureMap;

namespace ConsoleApp1
{
   internal class Program
   {
      private static void Main(string[] args)
      {
         using (var container = CreateContainer())
         {
            TryOwnObjects(container);

            TryExtendedObjects(container);
         }
      }

      private static void TryOwnObjects(IContainer container)
      {
         IObjectProviderExt<int, OwnPerson> provider = container.GetInstance<IObjectProviderExt<int, OwnPerson>>();
         int objectId = 1;
         OwnPerson obj = provider.GetById(objectId);
         obj.Print();
      }

      private static void TryExtendedObjects(IContainer container)
      {
         IObjectProviderExt<int, ThirdPartyPerson> provider = container.GetInstance<IObjectProviderExt<int, ThirdPartyPerson>>();
         int objectId = 1;
         ThirdPartyPerson obj = provider.GetById(objectId);
         obj.Print();
      }

      private static IContainer CreateContainer()
      {
         return new Container(cfg =>
         {
            cfg.Scan(s =>
            {
               s.AssembliesAndExecutablesFromApplicationBaseDirectory();
               s.LookForRegistries();
            });
         });
      }
   }
}