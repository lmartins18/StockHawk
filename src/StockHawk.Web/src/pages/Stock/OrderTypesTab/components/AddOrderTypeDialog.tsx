import React, { useState } from 'react';
import {
    Dialog,
    DialogActions,
    DialogContent,
    DialogTitle,
    TextField,
    Button
} from '@mui/material';
import { useForm } from 'react-hook-form';
import { useOrderTypesContext } from '../context';
import { CreateOrderTypeDto } from '../../../../types';
import { AxiosError } from 'axios';
import { FormErrorMessage } from '../../../../components';
import { handleApiError } from '../../../../utils';

interface AddOrderTypeDialogProps {
    open: boolean;
    onClose: () => void;
}

export const AddOrderTypeDialog: React.FC<AddOrderTypeDialogProps> = ({ open, onClose }) => {
    const { register, handleSubmit, formState: { errors } } = useForm<CreateOrderTypeDto>();
    const { handleAddOrderType } = useOrderTypesContext();
    const [apiError, setApiError] = useState<string | null>(null);

    const onSubmit = async (data: CreateOrderTypeDto) => {
        try {
            handleAddOrderType(data);
        } catch (error) {
            handleApiError(error as AxiosError, setApiError);
        }
    };

    return (
        <Dialog open={open} onClose={onClose}>
            <DialogTitle>Add Order Type</DialogTitle>
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
