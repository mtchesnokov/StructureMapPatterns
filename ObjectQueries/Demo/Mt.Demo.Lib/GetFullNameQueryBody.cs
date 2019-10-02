using Mt.CodePatterns.ObjectQueries.Interfaces;
using Mt.CodePatterns.ObjectQueries.Interfaces.Helpers;
using Mt.CodePatterns.ObjectQueries.Services;

namespace Mt.Demo.Lib
{
   public class GetFullNameQuery : IQuery<Person, string>
   {
   }

   public class GetFullNameQueryBody : QueryBodyBase<GetFullNameQuery, Person, string>
   {
      #region ctor

      public GetFullNameQueryBody(IAppLogService appLogService) : base(appLogService)
      {
      }

      #endregion

      public override string CanStart(Person source)
      {
         if (string.IsNullOrEmpty(source.FirstName) || string.IsNullOrEmpty(source.LastName))
         {
            return "Both first name and last name should be specified";
         }

         return string.Empty;
      }

      protected override string QueryImpl(Person source)
      {
         return $"{source.FirstName} {source.LastName}";
      }
   }
}