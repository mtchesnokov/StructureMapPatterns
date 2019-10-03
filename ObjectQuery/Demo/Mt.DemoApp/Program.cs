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

            RunSingleQuery(queryRuntime, person);

            RunAllQueries(queryRuntime, person);
         }
      }

      private static void RunAllQueries(IQueryRuntime queryRuntime, Person person)
      {
         Console.WriteLine("\nRunning all registered queries....");

         var queryResultset = queryRuntime.RunAllQueries(person);

         var salutation = queryResultset.GetQueryResult<GetSalutationQuery, string>();

         Console.WriteLine($"Salutation : {salutation}");

         var fullName = queryResultset.GetQueryResult<GetFullNameQuery, string>();

         Console.WriteLine($"Full name: {fullName}");
      }

      private static void RunSingleQuery(IQueryRuntime queryRuntime, Person person)
      {
         Console.WriteLine("Running specific query...");

         var salutation = queryRuntime.RunQuery<GetSalutationQuery, Person, string>(person);

         Console.WriteLine($"Salutation: {salutation}");
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