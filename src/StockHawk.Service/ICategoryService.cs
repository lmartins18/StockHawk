using StockHawk.Service.DTOs;

namespace StockHawk.Service;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();
    Task<CategoryDto?> GetCategoryByIdAsync(int id);
    Task<CategoryDto> AddCategoryAsync(CreateCategoryDto customerDetailsDto);
    Task<CategoryDto?> UpdateCategoryAsync(UpdateCategoryDto categoryDto);
    Task<bool?> DeleteCategoryAsync(int id);
    Task<int> GetCategoryCountAsync();

}