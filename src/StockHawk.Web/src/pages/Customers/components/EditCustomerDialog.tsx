import { Dialog, DialogTitle, DialogContent, Grid, TextField, DialogActions, Button } from "@mui/material";
import { AxiosError } from "axios";
import { useState } from "react";
import { useForm } from "react-hook-form";
import { FormErrorMessage, LoadingOverlay } from "../../../components";
import { Customer } from "../../../types";
import { apiClient, handleApiError } from "../../../utils";
import { PhoneNumberInput, EmailInput } from "../../../components/Inputs";


interface EditCustomerDialogProps {
    open: boolean;
    onClose: () => void;
    onSuccess: (updatedCustomer: Customer) => void;
    customer: Customer;
}

export const EditCustomerDialog: React.FC<EditCustomerDialogProps> = ({ open, onClose, onSuccess, customer }) => {
    const { register, handleSubmit, formState: { errors } } = useForm<Customer>({ defaultValues: customer });
    const [loading, setLoading] = useState(false);
    const [apiError, setApiError] = useState<string | null>(null);

    const onSubmit = async (data: Customer) => {
        setLoading(true);
        try {
            const response = await apiClient.put<Customer>(`/api/customers/${customer.id}`, data);
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
        <Dialog open={open} onClose={onClose}>
            <DialogTitle>Edit Customer</DialogTitle>
            <DialogContent>
                <form onSubmit={handleSubmit(onSubmit)}>
                    <Grid container spacing={2}>
                        <Grid item xs={12} sm={6}>
                            <TextField
                                label="First Name"
                                fullWidth
                                margin="dense"
                                {...register('firstName', { required: 'First Name is required' })}
                                error={!!errors.firstName}
                                helperText={errors.firstName?.message}
                            />
                        </Grid>
                        <Grid item xs={12} sm={6}>
                            <TextField
                                label="Last Name"
                                fullWidth
                                margin="dense"
                                {...register('lastName', { required: 'Last Name is required' })}
                                error={!!errors.lastName}
                                helperText={errors.lastName?.message}
                            />
                        </Grid>
                        <Grid item xs={12}>
                            <EmailInput
                                label="Email"
                                name="email"
                                register={register}
                                errors={errors}
                                className="mb-4"
                            />

                        </Grid>
                        <Grid item xs={12}>
                            <PhoneNumberInput
                                label="Phone Number"
                                name="phoneNumber"
                                register={register}
                                errors={errors}
                                className="mb-4"
                            />
                        </Grid>
                        <Grid item xs={12}>
                            <TextField
                                label="Address"
                                fullWidth
                                margin="dense"
                                {...register('address', { required: 'Address is required' })}
                                error={!!errors.address}
                                helperText={errors.address?.message}
                            />
                        </Grid>
                    </Grid>
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
