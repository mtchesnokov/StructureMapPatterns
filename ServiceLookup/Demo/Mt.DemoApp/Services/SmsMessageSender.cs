﻿using System;
using Mt.CodePatterns.ServiceLookup.Services;

namespace ConsoleApp1.Services
{
   public class SmsMessageSender : MessageSenderBase<SmsMessage>
   {
      public override void Send(SmsMessage message)
      {
         Console.WriteLine("Sending sms message...");
      }
   }
}