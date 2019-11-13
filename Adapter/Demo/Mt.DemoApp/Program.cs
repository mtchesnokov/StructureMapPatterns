using System;
using ConsoleApp1.Services;
using Mt.CodePatterns.Adapter.Interfaces;
using StructureMap;

namespace ConsoleApp1
{
   internal class Program
   {
      private static void Main(string[] args)
      {
         using (var container = CreateContainer())
         {
            UsingDefaultAdapter(container);

            UsingCustomAdapter(container);
         }
      }

      private static void UsingDefaultAdapter(IContainer container)
      {
         var adapter = container.GetInstance<IAdapter<SourceObject1, DestinationObject1>>();
         var source = new SourceObject1 {Text = "Hello"};
         var destination = adapter.Adapt(source);
         Console.WriteLine(destination.Text);
      }

      private static void UsingCustomAdapter(IContainer container)
      {
         var adapter = container.GetInstance<IAdapter<SourceObject2, DestinationObject2>>();
         var source = new SourceObject2 { Text = "Hello" };
         var destination = adapter.Adapt(source);
         Console.WriteLine(destination.Text);
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