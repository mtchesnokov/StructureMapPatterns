using Mt.CodePatterns.ServiceLookup.Interfaces;
using NUnit.Framework;

namespace Mt.CodePatterns.ServiceLookup.UnitTests.UseCases.MessageService.UseCase1
{
   public class HappyTests : UnitTestBase<IMessageService>
   {
      [Test]
      public void Sending_Sms()
      {
         //arrange
         var message = new SmsMessage();

         //act
         SUT.Send(message);
      }

      [Test]
      public void Sending_Mail()
      {
         //arrange
         var message = new MailMessage();

         //act
         SUT.Send(message);
      }
   }
}