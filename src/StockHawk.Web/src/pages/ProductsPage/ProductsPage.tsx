import { AxiosError } from "axios";
import { useState } from "react";
import { NotificationSnackbar } from "../../components";
import { CustomDataGridWithEditAndDelete, CustomDataGridBottomBar } from "../../components/CustomDataGrid";
import { Product } from "../../types";
import { apiClient, handleApiError } from "../../utils";
import { AddProductButton, ProductDialogs } from "./components";
import { ProductsContextProvider } from "./context";
import { useProductsData, productColumns } from "./data";


export const ProductsPage: React.FC = () => {
    const { products, loading, setLoading, error, setProducts, setError } = useProductsData();
    const [successMessage, setSuccessMessage] = useState<string | null>(null);
    const [openDialog, setOpenDialog] = useState({
        addProduct: false,
        editProduct: false,
        deleteProduct: false,
    });
    const [selectedProduct, setSelectedProduct] = useState<Product | undefined>(undefined);

    const handleEdit = (productId: number) => {
        setSelectedProduct(products.find((p) => p.id === productId));
        setOpenDialog({ addProduct: false, editProduct: true, deleteProduct: false });
    };

    const handleDelete = (productId: number) => {
        setSelectedProduct(products.find((p) => p.id === productId));
        setOpenDialog({ addProduct: false, editProduct: false, deleteProduct: true });
    };

    const handleAddProductSuccess = (newProduct: Product) => {
        setProducts([...products, newProduct]);
        setSuccessMessage('Product added successfully.');
        setOpenDialog({ addProduct: false, editProduct: false, deleteProduct: false });
    };

    const handleEditProductSuccess = (updatedProduct: Product) => {
        setProducts(products.map(product => product.id === updatedProduct.id ? updatedProduct : product));
        setSuccessMessage('Product updated successfully.');
    };

    const handleDeleteProduct = async () => {
        if (!selectedProduct) return;

        setLoading(true);

        try {
            await apiClient.delete(`/api/products/${selectedProduct.id}`);
            setProducts(prevProducts => prevProducts.filter(product => product.id !== selectedProduct.id));
            setOpenDialog(prevState => ({ ...prevState, deleteProduct: false }));
            setSuccessMessage('Product deleted successfully.');
        } catch (error) {
            handleApiError(error as AxiosError, setError);
        } finally {
            setLoading(false);
        }
    };

    return (
        <ProductsContextProvider
            value={{
                openDialog,
                setOpenDialog,
                selectedProduct,
                handleAddProductSuccess,
                handleEditProductSuccess,
                handleDeleteProduct,
                setError,
            }}
        >
            <div className="flex flex-col w-full flex-1 overflow-auto">
                <CustomDataGridWithEditAndDelete
                    loading={loading}
                    rows={products}
                    columns={productColumns}
                    onEdit={handleEdit}
                    onDelete={handleDelete}
                />
                <CustomDataGridBottomBar>
                    <AddProductButton />
                </CustomDataGridBottomBar>
                <ProductDialogs />
                <NotificationSnackbar
                    open={Boolean(successMessage || error)}
                    message={successMessage || error}
                    onClose={() => {
                        setSuccessMessage(null);
                        setError(null);
                    }}
                    severity={error ? 'error' : 'success'}
                />
            </div>
        </ProductsContextProvider>
    );
};
