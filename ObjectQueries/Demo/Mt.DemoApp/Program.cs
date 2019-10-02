using System;
using Mt.CodePatterns.ObjectQueries.Interfaces;
using Mt.Demo.Lib;
using StructureMap;

namespace ConsoleApp1
{
   internal class Program
   {
      private static void Main(string[] args)
      {
         using (var container = CreateContainer())
         {
            var person = new Person
            {
               Salutation = "Mr",
               FirstName = "John",
               LastName = "Silver"
            };

            var queryRuntime = container.GetInstance<IQueryRuntime>();

            var salutation = queryRuntime.Query<GetSalutationQuery, Person, string>(person);

            Console.WriteLine(salutation);
         }
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