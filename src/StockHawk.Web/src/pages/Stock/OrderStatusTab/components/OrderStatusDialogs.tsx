import React from 'react';
import { AddOrderStatusDialog, EditOrderStatusDialog, } from '.';
import { DeleteConfirmationDialog } from '../../../../components';
import { useOrderStatusContext } from '../context';

export const OrderStatusDialogs: React.FC = () => {
    const { openDialog, selectedOrderStatus, handleAddOrderStatusSuccess, handleEditOrderStatusSuccess, handleDeleteOrderStatusSuccess, setOpenDialog } = useOrderStatusContext();

    return (
        <>
            <AddOrderStatusDialog
                open={openDialog.addOrderStatus}
                onClose={() => setOpenDialog(prevState => ({ ...prevState, addOrderStatus: false }))}
                onSuccess={handleAddOrderStatusSuccess}
            />
            {selectedOrderStatus && openDialog.editOrderStatus && (
                <EditOrderStatusDialog
                    open={openDialog.editOrderStatus}
                    onClose={() => setOpenDialog(prevState => ({ ...prevState, editOrderStatus: false }))}
                    onSuccess={handleEditOrderStatusSuccess}
                    orderStatus={selectedOrderStatus}
                />
            )}
            {selectedOrderStatus && openDialog.deleteOrderStatus && (
                <DeleteConfirmationDialog
                    open={openDialog.deleteOrderStatus}
                    onClose={() => setOpenDialog(prevState => ({ ...prevState, deleteOrderStatus: false }))}
                    onDelete={handleDeleteOrderStatusSuccess}
                    title={"Delete Order Status"}
                    message={"Are you sure you want to delete this order status?"}
                />
            )}
        </>
    );
};
