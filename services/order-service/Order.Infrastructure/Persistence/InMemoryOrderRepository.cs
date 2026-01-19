using OrderEntity = Order.Domain.Entities.Order;
using Order.Application.Interfaces;

namespace Order.Infrastructure.Persistence;

public class InMemoryOrderRepository : IOrderRepository
{
    private static readonly List<OrderEntity> Orders = [];

    public Task AddAsync(OrderEntity order)
    {
        Orders.Add(order);
        return Task.CompletedTask;
    }

    public Task<OrderEntity?> GetByIdAsync(Guid id)
    {
        var order = Orders.SingleOrDefault(o => o.Id == id);
        return Task.FromResult(order);
    }
}
