// components/OrderDialogs.tsx
import React from 'react';
import { useOrdersContext } from '../context/OrdersContext';
import { AddOrderDialog, OrderDetailsDialog } from '.';

export const OrderDialogs: React.FC = () => {
    const { openDialog, setOpenDialog, selectedOrder, handleAddOrderSuccess, handleEditOrderSuccess } = useOrdersContext();

    return (
        <>
            <AddOrderDialog
                open={openDialog.addOrder}
                onClose={() => setOpenDialog(prevState => ({ ...prevState, addOrder: false }))}
                onSuccess={handleAddOrderSuccess}
            />
            {selectedOrder && (
                <OrderDetailsDialog
                    open={openDialog.editOrder}
                    onClose={() => setOpenDialog(prevState => ({ ...prevState, editOrder: false }))}
                    orderId={selectedOrder.id}
                    onSuccess={handleEditOrderSuccess}
                />
            )}
        </>
    );
};
