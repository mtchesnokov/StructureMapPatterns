# Service lookup

## Problem
Imagine we have the following problem: our application should be able to send different types of messages to users. Say, sms or email. 
However the actual type of the message that should be sent is only known at runtime. 

So our requirements are as follows: 
- Type of message to be sent is only known at runtime
- New types of messages can be added in the future
- Adding new type of message should have minimum implementation effort 
- Adding new type of message should have minimum impact on the existing codebase
- And of course, adding new code should not increase cyclomatic complexity of the code. Simply put, no if's!

## Solution
With the help of extra interface, it would be possible to use the DI container itself as dispatcher that locates the right implementation 
we need for the provided message type. 

## Usage example

```csharp
public class SmsMessage : IMessage
{
}

public class EmailMessage : IMessage
{
}

public interface IMessageService
{
   void Send(IMessage message);
}
   
private static void Main(string[] args)
{   
   ...

   IMessageService messageService = container.GetInstance<IMessageService>();

   var message = new SmsMessage();
   service.Send(message);

   var message = new MailMessage();
   service.Send(message);
}
   
```