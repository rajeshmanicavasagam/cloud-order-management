using Order.Application.Interfaces;
using OrderEntity = Order.Domain.Entities.Order;

namespace Order.UnitTests.Application;

public class FakeOrderRepository : IOrderRepository
{
    public readonly List<OrderEntity> Orders = [];

    public Task AddAsync(OrderEntity order)
    {
        Orders.Add(order);
        return Task.CompletedTask;
    }

    public Task<OrderEntity?> GetByIdAsync(Guid id)
    {
        return Task.FromResult(Orders.SingleOrDefault(o => o.Id == id));
    }
}
