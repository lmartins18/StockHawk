using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using StockHawk.Service;
using StockHawk.Service.DTOs;
using StockHawk.Service.Exceptions;

namespace StockHawk.API.Controllers;

[Route("api/categories")]
[Authorize]
[RequiredScope("Category.ReadWrite.All")]
[ProducesResponseType(StatusCodes.Status401Unauthorized)]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    [ProducesResponseType<IEnumerable<CategoryDto>>(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllCategories()
    {
        IEnumerable<CategoryDto> categories = await _categoryService.GetAllCategoriesAsync();
        return Ok(categories);
    }

    [HttpGet("{id}")]
    [ProducesResponseType<CategoryDto>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetCategoryById(int id)
    {
        CategoryDto? category = await _categoryService.GetCategoryByIdAsync(id);

        return (category == null) ? NotFound() : Ok(category);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDto createCategoryDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var createdCategory = await _categoryService.AddCategoryAsync(createCategoryDto);
            return CreatedAtAction(nameof(GetCategoryById), new { id = createdCategory.Id }, createdCategory);
        }
        catch (DuplicateEntityException ex)
        {
            return Conflict(new { message = ex.Message });
        }
    }


    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateCategory(int id, [FromBody] UpdateCategoryDto updateCategoryDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var existingCategory = await _categoryService.GetCategoryByIdAsync(id);
            if (existingCategory == null)
            {
                return NotFound();
            }

            updateCategoryDto.Id = id;
            var updatedCategory = await _categoryService.UpdateCategoryAsync(updateCategoryDto);

            return (updateCategoryDto is null)
            ? NotFound()
            : Ok(updatedCategory);
        }
        catch (DuplicateEntityException ex)
        {
            return Conflict(new { message = ex.Message });
        }

    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        var success = await _categoryService.DeleteCategoryAsync(id);

        if (success is null) return NotFound();
        if (!success.Value) return BadRequest(new { title = "Category must have no associated products prior to deletion." });

        return NoContent();
    }
}