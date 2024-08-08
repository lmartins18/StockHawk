import { AxiosError } from "axios";
import { useState } from "react";
import { NotificationSnackbar } from "../../components";
import { CustomDataGridWithEditAndDelete, CustomDataGridBottomBar } from "../../components/CustomDataGrid";
import { Customer } from "../../types";
import { apiClient, handleApiError } from "../../utils";
import { AddCustomerButton, CustomerDialogs } from "./components";
import { CustomersContextProvider } from "./context";
import { useCustomersData, customerColumns } from "./data";

export const CustomersPage: React.FC = () => {
    const { customers, loading, error, setCustomers, setError } = useCustomersData();
    const [successMessage, setSuccessMessage] = useState<string | null>(null);
    const [openDialog, setOpenDialog] = useState({
        addCustomer: false,
        editCustomer: false,
        deleteCustomer: false,
    });
    const [selectedCustomer, setSelectedCustomer] = useState<Customer | undefined>(undefined);

    const handleEdit = (customerId: number) => {
        setSelectedCustomer(customers.find((c) => c.id === customerId));
        setOpenDialog({ addCustomer: false, editCustomer: true, deleteCustomer: false });
    };

    const handleDelete = (customerId: number) => {
        setSelectedCustomer(customers.find((c) => c.id === customerId));
        setOpenDialog({ addCustomer: false, editCustomer: false, deleteCustomer: true });
    };

    const handleAddCustomerSuccess = (newCustomer: Customer) => {
        setCustomers([...customers, newCustomer]);
        setSuccessMessage('Customer added successfully.');
    };

    const handleEditCustomerSuccess = (updatedCustomer: Customer) => {
        setCustomers(customers.map(customer => customer.id === updatedCustomer.id ? updatedCustomer : customer));
        setSuccessMessage('Customer updated successfully.');
    };

    const handleDeleteCustomerSuccess = async () => {
        if (!selectedCustomer) return;

        try {
            await apiClient.delete(`/api/customers/${selectedCustomer.id}`);
            setCustomers(customers.filter(customer => customer.id !== selectedCustomer.id));
            setSuccessMessage('Customer deleted successfully.');
        } catch (error) {
            handleApiError(error as AxiosError, setError);
        }
        setOpenDialog(prevState => ({ ...prevState, deleteCustomer: false }));
    };

    return (
        <CustomersContextProvider
            value={{
                openDialog,
                setOpenDialog,
                selectedCustomer,
                setSelectedCustomer,
                handleAddCustomerSuccess,
                handleEditCustomerSuccess,
                handleDeleteCustomerSuccess,
                setError,
            }}
        >
            <div className="flex flex-col w-full flex-1 overflow-auto">
                <CustomDataGridWithEditAndDelete
                    loading={loading}
                    rows={customers}
                    columns={customerColumns}
                    onEdit={handleEdit}
                    onDelete={handleDelete}
                />
                <CustomDataGridBottomBar>
                    <AddCustomerButton />
                </CustomDataGridBottomBar>
                <CustomerDialogs />
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
        </CustomersContextProvider>
    );
};
