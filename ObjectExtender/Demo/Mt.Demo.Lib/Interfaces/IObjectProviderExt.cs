using System.Collections.Generic;

namespace Mt.Demo.Lib.Interfaces
{
   public interface IObjectProviderExt<TObjectId, TObject>
   {
      IEnumerable<TObject> GetAll();

      TObject GetById(TObjectId id);
   }
}