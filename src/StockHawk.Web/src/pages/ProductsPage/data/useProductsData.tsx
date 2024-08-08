import { InteractionRequiredAuthError, AccountInfo } from "@azure/msal-browser";
import { useMsal } from "@azure/msal-react";
import { AxiosError } from "axios";
import { useState, useEffect } from "react";
import { loginRequest } from "../../../authConfig";
import { Product } from "../../../types";
import { apiClient } from "../../../utils";

export const useProductsData = () => {
    const { instance } = useMsal();
    const [products, setProducts] = useState<Product[]>([]);
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState<string | null>(null);

    useEffect(() => {
        (async () => {
            setLoading(true);
            try {
                const response = await apiClient.get('/api/products');
                setProducts(response.data);
            } catch (e) {
                if (e instanceof InteractionRequiredAuthError) {
                    await instance.acquireTokenRedirect({
                        ...loginRequest,
                        account: instance.getActiveAccount() as AccountInfo,
                    });
                } else if (e instanceof AxiosError) {
                    setError(e.response?.data?.message || 'Failed to fetch products.');
                } else {
                    setError('An unexpected error occurred.');
                }
            } finally {
                setLoading(false);
            }
        })();
    }, [instance]);

    return { products, loading, setLoading, error, setProducts, setError };
};