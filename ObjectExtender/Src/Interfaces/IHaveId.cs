namespace Mt.CodePatterns.ObjectExtender.Interfaces
{
   /// <summary>
   /// For 'own' objects we can use this interface 
   /// </summary>
   /// <typeparam name="TObjectId"></typeparam>
   public interface IHaveId<TObjectId>
   {
      TObjectId Id { get; }
   }
}