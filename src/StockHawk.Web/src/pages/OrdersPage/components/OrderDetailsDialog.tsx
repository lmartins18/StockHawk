import { Dialog, DialogTitle, DialogContent, FormControl, TextField, InputLabel, Select, MenuItem, FormHelperText, Typography, Box, DialogActions, Button } from "@mui/material";
import { AxiosError } from "axios";
import { useState, useEffect } from "react";
import { useForm, Controller } from "react-hook-form";
import { LoadingOverlay } from "../../../components";
import { OrderDetailsDto, UpdateOrderDto, OrderStatus } from "../../../types";
import { apiClient, handleApiError } from "../../../utils";

interface OrderDetailsDialogProps {
    open: boolean;
    onClose: () => void;
    orderId: number;
    onSuccess: (updatedOrder: OrderDetailsDto) => void;
}

export const OrderDetailsDialog: React.FC<OrderDetailsDialogProps> = ({ open, onClose, orderId, onSuccess }) => {
    const { control, handleSubmit, formState: { errors }, setValue } = useForm<UpdateOrderDto>({});
    const [statuses, setStatuses] = useState<OrderStatus[]>([]);
    const [order, setOrder] = useState<OrderDetailsDto | null>(null);
    const [loading, setLoading] = useState(true);
    const [apiError, setApiError] = useState<string | null>(null);

    useEffect(() => {
        if (orderId && open) {
            (async () => {
                try {
                    const [orderResponse, statusesResponse] = await Promise.all([
                        apiClient.get(`/api/orders/${orderId}`),
                        apiClient.get('/api/order-statuses'),
                    ]);
                    setOrder(orderResponse.data);
                    setStatuses(statusesResponse.data);
                    setValue('id', orderId);
                    setValue('orderStatusId', orderResponse.data.orderStatus.id);
                    setLoading(false);
                } catch (error) {
                    console.error('Failed to fetch order details:', error);
                    setLoading(false);
                }
            })();
        }
    }, [orderId, open, setValue]);

    const onSubmit = async (data: UpdateOrderDto) => {
        try {
            const response = await apiClient.put<OrderDetailsDto>(`/api/orders/${orderId}`, { ...data });
            onSuccess(response.data);
            onClose();
        } catch (error) {
            handleApiError(error as AxiosError, setApiError);
        }
    };

    if (loading) {
        return <LoadingOverlay />;
    }

    return (
        <Dialog open={open} onClose={onClose}>
            <DialogTitle>Order Details</DialogTitle>
            <DialogContent>
                <form onSubmit={handleSubmit(onSubmit)}>
                    <FormControl fullWidth margin="dense" disabled>
                        <TextField
                            disabled
                            label="Reference"
                            value={order?.reference || ''}
                            InputProps={{ readOnly: true }}
                        />
                    </FormControl>
                    <FormControl fullWidth margin="dense" disabled>
                        <TextField
                            disabled
                            label="Customer"
                            value={order?.customerName || ''}
                            InputProps={{ readOnly: true }}
                        />
                    </FormControl>
                    <FormControl fullWidth margin="dense" disabled>
                        <TextField
                            disabled
                            label="Order Date"
                            type="date"
                            value={order?.orderDate?.substring(0, 10) || ''}
                            InputProps={{ readOnly: true }}
                        />
                    </FormControl>
                    <FormControl fullWidth margin="dense" disabled>
                        <TextField
                            disabled
                            label="Shipping Cost"
                            type="number"
                            value={order?.shippingCost || 0}
                            InputProps={{ readOnly: true }}
                        />
                    </FormControl>
                    <FormControl fullWidth margin="dense" disabled>
                        <TextField
                            disabled
                            label="Total Amount"
                            type="number"
                            value={order?.totalAmount || 0}
                            InputProps={{ readOnly: true }}
                        />
                    </FormControl>
                    <FormControl fullWidth margin="dense" error={!!errors.orderStatusId}>
                        <InputLabel>Status</InputLabel>
                        <Controller
                            name="orderStatusId"
                            control={control}
                            rules={{ required: 'Status is required' }}
                            render={({ field }) => (
                                <Select
                                    {...field}
                                    label="Status"
                                    value={field.value}
                                    onChange={(e) => setValue('orderStatusId', e.target.value as number)}
                                >
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
                    <FormControl fullWidth margin="dense" disabled>
                        <TextField
                            disabled
                            label="Order type"
                            type="text"
                            value={order?.orderType.name}
                            InputProps={{ readOnly: true }}
                        />
                    </FormControl>
                    <Typography variant="h6" marginY={2}>Order Items</Typography>
                    {order?.orderItems.map((item, index) => (
                        <Box key={index} display="flex" alignItems="center" marginY={1}>
                            <FormControl fullWidth margin="dense">
                                <TextField
                                    label="Product"
                                    disabled
                                    value={item.productName}
                                    InputProps={{ readOnly: true }}
                                />
                            </FormControl>
                            <TextField
                                label="Quantity"
                                disabled
                                type="number"
                                fullWidth
                                margin="dense"
                                value={item.quantity}
                                InputProps={{ readOnly: true }}
                            />
                            <TextField
                                label="Unit Price"
                                disabled
                                type="number"
                                fullWidth
                                margin="dense"
                                value={item.productPrice}
                                InputProps={{ readOnly: true }}
                            />
                            <TextField
                                label="Total Price"
                                disabled
                                type="number"
                                fullWidth
                                margin="dense"
                                value={item.totalPrice}
                                InputProps={{ readOnly: true }}
                            />
                        </Box>
                    ))}
                    {apiError && <Typography color="error">{apiError}</Typography>}
                </form>
            </DialogContent>
            <DialogActions>
                <Button onClick={onClose}>Cancel</Button>
                <Button onClick={handleSubmit(onSubmit)} color="primary" variant="contained">
                    Save
                </Button>
            </DialogActions>
        </Dialog>
    );
};
