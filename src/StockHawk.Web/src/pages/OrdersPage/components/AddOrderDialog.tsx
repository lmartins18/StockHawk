import {
    Dialog,
    DialogTitle,
    DialogContent,
    FormControl,
    TextField,
    InputLabel,
    Select,
    MenuItem,
    Box,
    Button,
    DialogActions,
    Table,
    TableBody,
    TableCell,
    TableHead,
    TableRow,
    IconButton,
    FormHelperText
} from "@mui/material";
import { AxiosError } from "axios";
import { useState, useEffect } from "react";
import { useForm, Controller, useFieldArray } from "react-hook-form";
import { FormErrorMessage, LoadingOverlay } from "../../../components";
import {
    Order,
    CreateOrderDto,
    Customer,
    OrderStatus,
    OrderType,
    Product,
} from "../../../types";
import { apiClient, handleApiError } from "../../../utils";
import DeleteIcon from '@mui/icons-material/Delete';
import { ProductSelectionDialog } from './ProductSelectionDialog';
import { NumberInput } from "../../../components/Inputs";

interface AddOrderDialogProps {
    open: boolean;
    onClose: () => void;
    onSuccess: (newOrder: Order) => void;
}

export const AddOrderDialog: React.FC<AddOrderDialogProps> = ({ open, onClose, onSuccess }) => {
    const { control, handleSubmit, formState: { errors }, reset, watch, register } = useForm<CreateOrderDto>({
        defaultValues: { orderItems: [], shippingCost: 0 }
    });
    const { fields, append, remove } = useFieldArray({ control, name: "orderItems" });
    const [customers, setCustomers] = useState<Customer[]>([]);
    const [statuses, setStatuses] = useState<OrderStatus[]>([]);
    const [types, setTypes] = useState<OrderType[]>([]);
    const [products, setProducts] = useState<Product[]>([]);
    const [loading, setLoading] = useState(true);
    const [apiError, setApiError] = useState<string | null>(null);
    const [productDialogOpen, setProductDialogOpen] = useState(false);

    const shippingCost = watch("shippingCost") ?? 0;
    const totalAmount = watch("orderItems").reduce((sum, item) => sum + item.price * item.quantity, 0) + shippingCost;

    // Reset form
    useEffect(() => {
        if (open) {
            reset({
                reference: '',
                customerId: 0,
                orderDate: '',
                shippingCost: 0,
                totalAmount: 0,
                orderStatusId: 0,
                orderTypeId: 0,
                orderItems: [],
            });
        }
        setApiError(null);
    }, [open, reset]);

    // Get necessary data
    useEffect(() => {
        (async () => {
            try {
                const [customersResponse, statusesResponse, typesResponse, productsResponse] = await Promise.all([
                    apiClient.get('/api/customers'),
                    apiClient.get('/api/order-statuses'),
                    apiClient.get('/api/order-types'),
                    apiClient.get('/api/products')
                ]);
                setCustomers(customersResponse.data);
                setStatuses(statusesResponse.data);
                setTypes(typesResponse.data);
                setProducts(productsResponse.data);
                setLoading(false);
            } catch (error) {
                console.error('Failed to fetch dropdown data:', error);
                setLoading(false);
            }
        })();
    }, []);

    const handleAddOrderItem = (product: Product, quantity: number) => {
        append({ productId: product.id, quantity, price: product.price });
        setProductDialogOpen(false);
    };

    const onSubmit = async (data: CreateOrderDto) => {
        try {
            const response = await apiClient.post<Order>('/api/orders', { ...data, totalAmount });
            onSuccess(response.data);

            // Update the products state to reflect the new quantities
            const updatedProducts = products.map(product => {
                const orderItem = response.data.orderItems.find(item => item.productId === product.id);
                if (orderItem) {
                    return { ...product, quantity: product.quantity - orderItem.quantity };
                }
                return product;
            });

            setProducts(updatedProducts);
            onClose();
        } catch (error) {
            handleApiError(error as AxiosError, setApiError);
        }
    };

    if (loading) {
        return <LoadingOverlay />;
    }

    const selectedProductIds = fields.map(item => item.productId);

    return (
        <>
            <Dialog open={open} onClose={onClose}>
                <DialogTitle>Add Order</DialogTitle>
                <DialogContent>
                    <form onSubmit={handleSubmit(onSubmit)} className="flex flex-col">
                        <FormControl fullWidth margin="dense" error={!!errors.reference}>
                            <TextField
                                label="Reference"
                                {...control.register('reference', { required: 'Reference is required' })}
                            />
                            <FormHelperText>{errors.reference?.message}</FormHelperText>
                        </FormControl>
                        <FormControl fullWidth margin="dense" error={!!errors.customerId}>
                            <InputLabel>Customer</InputLabel>
                            <Controller
                                name="customerId"
                                control={control}
                                render={({ field }) => (
                                    <Select {...field} label="Customer">
                                        {customers.map((customer) => (
                                            <MenuItem key={customer.id} value={customer.id}>
                                                {customer.firstName} {customer.lastName} | {customer.email}
                                            </MenuItem>
                                        ))}
                                    </Select>
                                )}
                            />
                            <FormHelperText>{errors.customerId?.message}</FormHelperText>
                        </FormControl>
                        <FormControl fullWidth margin="dense" error={!!errors.orderDate}>
                            <TextField
                                label="Order Date"
                                type="date"
                                InputLabelProps={{ shrink: true }}
                                {...control.register('orderDate', { required: 'Order Date is required' })}
                            />
                            <FormHelperText>{errors.orderDate?.message}</FormHelperText>
                        </FormControl>
                        <FormControl fullWidth margin="dense" error={!!errors.shippingCost}>
                            <NumberInput
                                name="shippingCost"
                                label="Shipping Cost"
                                register={register}
                                errors={errors}
                                integerOnly={false}
                                minValue={0}
                            />
                        </FormControl>
                        <FormControl fullWidth margin="dense" error={!!errors.orderStatusId}>
                            <InputLabel>Status</InputLabel>
                            <Controller
                                name="orderStatusId"
                                control={control}
                                rules={{ required: 'Status is required' }}
                                render={({ field }) => (
                                    <Select {...field} label="Status">
                                        {statuses.map((status) => (
                                            <MenuItem key={status.id} value={status.id}>
                                                {status.name}
                                            </MenuItem>
                                        ))}
                                    </Select>
                                )}
                            />
                            <FormHelperText>{errors.orderStatusId?.message}</FormHelperText>
                        </FormControl>
                        <FormControl fullWidth margin="dense" error={!!errors.orderTypeId}>
                            <InputLabel>Type</InputLabel>
                            <Controller
                                name="orderTypeId"
                                control={control}
                                rules={{ required: 'Type is required' }}
                                render={({ field }) => (
                                    <Select {...field} label="Type">
                                        {types.map((type) => (
                                            <MenuItem key={type.id} value={type.id}>
                                                {type.name}
                                            </MenuItem>
                                        ))}
                                    </Select>
                                )}
                            />
                            <FormHelperText>{errors.orderTypeId?.message}</FormHelperText>
                        </FormControl>
                        <Box mt={2}>
                            <p className="text-lg">Order Items</p>
                            <Table>
                                <TableHead>
                                    <TableRow>
                                        <TableCell>Product</TableCell>
                                        <TableCell>Quantity</TableCell>
                                        <TableCell>Price</TableCell>
                                        <TableCell>Total</TableCell>
                                        <TableCell></TableCell>
                                    </TableRow>
                                </TableHead>
                                <TableBody>
                                    {fields.map((item, index) => (
                                        <TableRow key={item.productId}>
                                            <TableCell>{products.find(p => p.id === item.productId)?.name}</TableCell>
                                            <TableCell>{item.quantity}</TableCell>
                                            <TableCell>{item.price.toFixed(2)}</TableCell>
                                            <TableCell>{(item.price * item.quantity).toFixed(2)}</TableCell>
                                            <TableCell>
                                                <IconButton onClick={() => remove(index)}>
                                                    <DeleteIcon />
                                                </IconButton>
                                            </TableCell>
                                        </TableRow>
                                    ))}
                                </TableBody>
                            </Table>
                        </Box>
                        <Box mt={2}>
                            <Button onClick={() => setProductDialogOpen(true)} variant="outlined" color="primary" fullWidth>Add Item</Button>
                        </Box>

                        <Box className="mt-2 flex flex-col space-between font-bold">
                            <p>Shipping Cost: €{shippingCost.toFixed(2)}</p>
                            <p>Total Amount: €{totalAmount.toFixed(2)}</p>
                        </Box>
                        {apiError && <FormErrorMessage error={apiError} />}
                        <DialogActions>
                            <Button onClick={onClose}>Cancel</Button>
                            <Button type="submit" color="primary" variant="contained">Save</Button>
                        </DialogActions>
                    </form>
                </DialogContent>
            </Dialog>
            <ProductSelectionDialog
                open={productDialogOpen}
                products={products.filter(product => !selectedProductIds.includes(product.id))}
                onClose={() => setProductDialogOpen(false)}
                onAdd={handleAddOrderItem}
            />
        </>
    );
};
