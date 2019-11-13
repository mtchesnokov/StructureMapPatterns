namespace Mt.CodePatterns.ServiceLookup.Interfaces
{
   /// <summary>
   /// Service that will send provided message using one of available senders
   /// </summary>
   public interface IMessageService
   {
      void Send(IMessage message);
   }
}