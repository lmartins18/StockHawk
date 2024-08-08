import React, { createContext, useContext, ReactNode } from 'react';
import { CreateOrderTypeDto, OrderType } from '../../../../types';

interface OrderTypesContextType {
    openDialog: { addOrderType: boolean; editOrderType: boolean; deleteOrderType: boolean };
    setOpenDialog: React.Dispatch<React.SetStateAction<{ addOrderType: boolean; editOrderType: boolean; deleteOrderType: boolean }>>;
    handleAddOrderType: (newOrderType: CreateOrderTypeDto) => void;
    selectedOrderType: OrderType | undefined;
    handleEditOrderTypeSuccess: (updatedOrderType: OrderType) => void;
    handleDeleteOrderTypeSuccess: () => void;
    error: string | null;
    setError: React.Dispatch<React.SetStateAction<string | null>>;
}

const OrderTypesContext = createContext<OrderTypesContextType | undefined>(undefined);

export const OrderTypesContextProvider: React.FC<{ value: OrderTypesContextType; children: ReactNode }> = ({ value, children }) => {
    return <OrderTypesContext.Provider value={value}>{children}</OrderTypesContext.Provider>;
};

export const useOrderTypesContext = () => {
    const context = useContext(OrderTypesContext);
    if (context === undefined) {
        throw new Error('useOrderTypesContext must be used within a OrderTypesContextProvider');
    }
    return context;
};
