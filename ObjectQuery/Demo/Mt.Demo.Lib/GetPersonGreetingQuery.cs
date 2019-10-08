using System.Collections.Generic;
using Mt.CodePatterns.ObjectQueries.Interfaces;

namespace Mt.Demo.Lib
{
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
}