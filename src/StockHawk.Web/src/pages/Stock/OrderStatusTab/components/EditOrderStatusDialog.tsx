import React, { useEffect, useState } from 'react';
import {
    Dialog,
    DialogActions,
    DialogContent,
    DialogTitle,
    TextField,
    Button
} from '@mui/material';
import { CreateOrderStatusDto, OrderStatus } from '../../../../types';
import { useForm } from 'react-hook-form';
import { FormErrorMessage } from '../../../../components';
import { AxiosError } from 'axios';
import { handleApiError } from '../../../../utils';

interface EditOrderStatusDialogProps {
    open: boolean;
    onClose: () => void;
    onSuccess: (orderStatus: OrderStatus) => void;
    orderStatus: OrderStatus;
}

export const EditOrderStatusDialog: React.FC<EditOrderStatusDialogProps> = ({ open, onClose, onSuccess, orderStatus }) => {
    const { register, handleSubmit, formState: { errors }, reset } = useForm<CreateOrderStatusDto>();
    const [apiError, setApiError] = useState<string | null>(null);

    useEffect(() => {
        reset({
            name: orderStatus.name,
            description: orderStatus.description || ''
        });
    }, [orderStatus, reset]);

    const onSubmit = (data: CreateOrderStatusDto) => {
        try {
            onSuccess({ ...orderStatus, name: data.name, description: data.description });
            onClose();
        } catch (error) {
            handleApiError(error as AxiosError, setApiError);
        }
    };

    return (
        <Dialog open={open} onClose={onClose}>
            <DialogTitle>Edit Order Status</DialogTitle>
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
                            Save
                        </Button>
                    </DialogActions>
                </form>
            </DialogContent>
        </Dialog>
    );
};
