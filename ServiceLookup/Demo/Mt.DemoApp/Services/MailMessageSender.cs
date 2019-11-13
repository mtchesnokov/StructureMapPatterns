using System;
using Mt.CodePatterns.ServiceLookup.Services;

namespace ConsoleApp1.Services
{
   public class MailMessageSender : MessageSenderBase<MailMessage>
   {
      public override void Send(MailMessage message)
      {
         Console.WriteLine("Sending mail message...");
      }
   }
}