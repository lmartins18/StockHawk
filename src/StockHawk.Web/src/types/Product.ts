export interface Product {
    id: number;
    name: string;
    description: string;
    price: number;
    quantity: number;
    lowStockThreshold: number;
    category: {
        id: number;
        name: string;
        description: string;
    };
    supplier: {
        id: number;
        name: string;
        contactNumber: string;
        email: string;
        address: string;
    };
}