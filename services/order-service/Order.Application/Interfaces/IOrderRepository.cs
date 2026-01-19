namespace Order.Application.Interfaces;

public interface IOrderRepository
{
    Task AddAsync(Order.Domain.Entities.Order order);
    Task<Order.Domain.Entities.Order?> GetByIdAsync(Guid id);
}
