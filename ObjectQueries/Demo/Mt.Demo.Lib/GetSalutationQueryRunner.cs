using Mt.CodePatterns.ObjectQueries.Interfaces;
using Mt.CodePatterns.ObjectQueries.Services;

namespace Mt.Demo.Lib
{
   public class GetSalutationQuery : IObjectQueryType
   {
   }

   public class GetSalutationQueryRunner : ObjectQueryRunnerBase<GetSalutationQuery, Person, string>
   {
      protected override string QueryImpl(Person source)
      {
         return source.Salutation;
      }

      #region ctor

      public GetSalutationQueryRunner(IAppLogService appLogService) : base(appLogService)
      {
      }

      #endregion
   }
}