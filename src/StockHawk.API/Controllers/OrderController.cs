using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using StockHawk.Service;
using StockHawk.Service.DTOs;
using StockHawk.Service.Exceptions;

namespace StockHawk.API.Controllers;

[Route("api/orders")]
[Authorize]
[RequiredScope("Order.ReadWrite.All")]
[ProducesResponseType(StatusCodes.Status401Unauthorized)]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    [ProducesResponseType<IEnumerable<OrderDto>>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllOrders()
    {
        IEnumerable<OrderDto> orders = await _orderService.GetAllOrdersAsync();
        return Ok(orders);
    }

    [HttpGet("{id}")]
    [ProducesResponseType<OrderDto>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetOrderById(int id)
    {
        OrderDto? order = await _orderService.GetOrderByIdAsync(id);

        return (order == null)
            ? NotFound()
            : Ok(order);
    }

    [HttpPost]
    [ProducesResponseType<OrderDto>(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDto createOrderDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            OrderDto createdOrder = await _orderService.AddOrderAsync(createOrderDto);
            return CreatedAtAction(nameof(GetOrderById), new { id = createdOrder.Id }, createdOrder);
        }
        catch (DuplicateEntityException ex)
        {
            return Conflict(new { ex.Message });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { ex.Message });
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPut("{id}")]
    [ProducesResponseType<UpdateOrderDto>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateOrder(int id, [FromBody] UpdateOrderDto orderDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            var updatedOrder = await _orderService.UpdateOrderAsync(orderDto);
            return (updatedOrder is null)
                ? NotFound()
                : Ok(updatedOrder);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteOrder(int id)
    {
        try
        {
            var order = await _orderService.DeleteOrderAsync(id);

            return (order is null)
            ? NotFound()
            : NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}
