using System.Collections.Generic;
using Mt.Demo.Lib.Domain;
using Mt.Demo.Lib.Interfaces;

namespace Mt.Demo.Lib.Services
{
   public class ThirdPartyPersonProvider : IObjectProvider<ThirdPartyPerson>
   {
      public IEnumerable<ThirdPartyPerson> GetAll()
      {
         return new[]
         {
            new ThirdPartyPerson {PersonNo = 1, Name = "'Ext_A"},
            new ThirdPartyPerson {PersonNo = 2, Name = "Ext_B"},
            new ThirdPartyPerson {PersonNo = 3, Name = "Ext_C"}
         };
      }
   }
}