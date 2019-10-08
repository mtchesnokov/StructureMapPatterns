using System;
using Mt.CodePatterns.ObjectQueries.Domain.Helpers;

namespace Mt.CodePatterns.ObjectQueries.Domain.Exceptions
{
   public class QueryCannotStartException : Exception
   {
      public string FailureReason { get; set; }

      public Type QueryType { get; set; }

      public Type ObjectType { get; set; }

      public Type ResultType { get; set; }

      public QueryCannotStartException()
         : base("Object query cannot start since precondition is violated")
      {
      }

      internal QueryCannotStartException(string failureReason, QueryDescriptor queryDescriptor)
         : base("Object query cannot start since precondition is violated")
      {
         FailureReason = failureReason;
         QueryType = queryDescriptor.QueryType;
         ObjectType = queryDescriptor.ObjectType;
         ResultType = queryDescriptor.ResultType;
      }
   }
}