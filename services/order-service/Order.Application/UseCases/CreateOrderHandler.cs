using Order.Application.DTOs;
using Order.Application.Interfaces;
using Order.Domain.Entities;

namespace Order.Application.UseCases;

public class CreateOrderHandler
{
    private readonly IOrderRepository _repository;

    public CreateOrderHandler(IOrderRepository repository)
    {
        _repository = repository;
    }

    public async Task<OrderResponse> HandleAsync(CreateOrderRequest request)
    {
        var order = new Order.Domain.Entities.Order(

            Guid.NewGuid(),
            request.CustomerId,
            request.TotalAmount
        );

        await _repository.AddAsync(order);

        return new OrderResponse(
            order.Id,
            order.CustomerId,
            order.TotalAmount,
            order.Status
        );
    }
}
