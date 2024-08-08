import { AddProductDialog, EditProductDialog } from ".";
import { DeleteConfirmationDialog } from "../../../components";
import { mapProductToEditProductDto } from "../../../mappings";
import { useProductsContext } from "../context";

export const ProductDialogs: React.FC = () => {
    const {
        openDialog,
        setOpenDialog,
        selectedProduct,
        handleAddProductSuccess,
        handleEditProductSuccess,
        handleDeleteProduct,
        setError,
    } = useProductsContext();

    return (
        <>
            <AddProductDialog
                open={openDialog.addProduct}
                onClose={() => setOpenDialog(prevState => ({ ...prevState, addProduct: false }))}
                onSuccess={handleAddProductSuccess}
                setError={setError}
            />
            {selectedProduct && openDialog.editProduct && (
                <EditProductDialog
                    open={openDialog.editProduct}
                    onClose={() => setOpenDialog(prevState => ({ ...prevState, editProduct: false }))}
                    onSuccess={handleEditProductSuccess}
                    product={mapProductToEditProductDto(selectedProduct)}
                    setError={setError}
                />
            )}
            {selectedProduct && openDialog.deleteProduct && (
                <DeleteConfirmationDialog
                    open={openDialog.deleteProduct}
                    onClose={() => setOpenDialog(prevState => ({ ...prevState, deleteProduct: false }))}
                    onDelete={handleDeleteProduct}
                    title="Delete Product"
                    message="Are you sure you want to delete this product?"
                />
            )}
        </>
    );
};
