import React, { useState } from 'react';
import {
    Dialog,
    DialogActions,
    DialogContent,
    DialogTitle,
    TextField,
    Button
} from '@mui/material';
import { OrderStatus } from '../../../../types/index.ts';
import { useForm } from 'react-hook-form';
import { apiClient, handleApiError } from '../../../../utils';
import { FormErrorMessage } from '../../../../components';
import { AxiosError } from 'axios';

interface AddOrderStatusDialogProps {
    open: boolean;
    onClose: () => void;
    onSuccess: (orderStatus: OrderStatus) => void;
}

interface CreateOrderStatusDto {
    name: string;
    description?: string;
}

export const AddOrderStatusDialog: React.FC<AddOrderStatusDialogProps> = ({ open, onClose, onSuccess }) => {
    const { register, handleSubmit, formState: { errors } } = useForm<CreateOrderStatusDto>();
    const [apiError, setApiError] = useState<string | null>(null);

    const onSubmit = async (data: CreateOrderStatusDto) => {
        try {
            const response = await apiClient.post<OrderStatus>('/api/order-statuses', data);
            onSuccess(response.data);
            onClose();
        } catch (error) {
            handleApiError(error as AxiosError, setApiError);
        }
    };

    return (
        <Dialog open={open} onClose={onClose}>
            <DialogTitle>Add Order Status</DialogTitle>
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
                        {...register('description')}
                    />
                    {apiError && <FormErrorMessage error={apiError} />}
                    <DialogActions>
                        <Button onClick={onClose} color="primary">
                            Cancel
                        </Button>
                        <Button type="submit" color="primary" variant="contained">
                            Add
                        </Button>
                    </DialogActions>
                </form>
            </DialogContent>
        </Dialog>
    );
};
