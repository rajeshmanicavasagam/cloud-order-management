using Order.Domain.Enums;
using Xunit;
using OrderEntity = Order.Domain.Entities.Order;

namespace Order.UnitTests.Domain;

public class OrderTests
{
    [Fact]
    public void New_order_should_start_in_created_status()
    {
        var order = new OrderEntity(
            Guid.NewGuid(),
            Guid.NewGuid(),
            100m
        );

        Assert.Equal(OrderStatus.Created, order.Status);
    }

    // ... other tests ...

    private static OrderEntity CreateOrder()
        => new(
            Guid.NewGuid(),
            Guid.NewGuid(),
            50m
        );
}
