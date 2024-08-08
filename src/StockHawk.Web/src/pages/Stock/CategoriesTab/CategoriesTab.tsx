import { AxiosError } from "axios";
import { useState } from "react";
import { NotificationSnackbar } from "../../../components";
import { CustomDataGridWithEditAndDelete, CustomDataGridBottomBar } from "../../../components/CustomDataGrid";
import { Category } from "../../../types";
import { apiClient, handleApiError } from "../../../utils";
import { AddCategoryButton, CategoryDialogs } from "./components";
import { CategoriesContextProvider } from "./context";
import { useCategoriesData, categoryColumns } from "./data";


export const CategoriesTab: React.FC = () => {
    const { categories, loading, error, setCategories, setError } = useCategoriesData();
    const [successMessage, setSuccessMessage] = useState<string | null>(null);
    const [dialogState, setDialogState] = useState({
        addCategory: false,
        editCategory: false,
        deleteCategory: false,
    });
    const [selectedCategory, setSelectedCategory] = useState<Category | undefined>(undefined);

    const handleAddCategorySuccess = (newCategory: Category) => {
        setCategories(prevCategories => [...prevCategories, newCategory]);
        setSuccessMessage('Category added successfully.');
    };

    const handleEditCategorySuccess = (updatedCategory: Category) => {
        setCategories(prevCategories =>
            prevCategories.map(category =>
                category.id === updatedCategory.id ? updatedCategory : category
            )
        );
        setSuccessMessage('Category updated successfully.');
    };

    const handleDeleteCategorySuccess = async () => {
        if (!selectedCategory) return;

        try {
            await apiClient.delete(`/api/categories/${selectedCategory.id}`);
            setCategories(prevCategories =>
                prevCategories.filter(category => category.id !== selectedCategory.id)
            );
            setSuccessMessage('Category deleted successfully.');
        } catch (error) {
            handleApiError(error as AxiosError, setError);
        } finally {
            setDialogState(prevState => ({ ...prevState, deleteCategory: false }));
        }
    };


    return (
        <CategoriesContextProvider
            value={{
                openDialog: dialogState,
                setOpenDialog: setDialogState,
                selectedCategory,
                setSelectedCategory,
                handleAddCategorySuccess,
                handleEditCategorySuccess,
                handleDeleteCategorySuccess,
                setError,
            }}
        >
            <div className="flex flex-col w-full flex-1 overflow-auto">
                <CustomDataGridWithEditAndDelete
                    loading={loading}
                    rows={categories}
                    columns={categoryColumns}
                    onEdit={(id) => {
                        setSelectedCategory(categories.find(c => c.id === id));
                        setDialogState({ addCategory: false, editCategory: true, deleteCategory: false });
                    }}
                    onDelete={(id) => {
                        setSelectedCategory(categories.find(c => c.id === id));
                        setDialogState({ addCategory: false, editCategory: false, deleteCategory: true });
                    }}
                />
                <CustomDataGridBottomBar>
                    <AddCategoryButton />
                </CustomDataGridBottomBar>
                <CategoryDialogs />
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
        </CategoriesContextProvider>
    );
};
