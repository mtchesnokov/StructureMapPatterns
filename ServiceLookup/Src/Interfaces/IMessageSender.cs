namespace Mt.CodePatterns.ServiceLookup.Interfaces
{
   /// <summary>
   /// Help interface
   /// </summary>
   internal interface IMessageSender
   {
      void Send(object message);
   }

   /// <summary>
   /// Interface that represents service that can send specific type of messages
   /// </summary>
   /// <typeparam name="TMessage"></typeparam>
   public interface IMessageSender<TMessage>
      where TMessage : IMessage
   {
      void Send(TMessage message);
   }
}