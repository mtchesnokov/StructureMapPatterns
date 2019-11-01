using ConsoleApp1.Services;
using Mt.CodePatterns.ServiceLookup.Interfaces;
using StructureMap;

namespace ConsoleApp1
{
   internal class Program
   {
      private static void Main(string[] args)
      {
         using (var container = CreateContainer())
         {
            SendingSmsMessage(container);

            SendingMailMessage(container);
         }
      }

      private static void SendingSmsMessage(IContainer container)
      {
         var service = container.GetInstance<ICanSendMessage>();
         var message = new SmsMessage();
         service.Send(message);
      }

      private static void SendingMailMessage(IContainer container)
      {
         var service = container.GetInstance<ICanSendMessage>();
         var message = new MailMessage();
         service.Send(message);
      }

      private static IContainer CreateContainer()
      {
         return new Container(cfg =>
         {
            cfg.Scan(s =>
            {
               s.AssembliesAndExecutablesFromApplicationBaseDirectory();
               s.LookForRegistries();
            });
         });
      }
   }
}