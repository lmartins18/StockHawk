import { Dialog, DialogTitle, DialogContent, TextField, FormControl, InputLabel, Select, MenuItem, FormHelperText, Divider, DialogActions, Button } from "@mui/material";
import { AxiosError } from "axios";
import { useState, useEffect } from "react";
import { useForm } from "react-hook-form";
import { LoadingOverlay, FormErrorMessage } from "../../../components";
import { Product, CreateProductDto, Category, Supplier } from "../../../types";
import { apiClient, handleApiError } from "../../../utils";
import { NumberInput } from "../../../components/Inputs";

interface AddProductDialogProps {
    open: boolean;
    onClose: () => void;
    onSuccess: (newProduct: Product) => void;
    setError: React.Dispatch<React.SetStateAction<string | null>>;
}

export const AddProductDialog: React.FC<AddProductDialogProps> = ({ open, onClose, onSuccess }) => {
    const { register, handleSubmit, formState: { errors }, reset } = useForm<CreateProductDto>();
    const [categories, setCategories] = useState<Category[]>([]);
    const [suppliers, setSuppliers] = useState<Supplier[]>([]);
    const [loading, setLoading] = useState(true);
    const [apiError, setApiError] = useState<string | null>(null);

    useEffect(() => {
        if (open) {
            reset({
                Name: '',
                Description: '',
                Price: undefined,
                Quantity: undefined,
                LowStockThreshold: undefined,
                CategoryId: undefined,
                SupplierId: undefined
            });
        }
        setApiError(null);
    }, [open, reset]);

    useEffect(() => {
        (async () => {
            try {
                const [categoriesResponse, suppliersResponse] = await Promise.all([
                    apiClient.get('/api/categories'),
                    apiClient.get('/api/suppliers')
                ]);
                setCategories(categoriesResponse.data);
                setSuppliers(suppliersResponse.data);
                setLoading(false);
            } catch (error) {

                console.error('Failed to fetch dropdown data:', error);
                setLoading(false);
            }
        })();
    }, []);

    const onSubmit = async (data: CreateProductDto) => {
        try {
            const response = await apiClient.post<Product>('/api/products', data);
            onSuccess(response.data);
        } catch (error) {
            handleApiError(error as AxiosError, setApiError);
        } finally {
            setLoading(false);
        }
    };

    if (loading) {
        return <LoadingOverlay />;
    }

    return (
        <Dialog open={open} onClose={onClose} maxWidth="sm" fullWidth>
            <DialogTitle>Add Product</DialogTitle>
            <DialogContent className="flex flex-col overflow-y-auto">
                <form onSubmit={handleSubmit(onSubmit)} className="flex flex-col flex-grow">
                    <TextField
                        label="Name"
                        fullWidth
                        margin="dense"
                        {...register('Name', { required: 'Name is required' })}
                        error={!!errors.Name}
                        helperText={errors.Name?.message}
                        className="mb-4"
                    />
                    <TextField
                        label="Description"
                        fullWidth
                        margin="dense"
                        {...register('Description', { required: 'Description is required' })}
                        error={!!errors.Description}
                        helperText={errors.Description?.message}
                        className="mb-4"
                    />
                    <NumberInput
                        label="Price"
                        name="Price"
                        register={register}
                        errors={errors}
                        minValue={0}
                        integerOnly={true}
                        className="mb-4"
                    />
                    <NumberInput
                        label="Quantity"
                        name="Quantity"
                        register={register}
                        errors={errors}
                        minValue={0}
                        integerOnly={true}
                        className="mb-4"
                    />
                    <NumberInput
                        label="Low Stock Threshold"
                        name="LowStockThreshold"
                        register={register}
                        errors={errors}
                        minValue={0}
                        integerOnly={true}
                        className="mb-4"
                    />
                    <FormControl fullWidth margin="dense" error={!!errors.CategoryId} className="mb-4">
                        <InputLabel>Category</InputLabel>
                        <Select
                            label="Category"
                            defaultValue=""
                            {...register('CategoryId', { required: 'Category is required', valueAsNumber: true })}
                        >
                            {categories.map((category) => (
                                <MenuItem key={category.id} value={category.id}>
                                    {category.name}
                                </MenuItem>
                            ))}
                        </Select>
                        <FormHelperText>{errors.CategoryId?.message}</FormHelperText>
                    </FormControl>
                    <FormControl fullWidth margin="dense" error={!!errors.SupplierId} className="mb-4">
                        <InputLabel>Supplier</InputLabel>
                        <Select
                            label="Supplier"
                            defaultValue=""
                            {...register('SupplierId', { required: 'Supplier is required', valueAsNumber: true })}
                        >
                            {suppliers.map((supplier) => (
                                <MenuItem key={supplier.id} value={supplier.id}>
                                    {supplier.name}
                                </MenuItem>
                            ))}
                        </Select>
                        <FormHelperText>{errors.SupplierId?.message}</FormHelperText>
                    </FormControl>
                    {apiError && <FormErrorMessage error={apiError} />}
                </form>
            </DialogContent>
            <Divider />
            <DialogActions className="flex justify-end">
                <Button onClick={onClose} color="primary" className="mr-2">
                    Cancel
                </Button>
                <Button type="submit" color="primary" variant="contained" onClick={handleSubmit(onSubmit)}>
                    Add
                </Button>
            </DialogActions>
        </Dialog>
    );
};
