using Mt.CodePatterns.ObjectQueries.Interfaces;

namespace Mt.Demo.Lib
{
   public class GetFullNameQuery : IDataQuery<Person, string>
   {
      public string Query(Person source)
      {
         return $"{source.FirstName} {source.LastName}";
      }
   }
}