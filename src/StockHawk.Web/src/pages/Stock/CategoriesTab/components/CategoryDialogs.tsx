import { DeleteConfirmationDialog } from '../../../../components';
import { useCategoriesContext } from '../context';
import { AddCategoryDialog, EditCategoryDialog } from ".";


export const CategoryDialogs: React.FC = () => {
    const {
        openDialog,
        setOpenDialog,
        selectedCategory,
        handleEditCategorySuccess,
        handleDeleteCategorySuccess,
        handleAddCategorySuccess,
        setError
    } = useCategoriesContext();

    return (
        <>
            <AddCategoryDialog
                open={openDialog.addCategory}
                onClose={() => setOpenDialog(prevState => ({ ...prevState, addCategory: false }))}
                onSuccess={handleAddCategorySuccess}
                setError={setError}
            />
            {selectedCategory && openDialog.editCategory && (
                <EditCategoryDialog
                    open={openDialog.editCategory}
                    onClose={() => setOpenDialog(prev => ({ ...prev, editCategory: false }))}
                    onSuccess={handleEditCategorySuccess}
                    category={selectedCategory}
                />
            )}
            {selectedCategory && openDialog.deleteCategory && (
                <DeleteConfirmationDialog
                    open={openDialog.deleteCategory}
                    onClose={() => setOpenDialog(prev => ({ ...prev, deleteCategory: false }))}
                    onDelete={handleDeleteCategorySuccess}
                    title="Category"
                    message="Are you sure you want to delete this category?"
                />
            )}
        </>
    );
};
