using System;

namespace Mt.Demo.Lib.Domain
{
   public class ObjectNotFoundException : Exception
   {
      public string ObjectType { get; set; }

      public string KeyType { get; set; }

      public object Key { get; set; }

      public ObjectNotFoundException()
         : base("Object you have requested cannot be found")
      {
      }
   }
}