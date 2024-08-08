import { useState } from "react";
import { AxiosError } from "axios";
import { CustomDataGridWithEditAndDelete, CustomDataGridBottomBar } from "../../../components/CustomDataGrid";
import { AddSupplierButton, SupplierDialogs } from "./components";
import { Supplier } from "../../../types";
import { SuppliersContextProvider } from "./context";
import { useSuppliersData, supplierColumns } from "./data";
import { apiClient, handleApiError } from "../../../utils";
import { NotificationSnackbar } from "../../../components";

export const SuppliersTab: React.FC = () => {
    const { suppliers, loading, error, setSuppliers, setError } = useSuppliersData();
    const [successMessage, setSuccessMessage] = useState<string | null>(null);
    const [openDialog, setOpenDialog] = useState({
        addSupplier: false,
        editSupplier: false,
        deleteSupplier: false,
    });
    const [selectedSupplier, setSelectedSupplier] = useState<Supplier | undefined>(undefined);

    const handleEdit = (supplierId: number) => {
        setSelectedSupplier(suppliers.find((s) => s.id === supplierId));
        setOpenDialog({ addSupplier: false, editSupplier: true, deleteSupplier: false });
    };

    const handleDelete = (supplierId: number) => {
        setSelectedSupplier(suppliers.find((s) => s.id === supplierId));
        setOpenDialog({ addSupplier: false, editSupplier: false, deleteSupplier: true });
    };

    const handleAddSupplierSuccess = (newSupplier: Supplier) => {
        setSuppliers([...suppliers, newSupplier]);
        setSuccessMessage('Supplier added successfully.');
    };

    const handleEditSupplierSuccess = (updatedSupplier: Supplier) => {
        setSuppliers(suppliers.map(supplier => supplier.id === updatedSupplier.id ? updatedSupplier : supplier));
        setSuccessMessage('Supplier updated successfully.');
    };

    const handleDeleteSupplierSuccess = async () => {
        if (!selectedSupplier) return;

        try {
            await apiClient.delete(`/api/suppliers/${selectedSupplier.id}`);
            setSuppliers(suppliers.filter(supplier => supplier.id !== selectedSupplier.id));
            setSuccessMessage('Supplier deleted successfully.');
        } catch (error) {
            handleApiError(error as AxiosError, setError);
        }
        setOpenDialog(prevState => ({ ...prevState, deleteSupplier: false }));
    };

    return (
        <SuppliersContextProvider
            value={{
                openDialog,
                setOpenDialog,
                selectedSupplier,
                handleAddSupplierSuccess,
                handleEditSupplierSuccess,
                handleDeleteSupplierSuccess,
                setError,
            }}
        >
            <div className="flex flex-col w-full flex-1 overflow-auto">
                <CustomDataGridWithEditAndDelete
                    loading={loading}
                    rows={suppliers}
                    columns={supplierColumns}
                    onEdit={handleEdit}
                    onDelete={handleDelete}
                />
                <CustomDataGridBottomBar>
                    <AddSupplierButton />
                </CustomDataGridBottomBar>
                <SupplierDialogs />
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
        </SuppliersContextProvider>
    );
};
