import { createContext, useContext, ReactNode } from 'react';
import { Order } from '../../../types';

interface OrdersContextType {
    openDialog: { addOrder: boolean; editOrder: boolean; };
    setOpenDialog: React.Dispatch<React.SetStateAction<{ addOrder: boolean; editOrder: boolean; }>>;
    selectedOrder: Order | undefined;
    handleAddOrderSuccess: (newOrder: Order) => void;
    handleEditOrderSuccess: (updatedOrder: Order) => void;
    setError: React.Dispatch<React.SetStateAction<string | null>>;
}

const OrdersContext = createContext<OrdersContextType | undefined>(undefined);

export const useOrdersContext = () => {
    const context = useContext(OrdersContext);
    if (!context) {
        throw new Error('useOrdersContext must be used within an OrdersProvider');
    }
    return context;
};

export const OrdersContextProvider = ({ children, value }: { children: ReactNode; value: OrdersContextType }) => (
    <OrdersContext.Provider value={value}>{children}</OrdersContext.Provider>
);
