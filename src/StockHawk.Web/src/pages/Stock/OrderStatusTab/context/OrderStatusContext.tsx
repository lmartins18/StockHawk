import React, { createContext, useContext, ReactNode } from 'react';
import { OrderStatus } from '../../../../types';

interface OrderStatusContextType {
    openDialog: {
        addOrderStatus: boolean;
        editOrderStatus: boolean;
        deleteOrderStatus: boolean;
    };
    setOpenDialog: React.Dispatch<React.SetStateAction<{
        addOrderStatus: boolean;
        editOrderStatus: boolean;
        deleteOrderStatus: boolean;
    }>>;
    selectedOrderStatus: OrderStatus | undefined;
    handleAddOrderStatusSuccess: (newOrderStatus: OrderStatus) => void;
    handleEditOrderStatusSuccess: (updatedOrderStatus: OrderStatus) => void;
    handleDeleteOrderStatusSuccess: () => void;
    setError: React.Dispatch<React.SetStateAction<string | null>>;
}

const OrderStatusContext = createContext<OrderStatusContextType | undefined>(undefined);

export const OrderStatusContextProvider: React.FC<{ value: OrderStatusContextType; children: ReactNode }> = ({ value, children }) => {
    return <OrderStatusContext.Provider value={value}>{children}</OrderStatusContext.Provider>;
};

export const useOrderStatusContext = () => {
    const context = useContext(OrderStatusContext);
    if (context === undefined) {
        throw new Error('useOrderStatusContext must be used within an OrderStatusContextProvider');
    }
    return context;
};
