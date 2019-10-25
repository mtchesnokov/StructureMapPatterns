using Mt.CodePatterns.ObjectExtender.Interfaces;
using Mt.Demo.Lib.Domain;

namespace Mt.Demo.Lib.Services
{
   public class ThirdPartyPersonExtender : IKnowObjectId<ThirdPartyPerson, int>
   {
      public int GetId(ThirdPartyPerson obj)
      {
         return obj.PersonNo;
      }
   }
}