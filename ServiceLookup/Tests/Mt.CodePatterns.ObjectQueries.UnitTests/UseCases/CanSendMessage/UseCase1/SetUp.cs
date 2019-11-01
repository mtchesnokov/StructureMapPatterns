using System.Diagnostics;
using Mt.CodePatterns.ServiceLookup.Interfaces;
using Mt.CodePatterns.ServiceLookup.Services;

namespace Mt.CodePatterns.ServiceLookup.UnitTests.UseCases.CanSendMessage.UseCase1
{
   public class SmsMessage : IMessage
   {
   }

   public class MailMessage : IMessage
   {
   }

   public class SmsMessageSendService : CanSendSpecificMessageBase<SmsMessage>
   {
      public override void Send(SmsMessage message)
      {
         Debug.WriteLine("Sending sms message...");
      }
   }

   public class MailMessageSendService : CanSendSpecificMessageBase<MailMessage>
   {
      public override void Send(MailMessage message)
      {
         Debug.WriteLine("Sending mail message...");
      }
   }
}