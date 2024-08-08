export interface CreateProductDto {
    Name: string;
    Description: string;
    Price: number;
    Quantity: number;
    LowStockThreshold: number;
    CategoryId: number;
    SupplierId: number;
}
