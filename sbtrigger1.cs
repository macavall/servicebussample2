using System;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace proj6;

public class sbtrigger1
{
    private readonly ILogger<sbtrigger1> _logger;

    public sbtrigger1(ILogger<sbtrigger1> logger)
    {
        _logger = logger;
    }

    [Function(nameof(sbtrigger1))]
    public async Task Run(
        [ServiceBusTrigger("myqueue5", Connection = "sbconnstring", IsSessionsEnabled = true, AutoCompleteMessages = false)]
        ServiceBusReceivedMessage message,
        ServiceBusMessageActions messageActions)
    {
        _logger.LogInformation("Message ID: {id}", message.MessageId);
        await messageActions.CompleteMessageAsync(message);
    }
}