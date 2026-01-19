using Microsoft.AspNetCore.Mvc;
using Order.Application.DTOs;
using Order.Application.UseCases;

namespace Order.API.Controllers;

[ApiController]
[Route("orders")]
public class OrdersController : ControllerBase
{
    private readonly CreateOrderHandler _handler;

    public OrdersController(CreateOrderHandler handler)
    {
        _handler = handler;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateOrderRequest request)
    {
        var result = await _handler.HandleAsync(request);
        return CreatedAtAction(nameof(Create), result);
    }
}
