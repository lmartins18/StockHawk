import { AxiosError } from "axios";
import { useState } from "react";
import { NotificationSnackbar } from "../../../components";
import { CustomDataGridWithEditAndDelete, CustomDataGridBottomBar } from "../../../components/CustomDataGrid";
import { OrderStatus } from "../../../types";
import { apiClient, handleApiError } from "../../../utils";
import { AddOrderStatusButton } from "./components";
import { OrderStatusDialogs } from "./components/OrderStatusDialogs";
import { OrderStatusContextProvider } from "./context";
import { useOrderStatusData, orderStatusColumns } from "./data";


export const OrderStatusTab: React.FC = () => {
    const { orderStatuses, loading, error, setOrderStatuses, setError } = useOrderStatusData();
    const [successMessage, setSuccessMessage] = useState<string | null>(null);
    const [openDialog, setOpenDialog] = useState({
        addOrderStatus: false,
        editOrderStatus: false,
        deleteOrderStatus: false,
    });
    const [selectedOrderStatus, setSelectedOrderStatus] = useState<OrderStatus | undefined>(undefined);

    const handleAddOrderStatusSuccess = (newOrderStatus: OrderStatus) => {
        setOrderStatuses((prevOrderStatuses) => [...prevOrderStatuses, newOrderStatus]);
        setSuccessMessage('Order Status added successfully.');
    };

    const handleEdit = (orderStatusId: number) => {
        setSelectedOrderStatus(orderStatuses.find((s) => s.id === orderStatusId));
        setOpenDialog({ addOrderStatus: false, editOrderStatus: true, deleteOrderStatus: false });
    };

    const handleDelete = (orderStatusId: number) => {
        setSelectedOrderStatus(orderStatuses.find((s) => s.id === orderStatusId));
        setOpenDialog({ addOrderStatus: false, editOrderStatus: false, deleteOrderStatus: true });
    };

    const handleEditOrderStatusSuccess = async (updatedOrderStatus: OrderStatus) => {
        try {
            const response = await apiClient.put<OrderStatus>(`/api/order-statuses/${updatedOrderStatus.id}`, updatedOrderStatus);
            setOrderStatuses(orderStatuses.map(status => status.id === updatedOrderStatus.id ? response.data : status));
            setSuccessMessage('Order Status updated successfully.');
        } catch (error) {
            handleApiError(error as AxiosError, setError);
        } finally {
            setOpenDialog({ addOrderStatus: false, editOrderStatus: false, deleteOrderStatus: false });
            setSelectedOrderStatus(undefined);
        }
    };

    const handleDeleteOrderStatusSuccess = async () => {
        try {
            if (selectedOrderStatus) {
                await apiClient.delete(`/api/order-statuses/${selectedOrderStatus.id}`);
                setOrderStatuses(orderStatuses.filter(status => status.id !== selectedOrderStatus.id));
                setSuccessMessage('Order Status deleted successfully.');
            }
        } catch (error) {
            handleApiError(error as AxiosError, setError);
        } finally {
            setOpenDialog({ addOrderStatus: false, editOrderStatus: false, deleteOrderStatus: false });
            setSelectedOrderStatus(undefined);
        }
    };

    return (
        <OrderStatusContextProvider
            value={{
                openDialog,
                setOpenDialog,
                selectedOrderStatus,
                handleAddOrderStatusSuccess,
                handleEditOrderStatusSuccess,
                handleDeleteOrderStatusSuccess,
                setError,
            }}
        >
            <div className="flex flex-col w-full flex-1 overflow-auto">
                <CustomDataGridWithEditAndDelete
                    loading={loading}
                    rows={orderStatuses}
                    columns={orderStatusColumns}
                    onEdit={handleEdit}
                    onDelete={handleDelete}
                />
                <CustomDataGridBottomBar>
                    <AddOrderStatusButton />
                </CustomDataGridBottomBar>
                <OrderStatusDialogs />
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
        </OrderStatusContextProvider>
    );
};
