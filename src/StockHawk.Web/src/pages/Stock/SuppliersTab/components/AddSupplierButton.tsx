import React from 'react';
import Button from '@mui/material/Button';
import { useSuppliersContext } from '../context';


export const AddSupplierButton: React.FC = () => {
    const { setOpenDialog } = useSuppliersContext();

    return (
        <Button
            variant="contained"
            color="primary"
            className="text-white"
            onClick={() => setOpenDialog(prevState => ({ ...prevState, addSupplier: true }))}
        >
            Add Supplier
        </Button>
    );
};
