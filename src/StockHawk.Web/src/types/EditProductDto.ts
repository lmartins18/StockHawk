export interface EditProductDto {
    id: number;
    name: string;
    description: string;
    price: number;
    quantity: number;
    lowStockThreshold: number;
    categoryId: number;
    supplierId: number;
}