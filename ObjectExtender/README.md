# Object Query

## Problem

We have an object instance (say of type 'Person'). That instance can be an object graph i.e. include accompaning child collections. 
We want to run computations on that object (say calculate person's display name, credit rating, etc). Each of those computations is an query that is run on that object (with possibility to use external data). 

## Requirements
* Each query is atomic and can be run independently from others
* Each query can be testible individually 
* Queries can be combined together to produce complex query scenarios 
* Each query can be re-used (multiple complex queries can call the same query)


## Implementation 
The implementation of that pattern include 2 logical parts: 
* Object query (actual worker part)
* Object query runtime (this manages execution, error logging and discovery)

## Code example

As an simple exammple, we will calculate Person's display name based on provided Person instance

```csharp
public class Person
{
   public string Salutation { get; set; }

   public string FirstName { get; set; }

   public string LastName { get; set; }
}
```
Each query has header and body:

```csharp
public class GetSalutationQuery : IQuery<Person, string>
{
}

public class GetSalutationQueryBody : QueryBodyBase<GetSalutationQuery, Person, string>
{
   public override string CanStart(Person source)
   {
      if (string.IsNullOrEmpty(source.Salutation))
      {
         return "Salutation cannot be empty";
      }

      return string.Empty;
   }

   protected override string QueryImpl(Person source)
   {
      return source.Salutation;
   }
}
```

Run individual query:

```csharp
IQueryRuntime queryRuntime = container.GetInstance<IQueryRuntime>();

string salutation = queryRuntime.RunQuery<GetSalutationQuery, Person, string>(person)

Console.WriteLine($"Salutation : {salutation}");

```

Run all known queries on Person (queries get auto discovered):

```csharp
IQueryRuntime queryRuntime = container.GetInstance<IQueryRuntime>();

IQueryResultset queryResultset = queryRuntime.RunAllQueries(person);

string salutation = queryResultset.GetQueryResult<GetSalutationQuery, string>();

Console.WriteLine($"Salutation : {salutation}");

```

Run complex query on Person:

```csharp
   public class GetPersonGreetingQuery : IComplexQuery<Person, string>
   {
      public IEnumerable<INeedInput<Person>> SubQueries
      {
         get
         {
            yield return new GetSalutationQuery();
            yield return new GetFullNameQuery();
         }
      }

      public string Execute(IQueryResultset queryResultset)
      {
         var salutation = queryResultset.GetQueryResult<GetSalutationQuery, string>();
         var fullName = queryResultset.GetQueryResult<GetFullNameQuery, string>();
         return $"{salutation} {fullName}";
      }
   }


         Console.WriteLine("Running complex query...");

         string greeting = queryRuntime.RunComplexQuery<GetPersonGreetingQuery, Person, string>(person);

         Console.WriteLine($"Greeting: {greeting}");

```
