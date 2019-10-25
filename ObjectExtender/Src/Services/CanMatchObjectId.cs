using Mt.CodePatterns.ObjectExtender.Domain.Exceptions;
using Mt.CodePatterns.ObjectExtender.Interfaces;
using StructureMap;

namespace Mt.CodePatterns.ObjectExtender.Services
{
   /// <summary>
   /// Default implementation of <see cref="ICanMatchObjectId{TObjectId,TObject}"/>
   /// </summary>
   /// <typeparam name="TKey"></typeparam>
   /// <typeparam name="TObject"></typeparam>
   public class CanMatchObjectId<TKey, TObject> : ICanMatchObjectId<TKey, TObject> where TObject : class
   {
      private readonly IContainer _container;

      #region ctor

      public CanMatchObjectId(IContainer container)
      {
         _container = container;
      }

      #endregion

      public bool IsMatch(TKey id, TObject obj)
      {
         if (obj is IHaveId<TKey>)
         {
            var x = obj as IHaveId<TKey>;
            return x.Id.Equals(id);
         }

         var z = _container.TryGetInstance<IKnowObjectId<TObject, TKey>>();

         if (z != null)
         {
            return z.GetId(obj).Equals(id);
         }

         throw new OperationNotSupportedException {ObjectType = typeof(TObject).FullName, ObjectIdType = typeof(TKey).FullName};
      }
   }
}