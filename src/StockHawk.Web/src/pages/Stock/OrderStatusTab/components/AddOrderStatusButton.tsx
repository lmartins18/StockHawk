import Button from '@mui/material/Button';
import { useOrderStatusContext } from '../context';

export const AddOrderStatusButton = () => {
    const { setOpenDialog } = useOrderStatusContext();

    return (
        <Button
            variant="contained"
            color="primary"
            className="text-white"
            onClick={() => setOpenDialog(prev => ({ ...prev, addOrderStatus: true }))}
        >
            Add Order Status
        </Button>
    );
};
