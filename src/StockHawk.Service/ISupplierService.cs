using StockHawk.Service.DTOs;

namespace StockHawk.Service;

public interface ISupplierService
{
    Task<IEnumerable<SupplierDto>> GetAllSuppliersAsync();
    Task<SupplierDto?> GetSupplierByIdAsync(int id);
    Task<SupplierDto> AddSupplierAsync(CreateSupplierDto supplierDto);
    Task<SupplierDto?> UpdateSupplierAsync(SupplierDto supplierDto);
    
    /// <returns>Null if no Supplier found, false if it has products associated, and true if deleted</returns>
    Task<bool?> DeleteSupplierAsync(int id);
}