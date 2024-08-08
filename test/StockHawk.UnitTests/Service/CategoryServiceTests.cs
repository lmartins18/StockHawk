using AutoMapper;
using FluentAssertions;
using StockHawk.Model;
using StockHawk.Service;
using StockHawk.Service.DTOs;
using StockHawk.UnitTests.FakeRepositories;
using StockHawk.Service.Exceptions;

namespace StockHawk.UnitTests.Service;

public class CategoryServiceTests
{
    private readonly FakeCategoryRepository _fakeCategoryRepository;
    private readonly IMapper _mapper;
    private readonly CategoryService _categoryService;

    public CategoryServiceTests()
    {
        _fakeCategoryRepository = new FakeCategoryRepository();

        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Category, CategoryDto>()
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
            cfg.CreateMap<CreateCategoryDto, Category>()
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
            cfg.CreateMap<UpdateCategoryDto, Category>()
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
        });
        _mapper = config.CreateMapper();

        _categoryService = new CategoryService(_fakeCategoryRepository, _mapper);
    }

    [Fact]
    public async Task GetAllCategoriesAsync_ReturnsAllCategories()
    {
        // Arrange
        var expected = (await _fakeCategoryRepository.GetAllAsync()).ToList();

        // Act
        var result = await _categoryService.GetAllCategoriesAsync();

        // Assert
        result.Should().HaveCount(expected.Count);
        result.First().Name.Should().Be(expected[0].Name);
        result.First().Description.Should().Be(expected[0].Description);
    }

    [Fact]
    public async Task GetCategoryByIdAsync_ReturnsCategory_WhenCategoryExists()
    {
        // Arrange
        var expected = _fakeCategoryRepository.GetById(1);

        // Act
        var result = await _categoryService.GetCategoryByIdAsync(1);

        // Assert
        result.Should().NotBeNull();
        result!.Id.Should().Be(1);
        result.Name.Should().Be(expected!.Name);
        result.Description.Should().Be(expected.Description);
    }

    [Fact]
    public async Task GetCategoryByIdAsync_ReturnsNull_WhenCategoryDoesNotExist()
    {
        // Act
        var result = await _categoryService.GetCategoryByIdAsync(999);

        // Assert
        result.Should().BeNull();
    }

    [Fact]
    public async Task GetCategoryByIdAsync_ReturnsNull_WhenIdIsZeroOrNegative()
    {
        // Act
        var resultZero = await _categoryService.GetCategoryByIdAsync(0);
        var resultNegative = await _categoryService.GetCategoryByIdAsync(-1);

        // Assert
        resultZero.Should().BeNull();
        resultNegative.Should().BeNull();
    }

    [Fact]
    public async Task AddCategoryAsync_AddsCategorySuccessfully()
    {
        // Arrange
        var createCategoryDto = new CreateCategoryDto { Name = "NewCategory", Description = "NewDescription" };

        // Act
        var result = await _categoryService.AddCategoryAsync(createCategoryDto);

        // Assert
        var category = await _fakeCategoryRepository.GetByIdAsync(result.Id);
        category.Should().NotBeNull();
        category!.Name.Should().Be("NewCategory");
        category.Description.Should().Be("NewDescription");
    }

    [Fact]
    public async Task AddCategoryAsync_ShouldThrowDuplicateCategoryException_WhenNameIsDuplicate()
    {
        // Arrange
        _fakeCategoryRepository.Add(new Category { Id = 1, Name = "ExistingCategory", Description = "Description" });
        var duplicateCategoryDto = new CreateCategoryDto { Name = "ExistingCategory", Description = "Description" };

        // Act
        Func<Task> act = async () => await _categoryService.AddCategoryAsync(duplicateCategoryDto);

        // Assert
        await act.Should().ThrowAsync<DuplicateEntityException>()
            .WithMessage("A category with this name already exists.");
    }


    [Fact]
    public async Task UpdateCategoryAsync_UpdatesCategorySuccessfully()
    {
        // Arrange
        var existingCategory = new Category { Id = 1, Name = "OldCategory", Description = "OldDescription" };
        _fakeCategoryRepository.Add(existingCategory);

        var updateCategoryDto = new UpdateCategoryDto { Id = 1, Name = "UpdatedCategory", Description = "UpdatedDescription" };

        // Act
        var result = await _categoryService.UpdateCategoryAsync(updateCategoryDto);

        // Assert
        var category = await _fakeCategoryRepository.GetByIdAsync(1);
        category.Should().NotBeNull();
        category!.Name.Should().Be("UpdatedCategory");
        category.Description.Should().Be("UpdatedDescription");
    }

    [Fact]
    public async Task UpdateCategoryAsync_ReturnsNull_WhenCategoryDoesNotExist()
    {
        // Arrange
        var updateCategoryDto = new UpdateCategoryDto { Id = 999, Name = "NonExistentCategory", Description = "NonExistentDescription" };

        // Act
        var result = await _categoryService.UpdateCategoryAsync(updateCategoryDto);

        // Assert
        result.Should().BeNull();
    }

    [Fact]
    public async Task UpdateCategoryAsync_ShouldThrowDuplicateCategoryException_WhenNameIsDuplicate()
    {
        // Arrange
        var existingCategory1 = new Category { Id = 1, Name = "Category1", Description = "Description1" };
        var existingCategory2 = new Category { Id = 2, Name = "Category2", Description = "Description2" };
        _fakeCategoryRepository.Add(existingCategory1);
        _fakeCategoryRepository.Add(existingCategory2);

        var updateCategoryDto = new UpdateCategoryDto { Id = 1, Name = "Category2", Description = "UpdatedDescription" };

        // Act
        Func<Task> act = async () => await _categoryService.UpdateCategoryAsync(updateCategoryDto);

        // Assert
        await act.Should().ThrowAsync<DuplicateEntityException>()
            .WithMessage("A category with this name already exists.");
    }

    [Fact]
    public async Task DeleteCategoryAsync_DeletesCategorySuccessfully_WhenNoProducts()
    {
        // Act
        var result = await _categoryService.DeleteCategoryAsync(1);

        // Assert
        result.Should().BeTrue();
        var deletedCategory = await _fakeCategoryRepository.GetByIdAsync(1);
        deletedCategory.Should().BeNull();
    }

    [Fact]
    public async Task DeleteCategoryAsync_ReturnsFalse_WhenCategoryHasProducts()
    {
        // Act
        var result = await _categoryService.DeleteCategoryAsync(3); // Category with products.

        // Assert
        result.Should().BeFalse();
        var existingCategory = await _fakeCategoryRepository.GetByIdAsync(1);
        existingCategory.Should().NotBeNull();
    }

    [Fact]
    public async Task DeleteCategoryAsync_ReturnsNull_WhenCategoryDoesNotExist()
    {
        // Act
        var result = await _categoryService.DeleteCategoryAsync(999);

        // Assert
        result.Should().BeNull();
    }

    [Fact]
    public async Task GetCategoryCountAsync_ReturnsCorrectCount()
    {
        // Arrange
        var expected = _fakeCategoryRepository.Count;

        // Act
        var result = await _categoryService.GetCategoryCountAsync();

        // Assert
        result.Should().Be(expected);
    }
}
