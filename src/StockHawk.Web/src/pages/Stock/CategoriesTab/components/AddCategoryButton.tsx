import { useCategoriesContext } from '../context';
import Button from '@mui/material/Button';

export const AddCategoryButton: React.FC = () => {
    const { setOpenDialog: setDialogState } = useCategoriesContext();

    return (
        <Button
            variant="contained"
            color="primary"
            onClick={() => setDialogState(prev => ({ ...prev, addCategory: true }))}
        >
            Add Category
        </Button>
    );
};
