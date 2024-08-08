import { useState, useEffect } from "react";
import { Supplier } from "../../../../types";
import { apiClient } from "../../../../utils";

export const useSuppliersData = () => {
    const [suppliers, setSuppliers] = useState<Supplier[]>([]);
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState<string | null>(null);

    useEffect(() => {
        (async () => {
            setLoading(true);
            try {
                const response = await apiClient.get('/api/suppliers');
                setSuppliers(response.data);
            } catch (e) {
                setError("Failed to fetch suppliers.");
            } finally {
                setLoading(false);
            }
        })();
    }, []);

    return { suppliers, loading, error, setSuppliers, setError };
};
