using System.Collections.Generic;

namespace Mt.Demo.Lib.Interfaces
{
   public interface IObjectProvider<TObject>
   {
      IEnumerable<TObject> GetAll();
   }
}