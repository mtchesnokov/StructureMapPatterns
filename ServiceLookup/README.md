# Service lookup

## Problem
Imagine we have the following problem: our application should be able to send different types of messages to users. Say, sms or email. However the type of the message that should be sent is only known at runtime when user select it in dropdown. So our requirements are as follows: 
- Type of message to be sent is only know at runtime
- New types of messages can be added in the future
- Adding new type of message should have minimum implementation effort 
- Adding new type of message should have minimum impact on the existing codebase
- And last but not least, adding new code should not increase cyclomatic complexity of the code. That is, no if's!

## Solution
Thanks to a simple trick in the implementation, it is possible to use DI container itself as dispatcher that locates the 
right implementation given the message type. 


## Using lookup 

```csharp
   public interface IMessage
   {
   }

   public interface ICanSendMessage
   {
      void Send(IMessage message);
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
```


## Sms message

```csharp
   public class SmsMessage : IMessage
   {
   }

   public class SmsMessageSendService : CanSendSpecificMessageBase<SmsMessage>
   {
      public override void Send(SmsMessage message)
      {
         Console.WriteLine("Sending sms message...");
      }
   }
       
```

## Email message

```csharp
   public class EmailMessage : IMessage
   {
   }

   public class EmailMessageSendService : CanSendSpecificMessageBase<EmailMessage>
   {
      public override void Send(EmailMessage message)
      {
         Console.WriteLine("Sending email message...");
      }
   }
       
```

