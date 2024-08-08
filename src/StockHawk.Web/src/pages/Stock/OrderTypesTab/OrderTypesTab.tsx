import { AxiosError } from "axios";
import { useState } from "react";
import { NotificationSnackbar } from "../../../components";
import { CustomDataGridWithEditAndDelete, CustomDataGridBottomBar } from "../../../components/CustomDataGrid";
import { OrderType, CreateOrderTypeDto } from "../../../types";
import { apiClient, handleApiError } from "../../../utils";
import { AddOrderTypeButton, OrderTypesDialogs } from "./components";
import { OrderTypesContextProvider } from "./context";
import { orderTypeColumns } from "./data";
import { useOrderTypeData } from "./data/useOrderTypeData";

export const OrderTypesTab = () => {
    const { orderTypes, loading, setOrderTypes, setError, error } = useOrderTypeData();
    const [openDialog, setOpenDialog] = useState({ addOrderType: false, editOrderType: false, deleteOrderType: false });
    const [successMessage, setSuccessMessage] = useState<string | null>(null);
    const [selectedOrderType, setSelectedOrderType] = useState<OrderType | undefined>();

    const handleAddOrderType = async (newOrderType: CreateOrderTypeDto) => {
        try {
            const response = await apiClient.post<OrderType>('/api/order-types', newOrderType);
            setOrderTypes((prevOrderTypes) => [...prevOrderTypes, response.data]);
            setSuccessMessage('Order Type added successfully.');
            setOpenDialog((prev) => ({ ...prev, addOrderType: false }));
        } catch (error) {
            handleApiError(error as AxiosError, setError);
            console.error('Failed to add order type:', error);
        }
    };

    const handleEdit = (orderTypeId: number) => {
        setSelectedOrderType(orderTypes.find((s) => s.id === orderTypeId));
        setOpenDialog(prev => ({ ...prev, editOrderType: true }));
    };

    const handleDelete = (orderTypeId: number) => {
        setSelectedOrderType(orderTypes.find((s) => s.id === orderTypeId));
        setOpenDialog(prev => ({ ...prev, deleteOrderType: true }));
    };

    const handleEditOrderTypeSuccess = async (updatedOrderType: OrderType) => {
        try {
            const response = await apiClient.put<OrderType>(`/api/order-types/${updatedOrderType.id}`, updatedOrderType);
            setOrderTypes(orderTypes.map(type => type.id === updatedOrderType.id ? response.data : type));
            setSuccessMessage('Order Type updated successfully.');

        } catch (error) {
            setError('Failed to update order type.');
        } finally {
            setOpenDialog((prev) => ({ ...prev, addOrderType: false }));
            setSelectedOrderType(undefined);
        }
    };

    const handleDeleteOrderTypeSuccess = async () => {
        try {
            if (selectedOrderType) {
                await apiClient.delete(`/api/order-types/${selectedOrderType.id}`);
                setOrderTypes(orderTypes.filter(type => type.id !== selectedOrderType.id));
                setSuccessMessage('Order Type deleted successfully.');
            }
        } catch (error) {
            handleApiError(error as AxiosError, setError);
        } finally {
            setOpenDialog({ addOrderType: false, editOrderType: false, deleteOrderType: false });
            setSelectedOrderType(undefined);
        }
    };

    return (
        <OrderTypesContextProvider value={{ openDialog, setOpenDialog, selectedOrderType, handleAddOrderType, handleEditOrderTypeSuccess, handleDeleteOrderTypeSuccess, error, setError }}>
            <div className="flex flex-col w-full flex-1 overflow-auto">
                <CustomDataGridWithEditAndDelete
                    loading={loading}
                    rows={orderTypes}
                    columns={orderTypeColumns}
                    onEdit={handleEdit}
                    onDelete={handleDelete}
                />
                <CustomDataGridBottomBar>
                    <AddOrderTypeButton />
                </CustomDataGridBottomBar>
                <OrderTypesDialogs />
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
        </OrderTypesContextProvider>
    );
};
