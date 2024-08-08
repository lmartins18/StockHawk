import { InteractionRequiredAuthError, AccountInfo } from "@azure/msal-browser";
import { useMsal } from "@azure/msal-react";
import { AxiosError } from "axios";
import { useState, useEffect } from "react";
import { loginRequest } from "../../../authConfig";
import { Order } from "../../../types";
import { apiClient } from "../../../utils";

export const useOrdersData = () => {
    const { instance } = useMsal();
    const [orders, setOrders] = useState<Order[]>([]);
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState<string | null>(null);

    useEffect(() => {
        (async () => {
            setLoading(true);
            try {
                const response = await apiClient.get('/api/orders');
                setOrders(response.data);
            } catch (e) {
                if (e instanceof InteractionRequiredAuthError) {
                    await instance.acquireTokenRedirect({
                        ...loginRequest,
                        account: instance.getActiveAccount() as AccountInfo,
                    });
                } else if (e instanceof AxiosError) {
                    setError(e.response?.data?.message || 'Failed to fetch orders.');
                } else {
                    setError('An unexpected error occurred.');
                }
            } finally {
                setLoading(false);
            }
        })();
    }, [instance]);

    return { orders, loading, error, setOrders, setError };
};


