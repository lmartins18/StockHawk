// components/AddOrderButton.tsx
import React from 'react';
import Button from '@mui/material/Button';
import { useOrdersContext } from '../context/OrdersContext';

export const AddOrderButton: React.FC = () => {
    const { setOpenDialog } = useOrdersContext();

    return (
        <Button
            variant="contained"
            color="primary"
            className="text-white"
            onClick={() => setOpenDialog(prevState => ({ ...prevState, addOrder: true }))}
        >
            Add Order
        </Button>

    );
};
