using System;

namespace Mt.CodePatterns.ObjectExtender.Domain.Exceptions
{
   public class OperationNotSupportedException : Exception
   {
      public OperationNotSupportedException()
         : base("Operation you have requested cannot be performed. Object's id cannot be inferred for given object type")
      {
      }

      public string ObjectType { get; set; }

      public string ObjectIdType { get; set; }
   }
}