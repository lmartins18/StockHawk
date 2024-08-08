import React, { useEffect } from 'react';
import {
    Dialog,
    DialogActions,
    DialogContent,
    DialogTitle,
    TextField,
    Button
} from '@mui/material';
import { CreateOrderTypeDto, OrderType } from '../../../../types';
import { useForm } from 'react-hook-form';

interface EditOrderTypeDialogProps {
    open: boolean;
    onClose: () => void;
    orderType: OrderType;
    onSuccess: (orderStatus: OrderType) => void;
}


export const EditOrderTypeDialog: React.FC<EditOrderTypeDialogProps> = ({ open, onClose, onSuccess, orderType }) => {
    const { register, handleSubmit, formState: { errors }, reset } = useForm<CreateOrderTypeDto>();

    useEffect(() => {
        reset({
            name: orderType.name,
            description: orderType.description || ''
        });
    }, [orderType, reset]);

    const onSubmit = (data: CreateOrderTypeDto) => {
        onSuccess({ ...orderType, name: data.name, description: data.description });
        onClose();
    };

    return (
        <Dialog open={open} onClose={onClose}>
            <DialogTitle>Edit Order Type</DialogTitle>
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
