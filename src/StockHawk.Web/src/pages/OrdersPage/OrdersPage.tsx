import { useState } from "react";
import { NotificationSnackbar } from "../../components";
import { CustomDataGridWithViewDetails, CustomDataGridBottomBar } from "../../components/CustomDataGrid";
import { Order } from "../../types";
import { AddOrderButton, OrderDialogs } from "./components";
import { OrdersContextProvider } from "./context";
import { useOrdersData, orderColumns } from "./data";

export const OrdersPage: React.FC = () => {
    const { orders, loading, error, setOrders, setError } = useOrdersData();
    const [successMessage, setSuccessMessage] = useState<string | null>(null);
    const [openDialog, setOpenDialog] = useState({
        addOrder: false,
        editOrder: false,
    });
    const [selectedOrder, setSelectedOrder] = useState<Order | undefined>(undefined);

    const handleViewDetails = (id: number) => {
        const order = orders.find(o => o.id === id);
        if (order) {
            setSelectedOrder(order);
            setOpenDialog({ addOrder: false, editOrder: true });
        }
    };

    const handleAddOrderSuccess = (newOrder: Order) => {
        setOrders([...orders, newOrder]);
        setSuccessMessage('Order added successfully.');
    };

    const handleEditOrderSuccess = (updatedOrder: Order) => {
        setOrders(orders.map(order => order.id === updatedOrder.id ? updatedOrder : order));
        setSuccessMessage('Order updated successfully.');
    };

    return (
        <OrdersContextProvider
            value={{
                openDialog,
                setOpenDialog,
                selectedOrder,
                handleAddOrderSuccess,
                handleEditOrderSuccess,
                setError,
            }}
        >
            <div className="flex flex-col w-full flex-1 overflow-auto">
                <CustomDataGridWithViewDetails
                    loading={loading}
                    rows={orders}
                    columns={orderColumns}
                    onViewDetails={handleViewDetails}
                />
                <CustomDataGridBottomBar>
                    <AddOrderButton />
                </CustomDataGridBottomBar>
                <OrderDialogs />
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
        </OrdersContextProvider>
    );
};
