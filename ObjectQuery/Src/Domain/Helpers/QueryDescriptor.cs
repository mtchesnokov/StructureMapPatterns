using System;

namespace Mt.CodePatterns.ObjectQueries.Domain.Helpers
{
   /// <summary>
   /// Help class that describes concrete query body implementation
   /// </summary>
   internal class QueryDescriptor
   {
      public Type QueryBodyType { get; set; }

      public Type QueryType { get; set; }

      public Type ObjectType { get; set; }

      public Type ResultType { get; set; }
   }
}