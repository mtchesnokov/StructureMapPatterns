using Mt.CodePatterns.ObjectQueries.Interfaces;
using Mt.CodePatterns.ObjectQueries.Interfaces.Helpers;
using Mt.CodePatterns.ObjectQueries.Services;

namespace Mt.Demo.Lib
{
   public class GetSalutationQuery : IQuery<Person, string>
   {
   }

   public class GetSalutationQueryBody : QueryBodyBase<GetSalutationQuery, Person, string>
   {
      #region ctor

      public GetSalutationQueryBody(IAppLogService appLogService) : base(appLogService)
      {
      }

      #endregion

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
}