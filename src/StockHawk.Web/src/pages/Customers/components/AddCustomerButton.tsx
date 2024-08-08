import React from 'react';
import Button from '@mui/material/Button';
import { useCustomersContext } from '../context';

export const AddCustomerButton: React.FC = () => {
    const { setOpenDialog } = useCustomersContext();

    return (
        <Button
            variant="contained"
            color="primary"
            className="text-white"
            onClick={() => setOpenDialog(prevState => ({ ...prevState, addCustomer: true }))}
        >
            Add Customer
        </Button>
    );
};
