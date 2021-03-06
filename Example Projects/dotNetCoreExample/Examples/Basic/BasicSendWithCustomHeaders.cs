﻿using SocketLabs.InjectionApi;
using SocketLabs.InjectionApi.Message;

namespace dotNetCoreExample.Examples.Basic
{
    public class BasicSendWithCustomHeaders : IExample
    {
        public SendResponse RunExample()
        {
            var client = new SocketLabsClient(ExampleConfig.ServerId, ExampleConfig.ApiKey)
            {
                EndpointUrl = ExampleConfig.TargetApi
            };

            var message = new BasicMessage();

            message.Subject = "Sending An Email With Custom Headers";
            message.HtmlBody = "<body><p><strong>Lorem Ipsum</strong></p></body>";
            message.PlainTextBody = "Lorem Ipsum";

            message.From.Email = "from@example.com";
            message.ReplyTo.Email = "replyto@example.com";
            message.To.Add("recipient1@example.com");

            message.CustomHeaders.Add("My-Header", "1...2...3...");
            message.CustomHeaders.Add("Example-Type", "BasicSendWithCustomHeaders");

            return client.Send(message);
        }
    }
}
