import { InteractionRequiredAuthError, AccountInfo } from "@azure/msal-browser";
import { useMsal } from "@azure/msal-react";
import { AxiosError } from "axios";
import { useState, useEffect } from "react";
import { loginRequest } from "../../../authConfig";
import { Customer } from "../../../types";
import { apiClient } from "../../../utils";


interface UseCustomersData {
    customers: Customer[];
    loading: boolean;
    error: string | null;
    setCustomers: React.Dispatch<React.SetStateAction<Customer[]>>;
    setError: React.Dispatch<React.SetStateAction<string | null>>;
}

export const useCustomersData = (): UseCustomersData => {
    const { instance } = useMsal();
    const [customers, setCustomers] = useState<Customer[]>([]);
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState<string | null>(null);

    useEffect(() => {
        const fetchCustomers = async () => {
            setLoading(true);
            try {
                const response = await apiClient.get('/api/customers');
                setCustomers(response.data);
                setError(null);
            } catch (e) {
                if (e instanceof InteractionRequiredAuthError) {
                    await instance.acquireTokenRedirect({
                        ...loginRequest,
                        account: instance.getActiveAccount() as AccountInfo,
                    });
                } else if (e instanceof AxiosError) {
                    setError(e.response?.data?.message || 'Failed to fetch customers.');
                } else {
                    setError('An unexpected error occurred.');
                }
            } finally {
                setLoading(false);
            }
        };

        fetchCustomers();
    }, [instance]);

    return { customers, loading, error, setCustomers, setError };
};
