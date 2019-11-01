using System;
using Mt.CodePatterns.ServiceLookup.Services;

namespace ConsoleApp1.Services
{
   public class MailMessageSendService : CanSendSpecificMessageBase<MailMessage>
   {
      public override void Send(MailMessage message)
      {
         Console.WriteLine("Sending mail message...");
      }
   }
}