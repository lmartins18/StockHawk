import { Dialog, DialogTitle, DialogContent, TextField, DialogActions, Button } from "@mui/material";
import { AxiosError } from "axios";
import { useState, useEffect } from "react";
import { useForm } from "react-hook-form";
import { Category } from "../../../../types";
import { apiClient, handleApiError } from "../../../../utils";
import { FormErrorMessage } from "../../../../components";

interface EditCategoryDialogProps {
    open: boolean;
    onClose: () => void;
    onSuccess: (updatedCategory: Category) => void;
    category: Category;
}

export const EditCategoryDialog: React.FC<EditCategoryDialogProps> = ({ open, onClose, onSuccess, category }) => {
    const { register, handleSubmit, formState: { errors }, reset } = useForm<Category>({
        defaultValues: {
            name: category.name,
            description: category.description,
        }
    });
    const [apiError, setApiError] = useState<string | null>(null);

    useEffect(() => {
        reset(category);
    }, [category, reset]);

    const onSubmit = async (data: Category) => {
        try {
            const response = await apiClient.put<Category>(`/api/categories/${category.id}`, data);
            onSuccess(response.data);
            onClose();
        } catch (error) {
            handleApiError(error as AxiosError, setApiError);
        }
    };

    return (
        <Dialog open={open} onClose={onClose}>
            <DialogTitle>Edit Category</DialogTitle>
            <DialogContent>
                <form onSubmit={handleSubmit(onSubmit)}>
                    <TextField
                        label="Name"
                        fullWidth
                        margin="dense"
                        {...register('name', { required: 'Name is required' })}
                        error={!!errors.name}
                        helperText={errors.name?.message}
                    />
                    <TextField
                        label="Description"
                        fullWidth
                        margin="dense"
                        {...register('description', { required: 'Description is required' })}
                        error={!!errors.description}
                        helperText={errors.description?.message}
                    />
                    {apiError && <FormErrorMessage error={apiError} />}
                    <DialogActions>
                        <Button onClick={onClose} color="primary">
                            Cancel
                        </Button>
                        <Button type="submit" color="primary" variant="contained">
                            Save
                        </Button>
                    </DialogActions>
                </form>
            </DialogContent>
        </Dialog>
    );
};
