using Mt.CodePatterns.ServiceLookup.Domain.Exceptions;
using Mt.CodePatterns.ServiceLookup.Interfaces;
using StructureMap;
using StructureMap.Attributes;

namespace Mt.CodePatterns.ServiceLookup.Services
{
   public class CanSendMessage : ICanSendMessage
   {
      [SetterProperty]
      public IContainer Container { get; set; }

      public void Send(IMessage message)
      {
         var serviceType = typeof(ICanSendSpecificMessage<>).MakeGenericType(message.GetType());
         var serviceInstance = Container.TryGetInstance(serviceType) as ICanSendSpecificMessage;

         if (serviceInstance == null)
         {
            throw new OperationNotSupportedException {ServiceType = serviceType.FullName};
         }

         serviceInstance.Send(message);
      }
   }
}