import { useState, useEffect } from "react";
import { OrderStatus } from "../../../../types";
import { apiClient } from "../../../../utils";


export const useOrderStatusData = () => {
    const [orderStatuses, setOrderStatuses] = useState<OrderStatus[]>([]);
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState<string | null>(null);

    useEffect(() => {
        (async () => {
            setLoading(true);
            try {
                const response = await apiClient.get('/api/order-statuses');
                setOrderStatuses(response.data);
            } catch (e) {
                setError("Failed to fetch order statuses.");
            } finally {
                setLoading(false);
            }
        })();
    }, []);

    return { orderStatuses, loading, error, setOrderStatuses, setError };
};
