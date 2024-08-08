import { Dialog, DialogTitle, DialogContent, TextField, Typography, DialogActions, Button } from "@mui/material";
import { AxiosError } from "axios";
import { useState, useEffect } from "react";
import { useForm } from "react-hook-form";
import { Supplier } from "../../../../types";
import { apiClient, handleApiError } from "../../../../utils";
import { EmailInput, PhoneNumberInput } from "../../../../components/Inputs";

interface EditSupplierDialogProps {
    open: boolean;
    onClose: () => void;
    onSuccess: (updatedSupplier: Supplier) => void;
    supplier: Supplier;
}

export const EditSupplierDialog: React.FC<EditSupplierDialogProps> = ({ open, onClose, onSuccess, supplier }) => {
    const { register, handleSubmit, formState: { errors }, reset } = useForm<Supplier>({
        defaultValues: {
            name: supplier.name,
            contactNumber: supplier.contactNumber,
            email: supplier.email,
            address: supplier.address
        }
    });
    const [apiError, setApiError] = useState<string | null>(null);

    useEffect(() => {
        reset(supplier);
    }, [supplier, reset]);

    const onSubmit = async (data: Supplier) => {
        try {
            const response = await apiClient.put<Supplier>(`/api/suppliers/${supplier.id}`, data);
            onSuccess(response.data);
            onClose();
        } catch (error) {
            handleApiError(error as AxiosError, setApiError);
        }
    };

    return (
        <Dialog open={open} onClose={onClose}>
            <DialogTitle>Edit Supplier</DialogTitle>
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
                    <PhoneNumberInput
                        label="Phone Number"
                        name="contactNumber"
                        register={register}
                        errors={errors}
                        className="mb-4"
                    />
                    <EmailInput
                        label="Email"
                        name="email"
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
                    />
                    {apiError && <Typography color="error">{apiError}</Typography>}
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
