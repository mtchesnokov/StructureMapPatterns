using Mt.CodePatterns.ServiceLookup.Domain.Exceptions;
using Mt.CodePatterns.ServiceLookup.Interfaces;
using StructureMap;
using StructureMap.Attributes;

namespace Mt.CodePatterns.ServiceLookup.Services
{
   /// <summary>
   /// Implementation of <see cref="IMessageService"/>
   /// </summary>
   public class MessageService : IMessageService
   {
      [SetterProperty]
      public IContainer Container { get; set; }

      public void Send(IMessage message)
      {
         var serviceType = typeof(IMessageSender<>).MakeGenericType(message.GetType());
         var serviceInstance = Container.TryGetInstance(serviceType) as IMessageSender;

         if (serviceInstance == null)
         {
            throw new OperationNotSupportedException
            {
               MessageType = message.GetType()
            };
         }

         serviceInstance.Send(message);
      }
   }
}