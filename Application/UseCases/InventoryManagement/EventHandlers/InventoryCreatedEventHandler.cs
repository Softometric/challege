using Confluent.Kafka;
using Domain.Events.InventoryEvents;
using Domain.Events.ProductEvents;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.InventoryManagement.EventHandlers
{
    public class InventoryCreatedEventHandler : INotificationHandler<InventoryCreatedEvent>
    {
        private readonly ILogger<InventoryCreatedEventHandler> _logger;
        
        public InventoryCreatedEventHandler(ILogger<InventoryCreatedEventHandler> logger)
        {
            _logger = logger;
          
        }
        public Task Handle(InventoryCreatedEvent notification, CancellationToken cancellationToken)
        {
            //  _logger.LogInformation("Payment Domain Event: {DomainEvent}", notification.GetType().Name);

            return Task.CompletedTask;
        }
    }
}
