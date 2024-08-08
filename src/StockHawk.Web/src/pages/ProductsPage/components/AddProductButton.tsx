import React from 'react';
import Button from '@mui/material/Button';
import { useProductsContext } from '../context';


export const AddProductButton: React.FC = () => {
    const { setOpenDialog } = useProductsContext();

    return (
        <Button
            variant="contained"
            color="primary"
            className="text-white"
            onClick={() => setOpenDialog(prevState => ({ ...prevState, addProduct: true }))}
        >
            Add Product
        </Button>
    );
};