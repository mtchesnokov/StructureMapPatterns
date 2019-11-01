using Mt.CodePatterns.ServiceLookup.Interfaces;

namespace Mt.CodePatterns.ServiceLookup.Services
{
   public abstract class CanSendSpecificMessageBase<TMessage> : ICanSendSpecificMessage<TMessage>, ICanSendSpecificMessage
      where TMessage : IMessage
   {
      public abstract void Send(TMessage message);

      void ICanSendSpecificMessage.Send(object message)
      {
         Send((TMessage) message);
      }
   }
}