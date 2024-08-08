import { Dialog, DialogTitle, DialogContent, TextField, FormControl, InputLabel, Select, MenuItem, FormHelperText, DialogActions, Button } from "@mui/material";
import { AxiosError } from "axios";
import { useState, useEffect } from "react";
import { useForm, Controller } from "react-hook-form";
import { FormErrorMessage, LoadingOverlay } from "../../../components";
import { Product, EditProductDto, Category, Supplier } from "../../../types";
import { apiClient, handleApiError } from "../../../utils";
import { NumberInput } from "../../../components/Inputs";

interface EditProductDialogProps {
    open: boolean;
    onClose: () => void;
    onSuccess: (updatedProduct: Product) => void;
    product: EditProductDto;
    setError: React.Dispatch<React.SetStateAction<string | null>>;
}

export const EditProductDialog: React.FC<EditProductDialogProps> = ({ open, onClose, onSuccess, product }) => {
    const { register, handleSubmit, control, formState: { errors }, setValue } = useForm<EditProductDto>({ defaultValues: product });
    const [categories, setCategories] = useState<Category[]>([]);
    const [suppliers, setSuppliers] = useState<Supplier[]>([]);
    const [loading, setLoading] = useState(true);
    const [apiError, setApiError] = useState<string | null>(null);

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

    const onSubmit = async (data: EditProductDto) => {
        try {
            const response = await apiClient.put<Product>(`/api/products/${product.id}`, data);
            onSuccess(response.data);
            onClose();
        } catch (error) {
            handleApiError(error as AxiosError, setApiError);
        } finally {
            setLoading(false);
        }
    }

    if (loading) {
        return <LoadingOverlay />;
    }

    return (
        <Dialog open={open} onClose={onClose}>
            <DialogTitle>Edit Product</DialogTitle>
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
                        {...register('description', { required: 'Description is required' })}
                        error={!!errors.description}
                        helperText={errors.description?.message}
                    />
                    <NumberInput
                        label="Price"
                        name="price"
                        register={register}
                        errors={errors}
                        minValue={0}
                        integerOnly={true}
                        className="mb-4"
                    />
                    <NumberInput
                        label="Quantity"
                        name="quantity"
                        register={register}
                        errors={errors}
                        minValue={0}
                        integerOnly={true}
                        className="mb-4"
                    />
                    <NumberInput
                        label="Low Stock Threshold"
                        name="lowStockThreshold"
                        register={register}
                        errors={errors}
                        minValue={0}
                        integerOnly={true}
                        className="mb-4"
                    />
                    <FormControl fullWidth margin="dense" error={!!errors.categoryId}>
                        <InputLabel>Category</InputLabel>
                        <Controller
                            name="categoryId"
                            control={control}
                            rules={{ required: 'Category is required' }}
                            render={({ field }) => (
                                <Select
                                    {...field}
                                    label="Category"
                                    value={field.value}
                                    onChange={(e) => setValue('categoryId', e.target.value as number)}
                                >
                                    {categories.map((category) => (
                                        <MenuItem key={category.id} value={category.id}>
                                            {category.name}
                                        </MenuItem>
                                    ))}
                                </Select>
                            )}
                        />
                        <FormHelperText>{errors.categoryId?.message}</FormHelperText>
                    </FormControl>
                    <FormControl fullWidth margin="dense" error={!!errors.supplierId}>
                        <InputLabel>Supplier</InputLabel>
                        <Controller
                            name="supplierId"
                            control={control}
                            rules={{ required: 'Supplier is required' }}
                            render={({ field }) => (
                                <Select
                                    {...field}
                                    label="Supplier"
                                    value={field.value}
                                    onChange={(e) => setValue('supplierId', e.target.value as number)}
                                >
                                    {suppliers.map((supplier) => (
                                        <MenuItem key={supplier.id} value={supplier.id}>
                                            {supplier.name}
                                        </MenuItem>
                                    ))}
                                </Select>
                            )}
                        />
                        <FormHelperText>{errors.supplierId?.message}</FormHelperText>
                    </FormControl>
                    {apiError && <FormErrorMessage error={apiError} />}
                    <DialogActions>
                        <Button onClick={onClose} color="primary">
                            Cancel
                        </Button>
                        <Button type="submit" color="primary" variant='contained'>
                            Save
                        </Button>
                    </DialogActions>
                </form>
            </DialogContent>
        </Dialog>
    );
};
