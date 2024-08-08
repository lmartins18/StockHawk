import { useEffect, useState } from 'react';
import { OrderType } from '../../../../types';
import { apiClient } from '../../../../utils';

export const useOrderTypeData = () => {
    const [orderTypes, setOrderTypes] = useState<OrderType[]>([]);
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState<string | null>(null);

    useEffect(() => {
        (async () => {
            setLoading(true);
            try {
                const response = await apiClient.get('/api/order-types');
                setOrderTypes(response.data);
            } catch (e) {
                setError("Failed to fetch order types.");
            } finally {
                setLoading(false);
            }
        })();
    }, []);

    return { orderTypes, loading, error, setOrderTypes, setError };
};
