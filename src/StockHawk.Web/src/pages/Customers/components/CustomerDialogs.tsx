import { AddCustomerDialog, EditCustomerDialog } from ".";
import { DeleteConfirmationDialog } from "../../../components";
import { useCustomersContext } from "../context";

export const CustomerDialogs: React.FC = () => {
    const { openDialog, setOpenDialog, selectedCustomer, handleAddCustomerSuccess, handleDeleteCustomerSuccess, handleEditCustomerSuccess, setError } = useCustomersContext();

    return (
        <>
            <AddCustomerDialog
                open={openDialog.addCustomer}
                onClose={() => setOpenDialog(prevState => ({ ...prevState, addCustomer: false }))}
                onSuccess={(newCustomer) => handleAddCustomerSuccess(newCustomer)}
                setError={setError}
            />
            {selectedCustomer && openDialog.deleteCustomer && (
                <DeleteConfirmationDialog
                    open={openDialog.deleteCustomer}
                    onClose={() => setOpenDialog(prevState => ({ ...prevState, deleteCustomer: false }))}
                    onDelete={() => handleDeleteCustomerSuccess()}
                    title="Delete customer"
                    message="Are you sure you want to delete this customer?"
                />
            )}
            {selectedCustomer && openDialog.editCustomer && (
                <EditCustomerDialog
                    open={openDialog.editCustomer}
                    onClose={() => setOpenDialog(prevState => ({ ...prevState, editCustomer: false }))}
                    onSuccess={(updatedCustomer) => handleEditCustomerSuccess(updatedCustomer)}
                    customer={selectedCustomer}
                />
            )}
        </>
    );
};
