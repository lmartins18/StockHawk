import { useState, useEffect } from "react";
import { Category } from "../../../../types";
import { apiClient } from "../../../../utils";

export const useCategoriesData = () => {
    const [categories, setCategories] = useState<Category[]>([]);
    const [loading, setLoading] = useState<boolean>(false);
    const [error, setError] = useState<string | null>(null);

    useEffect(() => {
        (async () => {
            setLoading(true);
            try {
                const response = await apiClient.get<Category[]>('/api/categories');
                setCategories(response.data);
            } catch (e) {
                setError('Failed to fetch categories.');
            } finally {
                setLoading(false);
            }
        })();
    }, []);

    return {
        categories,
        loading,
        error,
        setCategories,
        setError,
    };
};
