import { createContext, Dispatch, SetStateAction, useContext, ReactNode } from 'react';
import { Customer } from '../../../types';

interface CustomersContextType {
    openDialog: {
        addCustomer: boolean;
        editCustomer: boolean;
        deleteCustomer: boolean;
    };
    setOpenDialog: Dispatch<SetStateAction<{
        addCustomer: boolean;
        editCustomer: boolean;
        deleteCustomer: boolean;
    }>>;
    selectedCustomer: Customer | undefined;
    setSelectedCustomer: Dispatch<SetStateAction<Customer | undefined>>;
    handleAddCustomerSuccess: (newCustomer: Customer) => void;
    handleEditCustomerSuccess: (updatedCustomer: Customer) => void;
    handleDeleteCustomerSuccess: () => void;
    setError: Dispatch<SetStateAction<string | null>>;
}

const CustomersContext = createContext<CustomersContextType | undefined>(undefined);

export const useCustomersContext = () => {
    const context = useContext(CustomersContext);
    if (!context) {
        throw new Error('useCustomersContext must be used within a CustomersProvider');
    }
    return context;
};

export const CustomersContextProvider = ({ children, value }: { children: ReactNode; value: CustomersContextType }) => (
    <CustomersContext.Provider value={value}>
        {children}
    </CustomersContext.Provider>
);
