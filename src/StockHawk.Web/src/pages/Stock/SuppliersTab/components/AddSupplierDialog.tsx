import { Dialog, DialogTitle, DialogContent, TextField, Typography, Divider, DialogActions, Button } from "@mui/material";
import { AxiosError } from "axios";
import { useState, useEffect } from "react";
import { useForm } from "react-hook-form";
import { LoadingOverlay } from "../../../../components";
import { Supplier, CreateSupplierDto } from "../../../../types";
import { apiClient, handleApiError } from "../../../../utils";
import { PhoneNumberInput, EmailInput } from "../../../../components/Inputs";


interface AddSupplierDialogProps {
    open: boolean;
    onClose: () => void;
    onSuccess: (newSupplier: Supplier) => void;
}

export const AddSupplierDialog: React.FC<AddSupplierDialogProps> = ({ open, onClose, onSuccess }) => {
    const { register, handleSubmit, formState: { errors }, reset } = useForm<CreateSupplierDto>();
    const [loading, setLoading] = useState(false);
    const [apiError, setApiError] = useState<string | null>(null);

    useEffect(() => {
        if (open) {
            reset({
                name: '',
                contactNumber: '',
                email: '',
                address: '',
            });
        }
        setApiError(null);
    }, [open, reset]);

    const onSubmit = async (data: CreateSupplierDto) => {
        setLoading(true);
        try {
            const response = await apiClient.post<Supplier>('/api/suppliers', data);
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
            <DialogTitle>Add Supplier</DialogTitle>
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
                    <PhoneNumberInput
                        label="Contact Number"
                        name="contactNumber"
                        register={register}
                        errors={errors}
                        className="mb-4"
                    />
                    <EmailInput
                        label="Email"
                        name="Email"
                        register={register}
                        errors={errors}
                        className="mb-4"
                    />
                    <TextField
                        label="Address"
                        fullWidth
                        margin="dense"
                        {...register('address', { required: 'Address is required' })}
                        error={!!errors.address}
                        helperText={errors.address?.message}
                        className="mb-4"
                    />
                    {apiError && <Typography color="error" className="mb-4">{apiError}</Typography>}
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
