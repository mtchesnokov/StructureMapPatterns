using System;

namespace Mt.CodePatterns.ServiceLookup.Domain.Exceptions
{
   public class OperationNotSupportedException : Exception
   {
      public OperationNotSupportedException()
         : base("Operation you have requested cannot be performed. No service registered for requested service type")
      {
      }

      public Type MessageType { get; set; }
   }
}