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

            RunSpecificQuery(queryRuntime, person);

            RunAllKnownQueries(queryRuntime, person);

            RunComplexQuery(queryRuntime, person);
         }
      }

      private static void RunSpecificQuery(IQueryRuntime queryRuntime, Person person)
      {
         Console.WriteLine("Running specific query...");

         var salutation = queryRuntime.RunQuery<GetSalutationQuery, Person, string>(person);

         Console.WriteLine($"Salutation: {salutation}");
      }

      private static void RunAllKnownQueries(IQueryRuntime queryRuntime, Person person)
      {
         Console.WriteLine("\nRunning all known queries....");

         IQueryResultset queryResultset = queryRuntime.RunAllQueries(person);

         string salutation = queryResultset.GetQueryResult<GetSalutationQuery, string>();

         Console.WriteLine($"Salutation : {salutation}");

         string fullName = queryResultset.GetQueryResult<GetFullNameQuery, string>();

         Console.WriteLine($"Full name: {fullName}");
      }

      private static void RunComplexQuery(IQueryRuntime queryRuntime, Person person)
      {
         Console.WriteLine("Running complex query...");

         string greeting = queryRuntime.RunComplexQuery<GetPersonGreetingQuery, Person, string>(person);

         Console.WriteLine($"Greeting: {greeting}");
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