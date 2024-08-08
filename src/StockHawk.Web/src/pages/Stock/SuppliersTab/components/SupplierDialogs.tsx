import React from 'react';
import { AddSupplierDialog, EditSupplierDialog } from '.';
import { DeleteConfirmationDialog } from '../../../../components';
import { useSuppliersContext } from '../context';

export const SupplierDialogs: React.FC = () => {
    const { openDialog, selectedSupplier, handleAddSupplierSuccess, handleEditSupplierSuccess, handleDeleteSupplierSuccess, setOpenDialog } = useSuppliersContext();

    return (
        <>
            <AddSupplierDialog
                open={openDialog.addSupplier}
                onClose={() => setOpenDialog(prevState => ({ ...prevState, addSupplier: false }))}
                onSuccess={handleAddSupplierSuccess}
            />
            {selectedSupplier && openDialog.editSupplier && (
                <EditSupplierDialog
                    open={openDialog.editSupplier}
                    onClose={() => setOpenDialog(prevState => ({ ...prevState, editSupplier: false }))}
                    onSuccess={handleEditSupplierSuccess}
                    supplier={selectedSupplier}
                />
            )}
            {selectedSupplier && openDialog.deleteSupplier && (
                <DeleteConfirmationDialog
                    open={openDialog.deleteSupplier}
                    onClose={() => setOpenDialog(prevState => ({ ...prevState, deleteSupplier: false }))}
                    onDelete={handleDeleteSupplierSuccess}
                    title={"Delete Supplier"}
                    message={"Are you sure you want to delete this supplier?"}
                />
            )}
        </>
    );
};
