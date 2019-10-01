using Mt.CodePatterns.ObjectQueries.Interfaces;

namespace Mt.Demo.Lib
{
   public class GetSalutationQuery : IDataQuery<Person, string>
   {
      public string Query(Person source)
      {
         return source.Salutation;
      }
   }
}