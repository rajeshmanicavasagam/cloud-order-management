using Order.Domain.Enums;

namespace Order.Application.DTOs;

public record OrderResponse(
    Guid Id,
    Guid CustomerId,
    decimal TotalAmount,
    OrderStatus Status
);
