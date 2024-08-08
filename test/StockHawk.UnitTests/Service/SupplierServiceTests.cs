using AutoMapper;
using FluentAssertions;
using StockHawk.Service;
using StockHawk.Service.DTOs;
using StockHawk.Service.Exceptions;
using StockHawk.Service.MappingProfiles;
using StockHawk.UnitTests.FakeRepositories;

namespace StockHawk.UnitTests.Service
{
    public class SupplierServiceTests
    {
        private readonly SupplierService _supplierService;
        private readonly FakeSupplierRepository _fakeSupplierRepository;

        public SupplierServiceTests()
        {
            _fakeSupplierRepository = new FakeSupplierRepository();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new SupplierMappingProfile());
            });

            var mapper = config.CreateMapper();
            _supplierService = new SupplierService(_fakeSupplierRepository, mapper);
        }

        [Fact]
        public async Task GetAllSuppliersAsync_ReturnsAllSuppliers()
        {
            // Act
            var result = await _supplierService.GetAllSuppliersAsync();
            var expected = _fakeSupplierRepository.Count;

            // Assert
            result.Should().HaveCount(expected);
        }

        [Fact]
        public async Task GetSupplierByIdAsync_ReturnsCorrectSupplier()
        {
            // Act
            var result = await _supplierService.GetSupplierByIdAsync(1);

            // Assert
            result.Should().NotBeNull();
            result.Should().Match<SupplierDto>(s => s.Name == "Supplier1");
        }

        [Fact]
        public async Task AddSupplierAsync_AddsSupplier()
        {
            // Arrange
            var newSupplier = new CreateSupplierDto
            {
                Name = "Supplier4",
                ContactNumber = "555-555-5555",
                Email = "supplier4@example.com",
                Address = "789 Supplier St."
            };

            // Act
            var result = await _supplierService.AddSupplierAsync(newSupplier);

            // Assert
            result.Should().NotBeNull();
            result.Name.Should().Be("Supplier4");

            var addedSupplier = await _fakeSupplierRepository.GetByIdAsync(result.Id);
            addedSupplier.Should().NotBeNull();
            addedSupplier!.Name.Should().Be("Supplier4");
        }
        [Fact]
        public async Task AddSupplierAsync_ShouldThrowDuplicateSupplierException_WhenSupplierWithSameNameAndEmailExists()
        {
            // Arrange
            var existing = await _fakeSupplierRepository.GetByIdAsync(1);

            var createSupplierDto = new CreateSupplierDto
            {
                Name = "ExistingSupplier",
                Email = existing!.Email,
                ContactNumber = "987654321",
                Address = "Second street Dublin"
            };

            // Act
            Func<Task> act = async () => await _supplierService.AddSupplierAsync(createSupplierDto);

            // Assert
            await act.Should().ThrowAsync<DuplicateEntityException>()
                .WithMessage($"A supplier with the same email already exists.");
        }
        [Fact]
        public async Task AddSupplierAsync_ShouldThrowDuplicateEntityException_WhenSupplierWithSameEmailOrContactNumberExists()
        {
            // Arrange
            var existingSupplier = await _fakeSupplierRepository.GetByIdAsync(1);

            var createSupplierDto = new CreateSupplierDto
            {
                Name = "NewSupplier",
                Email = existingSupplier!.Email, // Same email as an existing supplier
                ContactNumber = existingSupplier.ContactNumber, // Same contact number as an existing supplier
                Address = "Test road 2"
            };

            // Act
            Func<Task> act = async () => await _supplierService.AddSupplierAsync(createSupplierDto);

            // Assert
            await act.Should().ThrowAsync<DuplicateEntityException>()
                .WithMessage($"A supplier with the same email and contact number already exists.");
        }


        [Fact]
        public async Task UpdateSupplierAsync_ShouldThrowDuplicateEntityException_WhenSupplierWithSameEmailOrContactNumberExists()
        {
            // Arrange
            var existingSupplier = await _fakeSupplierRepository.GetByIdAsync(1);

            var SupplierDto = new SupplierDto
            {
                Id = 2,
                Name = "AnotherSupplier",
                Email = existingSupplier!.Email, // Same email as an existing supplier
                ContactNumber = existingSupplier.ContactNumber, // Same contact number as an existing supplier
                Address = "Test road 2nd"
            };

            // Act
            Func<Task> act = async () => await _supplierService.UpdateSupplierAsync(SupplierDto);

            // Assert
            await act.Should().ThrowAsync<DuplicateEntityException>()
                .WithMessage($"A supplier with the same email and contact number already exists.");
        }

        [Fact]
        public async Task UpdateSupplierAsync_UpdatesSupplier()
        {
            // Arrange
            var supplierDto = new SupplierDto
            {
                Id = 1,
                Name = "UpdatedSupplier",
                Email = "updated@supplier.com",
                ContactNumber = "123456789",
                Address = "Test road 2nd"
            };

            // Act
            var result = await _supplierService.UpdateSupplierAsync(supplierDto);

            // Assert
            result.Should().NotBeNull();
            result!.Name.Should().Be("UpdatedSupplier");
            result.Email.Should().Be("updated@supplier.com");
            result.ContactNumber.Should().Be("123456789");
        }

        [Fact]
        public async Task UpdateSupplierAsync_ShouldReturnNull_WhenSupplierDoesNotExist()
        {
            // Arrange
            var SupplierDto = new SupplierDto
            {
                Id = 999, // Non-existent supplier ID
                Name = "NonExistentSupplier",
                Email = "nonexistent@supplier.com",
                ContactNumber = "0000000000",
                Address = "2nd test street"
            };

            // Act
            var result = await _supplierService.UpdateSupplierAsync(SupplierDto);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public async Task DeleteSupplierAsync_DeletesSupplier_WhenNoProducts()
        {
            // Arrange
            var supplierId = 3; // Supplier with no products

            // Act
            var result = await _supplierService.DeleteSupplierAsync(supplierId);

            // Assert
            result.Should().BeTrue();
            var supplier = await _fakeSupplierRepository.GetByIdAsync(supplierId);
            supplier.Should().BeNull();
        }

        [Fact]
        public async Task DeleteSupplierAsync_DoesNotDeleteSupplier_WhenHasProducts()
        {
            // Arrange
            int supplierId = 2; // Supplier with products

            // Act
            var result = await _supplierService.DeleteSupplierAsync(supplierId);

            // Assert
            result.Should().BeFalse();
            var supplier = await _fakeSupplierRepository.GetByIdAsync(supplierId);
            supplier.Should().NotBeNull();
        }
    }
}
