using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using StockHawk.Service;
using StockHawk.Service.DTOs;
using StockHawk.Service.Exceptions;

namespace StockHawk.API.Controllers;

[Route("api/order-types")]
[Authorize]
[RequiredScope("OrderType.ReadWrite.All")]
[ProducesResponseType(StatusCodes.Status401Unauthorized)]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
[ApiController]
public class OrderTypeController : ControllerBase
{
    private readonly IOrderTypeService _orderTypeService;

    public OrderTypeController(IOrderTypeService orderTypeService)
    {
        _orderTypeService = orderTypeService;
    }

    [HttpGet]
    [ProducesResponseType<IEnumerable<OrderTypeDto>>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllOrderTypes()
    {
        IEnumerable<OrderTypeDto> orderTypes = await _orderTypeService.GetAllOrderTypesAsync();
        return Ok(orderTypes);
    }

    [HttpGet("{id}")]
    [ProducesResponseType<OrderTypeDto>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetOrderTypeById(int id)
    {
        OrderTypeDto? orderType = await _orderTypeService.GetOrderTypeByIdAsync(id);
        return (orderType == null) ? NotFound() : Ok(orderType);
    }

    [HttpPost]
    [ProducesResponseType(typeof(OrderTypeDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateOrderType([FromBody] CreateOrderTypeDto createOrderTypeDto)
    {

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {

            OrderTypeDto createdOrderType = await _orderTypeService.AddOrderTypeAsync(createOrderTypeDto);
            return CreatedAtAction(nameof(GetOrderTypeById), new { id = createdOrderType.Id }, createdOrderType);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { ex.Message });
        }
        catch (DuplicateEntityException ex)
        {
            // Handle duplicate entity exception
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
    public async Task<IActionResult> UpdateOrderType(int id, [FromBody] UpdateOrderTypeDto updateOrderTypeDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {

            var existingOrderType = await _orderTypeService.GetOrderTypeByIdAsync(id);
            if (existingOrderType == null)
            {
                return NotFound();
            }

            updateOrderTypeDto.Id = id;
            var updatedOrderType = await _orderTypeService.UpdateOrderTypeAsync(updateOrderTypeDto);
            return Ok(updatedOrderType);
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
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteOrderType(int id)
    {
        var success = await _orderTypeService.DeleteOrderTypeAsync(id);

        if (success is null) return NotFound();
        if (!success.Value) return BadRequest(new { title = "Order type must have no associated orders prior to deletion." });

        return NoContent();
    }
}