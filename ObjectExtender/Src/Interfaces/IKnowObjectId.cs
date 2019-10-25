namespace Mt.CodePatterns.ObjectExtender.Interfaces
{
   /// <summary>
   /// For objects we have no control over. We can use this interface to 'attach' id property
   /// </summary>
   /// <typeparam name="TObject"></typeparam>
   /// <typeparam name="TObjectId"></typeparam>
   public interface IKnowObjectId<TObject, TObjectId>
   {
      TObjectId GetId(TObject obj);
   }
}