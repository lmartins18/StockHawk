import React, { createContext, ReactNode, useContext } from 'react';
import { Category } from '../../../../types';

interface CategoriesContextType {
    openDialog: {
        addCategory: boolean;
        editCategory: boolean;
        deleteCategory: boolean;
    };
    setOpenDialog: React.Dispatch<React.SetStateAction<{
        addCategory: boolean;
        editCategory: boolean;
        deleteCategory: boolean;
    }>>;
    selectedCategory: Category | undefined;
    setSelectedCategory: React.Dispatch<React.SetStateAction<Category | undefined>>;
    handleAddCategorySuccess: (newCategory: Category) => void;
    handleEditCategorySuccess: (updatedCategory: Category) => void;
    handleDeleteCategorySuccess: () => void;
    setError: React.Dispatch<React.SetStateAction<string | null>>;
}

const CategoriesContext = createContext<CategoriesContextType | undefined>(undefined);

export const useCategoriesContext = () => {
    const context = useContext(CategoriesContext);
    if (!context) {
        throw new Error('useCategoriesContext must be used within a CategoriesContextProvider');
    }
    return context;
};

interface CategoriesContextProviderProps {
    value: CategoriesContextType;
    children: ReactNode;
}

export const CategoriesContextProvider: React.FC<CategoriesContextProviderProps> = ({ value, children }) => {
    return (
        <CategoriesContext.Provider value={value}>
            {children}
        </CategoriesContext.Provider>
    );
};
