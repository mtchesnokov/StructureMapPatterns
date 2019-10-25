namespace Mt.CodePatterns.ObjectExtender.Interfaces
{
   /// <summary>
   /// This interface represents service that will look for object id (own of attached) and compare it with provided value
   /// </summary>
   /// <typeparam name="TObjectId"></typeparam>
   /// <typeparam name="TObject"></typeparam>
   public interface ICanMatchObjectId<TObjectId, TObject>
      where TObject : class
   {
      bool IsMatch(TObjectId id, TObject obj);
   }
}