namespace Order.Application.DTOs;

public record CreateOrderRequest(
    Guid CustomerId,
    decimal TotalAmount
);
