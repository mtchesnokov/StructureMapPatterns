using Mt.CodePatterns.ObjectExtender.Interfaces;

namespace Mt.Demo.Lib.Domain
{
   public class OwnPerson : IHaveId<int>
   {
      public int Id { get; set; }

      public string Name { get; set; }
   }
}