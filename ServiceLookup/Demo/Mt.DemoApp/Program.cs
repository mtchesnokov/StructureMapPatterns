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
            var messageService = container.GetInstance<IMessageService>();

            SendSmsMessage(messageService);

            SendMailMessage(messageService);
         }
      }

      private static void SendSmsMessage(IMessageService messageService)
      {
         var message = new SmsMessage();
         messageService.Send(message);
      }

      private static void SendMailMessage(IMessageService messageService)
      {
         var message = new MailMessage();
         messageService.Send(message);
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