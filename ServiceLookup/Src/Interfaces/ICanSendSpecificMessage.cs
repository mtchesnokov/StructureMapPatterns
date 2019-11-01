namespace Mt.CodePatterns.ServiceLookup.Interfaces
{
   internal interface ICanSendSpecificMessage
   {
      void Send(object message);
   }

   public interface ICanSendSpecificMessage<TMessage>
      where TMessage : IMessage
   {
      void Send(TMessage message);
   }
}