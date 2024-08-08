import { CircularProgress, Dialog, DialogTitle, DialogContent, TextField, Divider, DialogActions, Button } from "@mui/material";
import { AxiosError } from "axios";
import { useState, useEffect } from "react";
import { useForm } from "react-hook-form";
import { Customer, CreateCustomerDto } from "../../../types";
import { apiClient, handleApiError } from "../../../utils";
import { EmailInput, PhoneNumberInput } from "../../../components/Inputs";
import { FormErrorMessage } from "../../../components";


interface AddCustomerDialogProps {
    open: boolean;
    onClose: () => void;
    onSuccess: (customer: Customer) => void;
    setError: React.Dispatch<React.SetStateAction<string | null>>;
}

export const AddCustomerDialog: React.FC<AddCustomerDialogProps> = ({ open, onClose, onSuccess }) => {
    const { register, handleSubmit, formState: { errors }, reset } = useForm<CreateCustomerDto>();
    const [loading, setLoading] = useState(false);
    const [apiError, setApiError] = useState<string | null>(null);

    useEffect(() => {
        if (open) {
            reset({
                firstName: '',
                lastName: '',
                email: '',
                phoneNumber: '',
                address: ''
            });
        }
        setApiError(null);
    }, [open, reset]);

    const onSubmit = async (data: CreateCustomerDto) => {
        setLoading(true);
        try {
            const response = await apiClient.post<Customer>('/api/customers', data);
            onSuccess(response.data);
            onClose();
        } catch (error) {
            handleApiError(error as AxiosError, setApiError);
        } finally {
            setLoading(false);
        }
    };

    if (loading) {
        return <CircularProgress />;
    }

    return (
        <Dialog open={open} onClose={onClose} maxWidth="sm" fullWidth>
            <DialogTitle>Add Customer</DialogTitle>
            <DialogContent>
                <form onSubmit={handleSubmit(onSubmit)} className="flex flex-col">
                    <TextField
                        label="First Name"
                        fullWidth
                        margin="dense"
                        {...register('firstName', { required: 'First Name is required' })}
                        error={!!errors.firstName}
                        helperText={errors.firstName?.message}
                        className="mb-4"
                    />
                    <TextField
                        label="Last Name"
                        fullWidth
                        margin="dense"
                        {...register('lastName', { required: 'Last Name is required' })}
                        error={!!errors.lastName}
                        helperText={errors.lastName?.message}
                        className="mb-4"
                    />
                    <EmailInput
                        label="Email"
                        name="Email"
                        register={register}
                        errors={errors}
                        className="mb-4"
                    />
                    <PhoneNumberInput
                        label="Phone Number"
                        name="phoneNumber"
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
                    {apiError && <FormErrorMessage error={apiError} />}
                </form>
            </DialogContent>
            <Divider />
            <DialogActions>
                <Button onClick={onClose} color="primary" className="mr-2">
                    Cancel
                </Button>
                <Button type="submit" color="primary" variant="contained" onClick={handleSubmit(onSubmit)}>
                    Add
                </Button>
            </DialogActions>
        </Dialog>
    );
};
