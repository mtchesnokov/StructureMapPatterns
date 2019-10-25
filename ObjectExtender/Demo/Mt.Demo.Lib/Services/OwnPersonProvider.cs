using System.Collections.Generic;
using Mt.Demo.Lib.Domain;
using Mt.Demo.Lib.Interfaces;

namespace Mt.Demo.Lib.Services
{
   public class OwnPersonProvider : IObjectProvider<OwnPerson>
   {
      public IEnumerable<OwnPerson> GetAll()
      {
         return new[]
         {
            new OwnPerson {Id = 1, Name = "A"},
            new OwnPerson {Id = 2, Name = "B"},
            new OwnPerson {Id = 3, Name = "C"}
         };
      }
   }
}