using System;

namespace Mt.CodePatterns.ObjectQueries.Services
{
   public class QueryCannotStartException : Exception
   {
      public string FailureReason { get; set; }

      public Type QueryType { get; set; }

      public Type ObjectType { get; set; }

      public Type ResultType { get; set; }

      public QueryCannotStartException() : base("Object query cannot start since precondition is violated")
      {
      }
   }
}