using MediatR;
using Shop.L1.Domain.Order_Aggregate.Events;

namespace Shop.L2.Application.Orders._EvenHandlers;

public class SendSmsOrderFinalizedEventHandler : INotificationHandler<OrderFinalized>
{
    public async Task Handle(OrderFinalized notification, CancellationToken cancellationToken)
    {
        await Task.Delay(10000, cancellationToken);
        Console.WriteLine("------------------------------------------------------------");
    }
}