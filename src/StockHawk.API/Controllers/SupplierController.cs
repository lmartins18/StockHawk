using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using StockHawk.Service;
using StockHawk.Service.DTOs;
using StockHawk.Service.Exceptions;

namespace StockHawk.API.Controllers;

[Route("api/suppliers")]
[Authorize]
[RequiredScope("Supplier.ReadWrite.All")]
[ProducesResponseType(StatusCodes.Status401Unauthorized)]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
[ApiController]
public class SupplierController : ControllerBase
{
    private readonly ISupplierService _supplierService;

    public SupplierController(ISupplierService supplierService)
    {
        _supplierService = supplierService;
    }

    [HttpGet]
    [ProducesResponseType<IEnumerable<SupplierDto>>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllSuppliers()
    {
        IEnumerable<SupplierDto> suppliers = await _supplierService.GetAllSuppliersAsync();
        return Ok(suppliers);
    }

    [HttpGet("{id}")]
    [ProducesResponseType<SupplierDto>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetSupplierById(int id)
    {
        SupplierDto? supplier = await _supplierService.GetSupplierByIdAsync(id);
        if (supplier == null)
            return NotFound();

        return Ok(supplier);
    }

    [HttpPost]
    [ProducesResponseType(typeof(SupplierDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateSupplier([FromBody] CreateSupplierDto createSupplierDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            SupplierDto createdSupplier = await _supplierService.AddSupplierAsync(createSupplierDto);
            return CreatedAtAction(nameof(GetSupplierById), new { id = createdSupplier.Id }, createdSupplier);
        }
        catch (DuplicateEntityException ex)
        {
            return Conflict(new { ex.Message });
        }
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateSupplier(int id, [FromBody] SupplierDto supplierDto)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedSupplier = await _supplierService.UpdateSupplierAsync(supplierDto);
            return (updatedSupplier is null)
                ? NotFound()
                : Ok(updatedSupplier);
        }
        catch (DuplicateEntityException ex)
        {
            return Conflict(new { ex.Message });
        }
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteSupplier(int id)
    {
        var success = await _supplierService.DeleteSupplierAsync(id);

        if (success is null) return NotFound();
        if (!success.Value) return BadRequest(new { title = "Supplier must have no associated products prior to deletion." });

        return NoContent();
    }
}