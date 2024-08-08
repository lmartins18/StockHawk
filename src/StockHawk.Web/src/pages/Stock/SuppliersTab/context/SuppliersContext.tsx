import React, { createContext, useContext, ReactNode } from 'react';
import { Supplier } from '../../../../types';

interface SuppliersContextType {
    openDialog: { addSupplier: boolean; editSupplier: boolean; deleteSupplier: boolean };
    setOpenDialog: React.Dispatch<React.SetStateAction<{ addSupplier: boolean; editSupplier: boolean; deleteSupplier: boolean }>>;
    selectedSupplier: Supplier | undefined;
    handleAddSupplierSuccess: (newSupplier: Supplier) => void;
    handleEditSupplierSuccess: (updatedSupplier: Supplier) => void;
    handleDeleteSupplierSuccess: () => void;
    setError: React.Dispatch<React.SetStateAction<string | null>>;
}

const SuppliersContext = createContext<SuppliersContextType | undefined>(undefined);

export const SuppliersContextProvider: React.FC<{ value: SuppliersContextType; children: ReactNode }> = ({ value, children }) => {
    return <SuppliersContext.Provider value={value}>{children}</SuppliersContext.Provider>;
};

export const useSuppliersContext = () => {
    const context = useContext(SuppliersContext);
    if (context === undefined) {
        throw new Error('useSuppliersContext must be used within a SuppliersContextProvider');
    }
    return context;
};
