import { Route, Routes } from "react-router-dom";
import { ProductsPage, Customers, OrdersPage, Stock, HomePage, NotFoundPage } from "./pages";
import ErrorBoundary from "./components/ErrorBoundary";


export function AppRoutes() {
    return (
        <ErrorBoundary>
            <Routes>
                <Route path="/" element={<HomePage />} />
                <Route path="*" element={<NotFoundPage />} />
                <Route path="/products" element={<ProductsPage />} />
                <Route path="/customers" element={<Customers />} />
                <Route path="/orders" element={<OrdersPage />} />
                <Route path="/stock" element={<Stock />} />
            </Routes>
        </ErrorBoundary>
    );
}