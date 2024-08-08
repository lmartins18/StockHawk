using AutoMapper;
using StockHawk.DataAccess.Repositories;
using StockHawk.Model;
using StockHawk.Service.DTOs;
using StockHawk.Service.Exceptions;

namespace StockHawk.Service;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
    {
        var categories = await _categoryRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<CategoryDto>>(categories);
    }

    public async Task<CategoryDto?> GetCategoryByIdAsync(int id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);
        return _mapper.Map<CategoryDto?>(category);
    }

    public async Task<CategoryDto> AddCategoryAsync(CreateCategoryDto createCategoryDto)
    {
        await CheckForDuplicateCategoryNameAsync(createCategoryDto.Name);

        var category = _mapper.Map<Category>(createCategoryDto);
        await _categoryRepository.AddAsync(category);
        return _mapper.Map<CategoryDto>(category);
    }

    public async Task<CategoryDto?> UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
    {
        var category = await _categoryRepository.GetByIdAsync(updateCategoryDto.Id);

        if (category == null)
        {
            return null;
        }

        if (updateCategoryDto.Name is not null)
            await CheckForDuplicateCategoryNameAsync(updateCategoryDto.Name, updateCategoryDto.Id);

        _mapper.Map(updateCategoryDto, category);
        await _categoryRepository.UpdateAsync(category);
        return _mapper.Map<CategoryDto>(category);
    }

    public async Task<bool?> DeleteCategoryAsync(int id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);

        if (category == null) return null;

        var hasProducts = category.Products?.Count > 0;

        if (hasProducts) return false;

        await _categoryRepository.DeleteAsync(category);
        return true;
    }
    public async Task<int> GetCategoryCountAsync() => await _categoryRepository.CountAsync();


    private async Task CheckForDuplicateCategoryNameAsync(string categoryName, int? excludeCategoryId = null)
    {
        var allCategories = await _categoryRepository.GetAllAsync();

        if (allCategories.Any(c => c.Name == categoryName && (!excludeCategoryId.HasValue || c.Id != excludeCategoryId.Value)))
        {
            throw new DuplicateEntityException("A category with this name already exists.");
        }
    }
}