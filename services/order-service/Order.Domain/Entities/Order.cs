using Order.Domain.Enums;

namespace Order.Domain.Entities;

public class Order
{
    public Guid Id { get; init; }
    public Guid CustomerId { get; init; }
    public decimal TotalAmount { get; init; }
    public OrderStatus Status { get; private set; }
    public DateTime CreatedAt { get; init; }

    public Order(Guid id, Guid customerId, decimal totalAmount)
    {
        if (totalAmount <= 0)
            throw new InvalidOperationException("Total amount must be positive");

        Id = id;
        CustomerId = customerId;
        TotalAmount = totalAmount;
        Status = OrderStatus.Created;
        CreatedAt = DateTime.UtcNow;
    }

    public void MarkPaid()
    {
        if (Status != OrderStatus.Created)
            throw new InvalidOperationException("Only created orders can be paid");

        Status = OrderStatus.Paid;
    }

    public void Fulfill()
    {
        if (Status != OrderStatus.Paid)
            throw new InvalidOperationException("Only paid orders can be fulfilled");

        Status = OrderStatus.Fulfilled;
    }

    public void Cancel()
    {
        if (Status == OrderStatus.Fulfilled)
            throw new InvalidOperationException("Fulfilled orders cannot be cancelled");

        Status = OrderStatus.Cancelled;
    }

    public void Fail()
    {
        if (Status == OrderStatus.Fulfilled)
            throw new InvalidOperationException("Fulfilled orders cannot fail");

        Status = OrderStatus.Failed;
    }
}
