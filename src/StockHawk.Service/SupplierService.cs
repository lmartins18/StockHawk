using AutoMapper;
using StockHawk.DataAccess.Repositories;
using StockHawk.Model;
using StockHawk.Service.DTOs;
using StockHawk.Service.Exceptions;
using StockHawk.Service.Utilities;

namespace StockHawk.Service;

public class SupplierService : ISupplierService
{
    private readonly ISupplierRepository _supplierRepository;
    private readonly IMapper _mapper;

    public SupplierService(ISupplierRepository supplierRepository, IMapper mapper)
    {
        _supplierRepository = supplierRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<SupplierDto>> GetAllSuppliersAsync()
    {
        var suppliers = await _supplierRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<SupplierDto>>(suppliers);
    }

    public async Task<SupplierDto?> GetSupplierByIdAsync(int id)
    {
        var supplier = await _supplierRepository.GetByIdAsync(id);
        return _mapper.Map<SupplierDto?>(supplier);
    }

    public async Task<SupplierDto> AddSupplierAsync(CreateSupplierDto supplierDto)
    {
        // Check if a supplier with the same email or contact number already exists
        var existingSupplier = (await _supplierRepository.GetAllAsync())
            .FirstOrDefault(s => s.Email == supplierDto.Email || s.ContactNumber == supplierDto.ContactNumber);

        if (existingSupplier != null)
        {
            var messages = new List<string>();

            if (existingSupplier.Email == supplierDto.Email)
                messages.Add("email");
            if (existingSupplier.ContactNumber == supplierDto.ContactNumber)
                messages.Add("contact number");

            var duplicateProps = string.Join(" and ", messages);
            throw new DuplicateEntityException($"A supplier with the same {duplicateProps} already exists.");
        }

        // Map the DTO to the supplier entity
        var supplier = _mapper.Map<Supplier>(supplierDto);

        // Add the new supplier to the repository
        await _supplierRepository.AddAsync(supplier);

        // Return the created supplier as a DTO
        return _mapper.Map<SupplierDto>(supplier);
    }

    public async Task<SupplierDto?> UpdateSupplierAsync(SupplierDto supplierDto)
    {
        var supplier = await _supplierRepository.GetByIdAsync(supplierDto.Id);

        if (supplier is null) return null;

        // Check if another supplier with the same email or contact number already exists
        var existingSupplier = (await _supplierRepository.GetAllAsync())
            .FirstOrDefault(s => (s.Email == supplierDto.Email || s.ContactNumber == supplierDto.ContactNumber) && s.Id != supplierDto.Id);

        if (existingSupplier != null)
        {
            var messages = new List<string>();

            if (existingSupplier.Email == supplierDto.Email)
                messages.Add("email");
            if (existingSupplier.ContactNumber == supplierDto.ContactNumber)
                messages.Add("contact number");

            var duplicateProps = string.Join(" and ", messages);
            throw new DuplicateEntityException($"A supplier with the same {duplicateProps} already exists.");
        }

        // Apply updates from DTO to entity
        UpdateHelper.ApplyUpdates(supplierDto, supplier);

        await _supplierRepository.UpdateAsync(supplier);
        return _mapper.Map<SupplierDto>(supplier);
    }

    public async Task<bool?> DeleteSupplierAsync(int id)
    {
        var supplier = await _supplierRepository.GetByIdAsync(id);

        if (supplier == null) return null;

        var hasProducts = supplier.Products?.Count > 0;

        if (hasProducts) return false;

        await _supplierRepository.DeleteAsync(supplier);
        return true;
    }
}
