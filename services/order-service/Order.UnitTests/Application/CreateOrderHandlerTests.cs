using Order.Application.DTOs;
using Order.Application.UseCases;
using Order.Domain.Enums;
using Xunit;

namespace Order.UnitTests.Application;

public class CreateOrderHandlerTests
{
    [Fact]
    public async Task Create_order_returns_created_status()
    {
        var repository = new FakeOrderRepository();
        var handler = new CreateOrderHandler(repository);

        var request = new CreateOrderRequest(
            Guid.NewGuid(),
            200m
        );

        var response = await handler.HandleAsync(request);

        Assert.Equal(OrderStatus.Created, response.Status);
        Assert.Single(repository.Orders);
    }
}
