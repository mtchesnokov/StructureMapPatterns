using System.Collections.Generic;
using Mt.CodePatterns.ObjectExtender.Interfaces;
using Mt.Demo.Lib.Domain;
using Mt.Demo.Lib.Interfaces;

namespace Mt.Demo.Lib.Services
{
   public class ObjectProviderExt<TObjectId, TObject> : IObjectProviderExt<TObjectId, TObject> where TObject : class
   {
      private readonly IObjectProvider<TObject> _innerProvider;
      private readonly ICanMatchObjectId<TObjectId, TObject> _canMatchObjectId;

      #region ctor

      public ObjectProviderExt(IObjectProvider<TObject> innerProvider, ICanMatchObjectId<TObjectId, TObject> canMatchObjectId)
      {
         _innerProvider = innerProvider;
         _canMatchObjectId = canMatchObjectId;
      }

      #endregion

      public IEnumerable<TObject> GetAll()
      {
         return _innerProvider.GetAll();
      }

      public TObject GetById(TObjectId id)
      {
         var allObjects = _innerProvider.GetAll();

         foreach (var o in allObjects)
         {
            var isMatch = _canMatchObjectId.IsMatch(id, o);

            if (isMatch)
            {
               return o;
            }
         }

         throw new ObjectNotFoundException(){ObjectType = typeof(TObject).FullName, KeyType = typeof(TObjectId).FullName, Key = id};
      }
   }
}