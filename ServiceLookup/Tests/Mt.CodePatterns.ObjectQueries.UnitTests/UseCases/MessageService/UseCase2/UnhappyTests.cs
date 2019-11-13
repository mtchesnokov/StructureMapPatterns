using Mt.CodePatterns.ServiceLookup.Domain.Exceptions;
using Mt.CodePatterns.ServiceLookup.Interfaces;
using NUnit.Framework;

namespace Mt.CodePatterns.ServiceLookup.UnitTests.UseCases.MessageService.UseCase2
{
   public class UnhappyTests : UnitTestBase<IMessageService>
   {
      [Test]
      public void Operation_Not_Supported()
      {
         //arrange
         var message = new VoiceMessage();

         //act+assert
         Assert.Throws<OperationNotSupportedException>(() => SUT.Send(message));
      }
   }
}