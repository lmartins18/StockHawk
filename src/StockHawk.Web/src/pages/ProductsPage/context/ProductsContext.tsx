import { createContext, Dispatch, SetStateAction, useContext, ReactNode } from 'react';
import { Product } from '../../../types';

interface ProductsContextType {
    openDialog: {
        addProduct: boolean;
        editProduct: boolean;
        deleteProduct: boolean;
    };
    setOpenDialog: Dispatch<SetStateAction<{
        addProduct: boolean;
        editProduct: boolean;
        deleteProduct: boolean;
    }>>;
    selectedProduct: Product | undefined;
    handleAddProductSuccess: (newProduct: Product) => void;
    handleEditProductSuccess: (updatedProduct: Product) => void;
    handleDeleteProduct: () => void;
    setError: Dispatch<SetStateAction<string | null>>;
}

const ProductsContext = createContext<ProductsContextType | undefined>(undefined);

export const useProductsContext = () => {
    const context = useContext(ProductsContext);
    if (!context) {
        throw new Error('useProductsContext must be used within a ProductsProvider');
    }
    return context;
};

export const ProductsContextProvider = ({ children, value }: { children: ReactNode; value: ProductsContextType }) =>
(
    <ProductsContext.Provider value={value}>
        {children}
    </ProductsContext.Provider>
)