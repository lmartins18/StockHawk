import React from 'react';
import Button from '@mui/material/Button';
import { useOrderTypesContext } from '../context';


export const AddOrderTypeButton: React.FC = () => {
    const { setOpenDialog } = useOrderTypesContext();

    return (
        <Button
            variant="contained"
            color="primary"
            className="text-white"
            onClick={() => setOpenDialog(prevState => ({ ...prevState, addOrderType: true }))}
        >
            Add Order Type
        </Button>
    );
};
