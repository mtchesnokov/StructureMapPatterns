using Mt.CodePatterns.ObjectQueries.Interfaces;
using Mt.CodePatterns.ObjectQueries.Services;

namespace Mt.Demo.Lib
{
   public class GetFullNameQuery : IObjectQueryType
   {
   }

   public class GetFullNameQueryRunner : ObjectQueryRunnerBase<GetFullNameQuery, Person, string>
   {
      protected override string QueryImpl(Person source)
      {
         return $"{source.FirstName} {source.LastName}";
      }

      #region ctor

      public GetFullNameQueryRunner(IAppLogService appLogService) : base(appLogService)
      {
      }

      #endregion
   }
}