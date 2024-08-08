import React, { useEffect, useState } from 'react';
import {
    Dialog,
    DialogTitle,
    DialogContent,
    DialogActions,
    Button,
    FormControl,
    InputLabel,
    Select,
    MenuItem,
    TextField,
    FormHelperText
} from "@mui/material";
import { Controller, useForm } from "react-hook-form";
import { Product } from "../../../types";

interface ProductSelectionDialogProps {
    open: boolean;
    products: Product[];
    onClose: () => void;
    onAdd: (product: Product, quantity: number) => void;
}

export const ProductSelectionDialog: React.FC<ProductSelectionDialogProps> = ({ open, products, onClose, onAdd }) => {
    const { control, handleSubmit, formState: { errors }, reset, setValue, watch } = useForm({
        defaultValues: {
            productId: 0,
            quantity: 1
        }
    });

    const [maxQuantity, setMaxQuantity] = useState(0);
    const selectedProductId = watch('productId');

    useEffect(() => {
        const selectedProduct = products.find(p => p.id === selectedProductId);
        const availableQuantity = selectedProduct ? selectedProduct.quantity : 0;
        setMaxQuantity(availableQuantity);
        setValue('quantity', Math.min(1, availableQuantity));
    }, [selectedProductId, products, setValue]);

    const onSubmit = (data: { productId: number, quantity: number }) => {
        const product = products.find(p => p.id === data.productId);
        if (product) {
            onAdd(product, data.quantity);
            reset();
        }
        onClose();
    };

    return (
        <Dialog open={open} onClose={onClose}>
            <DialogTitle>Select Product</DialogTitle>
            <DialogContent>
                <form onSubmit={handleSubmit(onSubmit)}>
                    <FormControl fullWidth margin="dense" error={!!errors.productId}>
                        <InputLabel>Product</InputLabel>
                        <Controller
                            name="productId"
                            control={control}
                            rules={{ required: "Product is required" }}
                            render={({ field }) => (
                                <Select {...field} label="Product">
                                    <MenuItem value={0} disabled>Select a product</MenuItem>
                                    {products.map(product => (
                                        <MenuItem key={product.id} value={product.id} disabled={product.quantity < 1}>
                                            {product.name} (Available: {product.quantity})
                                        </MenuItem>
                                    ))}
                                </Select>
                            )}
                        />
                        <FormHelperText>{errors.productId?.message}</FormHelperText>
                    </FormControl>
                    <FormControl fullWidth margin="dense" error={!!errors.quantity}>
                        <TextField
                            label="Quantity"
                            type="number"
                            inputProps={{ max: maxQuantity }}
                            {...control.register("quantity", {
                                required: "Quantity is required",
                                min: { value: 1, message: "Minimum quantity is 1" },
                                max: { value: maxQuantity, message: `Maximum quantity is ${maxQuantity}` }
                            })}
                        />
                        <FormHelperText>{errors.quantity?.message}</FormHelperText>
                    </FormControl>
                </form>
            </DialogContent>
            <DialogActions>
                <Button onClick={onClose}>Cancel</Button>
                <Button onClick={handleSubmit(onSubmit)} color="primary">Add</Button>
            </DialogActions>
        </Dialog>
    );
};
