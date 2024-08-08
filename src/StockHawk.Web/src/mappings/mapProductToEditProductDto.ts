import { Product, EditProductDto } from '../types';

export const mapProductToEditProductDto = (product: Product): EditProductDto => ({
    id: product.id,
    name: product.name,
    description: product.description,
    price: product.price,
    quantity: product.quantity,
    lowStockThreshold: product.lowStockThreshold,
    categoryId: product.category.id,
    supplierId: product.supplier.id,
});