using Mt.CodePatterns.ServiceLookup.Interfaces;
using NUnit.Framework;

namespace Mt.CodePatterns.ServiceLookup.UnitTests.UseCases.CanSendMessage.UseCase1
{
   public class HappyTests : UnitTestBase<ICanSendMessage>
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