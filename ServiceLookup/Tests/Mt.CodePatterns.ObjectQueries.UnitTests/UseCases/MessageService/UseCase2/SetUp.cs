using System;
using Mt.CodePatterns.ServiceLookup.Interfaces;
using Mt.CodePatterns.ServiceLookup.Services;

namespace Mt.CodePatterns.ServiceLookup.UnitTests.UseCases.MessageService.UseCase2
{
   public class SmsMessage : IMessage
   {
   }

   public class MailMessage : IMessage
   {
   }

   public class VoiceMessage : IMessage
   {
   }

   public class SmsMessageSendService : MessageSenderBase<SmsMessage>
   {
      public override void Send(SmsMessage message)
      {
         throw new NotImplementedException();
      }
   }

   public class MailMessageSendService : MessageSenderBase<MailMessage>
   {
      public override void Send(MailMessage message)
      {
         throw new NotImplementedException();
      }
   }
}