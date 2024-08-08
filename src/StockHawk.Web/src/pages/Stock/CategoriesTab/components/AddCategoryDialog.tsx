import { Dialog, DialogTitle, DialogContent, TextField, Divider, DialogActions, Button } from "@mui/material";
import { AxiosError } from "axios";
import { useState, useEffect } from "react";
import { useForm } from "react-hook-form";
import { FormErrorMessage, LoadingOverlay } from "../../../../components";
import { Category, CreateCategoryDto } from "../../../../types";
import { apiClient, handleApiError } from "../../../../utils";


interface AddCategoryDialogProps {
    open: boolean;
    onClose: () => void;
    onSuccess: (newCategory: Category) => void;
    setError: React.Dispatch<React.SetStateAction<string | null>>;
}

export const AddCategoryDialog: React.FC<AddCategoryDialogProps> = ({ open, onClose, onSuccess, }) => {
    const { register, handleSubmit, formState: { errors }, reset } = useForm<CreateCategoryDto>();
    const [loading, setLoading] = useState(false);
    const [apiError, setApiError] = useState<string | null>(null);

    useEffect(() => {
        if (open) {
            reset({
                name: '',
                description: ''
            });
        }
    }, [open, reset]);

    const onSubmit = async (data: CreateCategoryDto) => {
        setLoading(true);
        try {
            const response = await apiClient.post<Category>('/api/categories', data);
            onSuccess(response.data);
            onClose();
        } catch (error) {
            handleApiError(error as AxiosError, setApiError);
        } finally {
            setLoading(false);
        }
    };

    if (loading) {
        return <LoadingOverlay />;
    }

    return (
        <Dialog open={open} onClose={onClose} maxWidth="sm" fullWidth>
            <DialogTitle>Add Category</DialogTitle>
            <DialogContent className="flex flex-col overflow-y-auto">
                <form onSubmit={handleSubmit(onSubmit)} className="flex flex-col flex-grow">
                    <TextField
                        label="Name"
                        fullWidth
                        margin="dense"
                        {...register('name', { required: 'Name is required' })}
                        error={!!errors.name}
                        helperText={errors.name?.message}
                        className="mb-4"
                    />
                    <TextField
                        label="Description"
                        fullWidth
                        margin="dense"
                        {...register('description', { required: 'Description is required' })}
                        error={!!errors.description}
                        helperText={errors.description?.message}
                        className="mb-4"
                    />
                    {apiError && <FormErrorMessage error={apiError} />}
                </form>
            </DialogContent>
            <Divider />
            <DialogActions className="flex justify-end">
                <Button onClick={onClose} color="primary" className="mr-2">
                    Cancel
                </Button>
                <Button
                    type="submit"
                    color="primary"
                    variant="contained"
                    onClick={handleSubmit(onSubmit)}
                >
                    Add
                </Button>
            </DialogActions>
        </Dialog>
    );
};
