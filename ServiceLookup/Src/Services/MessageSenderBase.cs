using Mt.CodePatterns.ServiceLookup.Interfaces;

namespace Mt.CodePatterns.ServiceLookup.Services
{
   /// <summary>
   /// Basic implementation of <see cref="IMessageSender{TMessage}"/>
   /// </summary>
   /// <typeparam name="TMessage"></typeparam>
   public abstract class MessageSenderBase<TMessage> : IMessageSender<TMessage>, IMessageSender
      where TMessage : IMessage
   {
      public abstract void Send(TMessage message);

      void IMessageSender.Send(object message)
      {
         Send((TMessage) message);
      }
   }
}