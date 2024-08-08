using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using StockHawk.Service;
using StockHawk.Service.DTOs;
using StockHawk.Service.Exceptions;

namespace StockHawk.API.Controllers;

[Route("api/order-statuses")]
[Authorize]
[RequiredScope("OrderStatus.ReadWrite.All")]
[ProducesResponseType(StatusCodes.Status401Unauthorized)]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
[ApiController]
public class OrderStatusController : ControllerBase
{
    private readonly IOrderStatusService _orderStatusService;

    public OrderStatusController(IOrderStatusService orderStatusService)
    {
        _orderStatusService = orderStatusService;
    }

    [HttpGet]
    [ProducesResponseType<IEnumerable<OrderStatusDto>>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllOrderStatuses()
    {
        IEnumerable<OrderStatusDto> orderStatuses = await _orderStatusService.GetAllOrderStatusesAsync();
        return Ok(orderStatuses);
    }

    [HttpGet("{id}")]
    [ProducesResponseType<OrderStatusDto>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetOrderStatusById(int id)
    {
        OrderStatusDto? orderStatus = await _orderStatusService.GetOrderStatusByIdAsync(id);
        return (orderStatus == null) ? NotFound() : Ok(orderStatus);
    }

    [HttpPost]
    [ProducesResponseType(typeof(OrderStatusDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateOrderStatus([FromBody] CreateOrderStatusDto createOrderStatusDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            OrderStatusDto createdOrderStatus = await _orderStatusService.AddOrderStatusAsync(createOrderStatusDto);
            return CreatedAtAction(nameof(GetOrderStatusById), new { id = createdOrderStatus.Id }, createdOrderStatus);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { ex.Message });
        }
        catch (DuplicateEntityException ex)
        {
            return Conflict(new { ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }


    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateOrderStatus(int id, [FromBody] UpdateOrderStatusDto updateOrderStatusDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        try
        {
            var existingOrderStatus = await _orderStatusService.GetOrderStatusByIdAsync(id);
            if (existingOrderStatus == null)
            {
                return NotFound();
            }

            updateOrderStatusDto.Id = id;
            var updatedOrderStatus = await _orderStatusService.UpdateOrderStatusAsync(updateOrderStatusDto);
            return Ok(updatedOrderStatus);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { ex.Message });
        }
        catch (DuplicateEntityException ex)
        {
            return Conflict(new { ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteOrderStatus(int id)
    {
        var success = await _orderStatusService.DeleteOrderStatusAsync(id);

        if (success is null) return NotFound();
        if (!success.Value) return BadRequest(new { title = "Order Status must have no associated orders prior to deletion." });

        return NoContent();

    }
}