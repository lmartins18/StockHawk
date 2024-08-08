import { InteractionRequiredAuthError, AccountInfo } from "@azure/msal-browser";
import { useMsal } from "@azure/msal-react";
import { CircularProgress, Container, Grid, Card, CardContent, List, ListItem, ListItemText } from "@mui/material";
import { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { loginRequest } from "../../authConfig";
import { SummaryData } from "../../types";
import { apiClient } from "../../utils";

export const AuthenticatedHome: React.FC = () => {
    const [summaryData, setSummaryData] = useState<SummaryData | null>(null);
    const [loading, setLoading] = useState(true);
    const { instance } = useMsal();
    const navigate = useNavigate();

    useEffect(() => {
        const fetchSummaryData = async () => {
            try {
                const response = await apiClient.get<SummaryData>('/api/summary/dashboard');
                setSummaryData(response.data);
            } catch (e) {
                if (e instanceof InteractionRequiredAuthError) {
                    await instance.acquireTokenRedirect({
                        ...loginRequest,
                        account: instance.getActiveAccount() as AccountInfo,
                    });
                }
            } finally {
                setLoading(false);
            }
        };

        fetchSummaryData();
    }, []);

    if (loading) {
        return <CircularProgress />;
    }

    const cardStyles = (color: string) => ({
        backgroundColor: color,
        color: 'white',
        cursor: 'pointer',
        '&:hover': {
            opacity: 0.8,
        },
        margin: 1
    });

    return (
        <Container className="mx-auto py-8">
            <h1 className="text-2xl font-bold mb-8">Dashboard Summary</h1>
            <Grid container spacing={3}>
                <Grid item xs={12} md={4}>
                    <Card sx={cardStyles('#ff9800')} onClick={() => navigate('/orders')}>
                        <CardContent>
                            <h2 className="text-lg font-semibold">Total Sales</h2>
                            <p className="text-3xl font-bold">€{summaryData?.totalSales.toFixed(2)}</p>
                        </CardContent>
                    </Card>
                    <Card sx={cardStyles('#f44336')} onClick={() => navigate('/orders')}>
                        <CardContent>
                            <h2 className="text-lg font-semibold">Total Orders</h2>
                            <p className="text-3xl font-bold">{summaryData?.totalOrders}</p>
                        </CardContent>
                    </Card>
                    <Card sx={cardStyles('#4caf50')} onClick={() => navigate('/categories')}>
                        <CardContent>
                            <h2 className="text-lg font-semibold">Total Categories</h2>
                            <p className="text-3xl font-bold">{summaryData?.totalCategories}</p>
                        </CardContent>
                    </Card>
                </Grid>
                <Grid item xs={12} md={4}>
                    <Card sx={cardStyles('#2196f3')} onClick={() => navigate('/products')}>
                        <CardContent>
                            <h2 className="text-lg font-semibold">Total Products</h2>
                            <p className="text-3xl font-bold">{summaryData?.totalProducts}</p>
                        </CardContent>
                    </Card>
                    <Card sx={cardStyles('#ff5722')} onClick={() => navigate('/products')}>
                        <CardContent>
                            <h2 className="text-lg font-semibold">Low Stock Products</h2>
                            {summaryData?.lowStockProducts.length ?? 0 > 0
                                ? (<List>
                                    {summaryData?.lowStockProducts.map(product => (
                                        <ListItem key={product.id}>
                                            <ListItemText
                                                primary={product.name}
                                                secondary={`Quantity: ${product.quantity}`}
                                            />
                                        </ListItem>
                                    ))}
                                </List>)
                                : (<p className="text-3xl font-bold">0</p>)
                            }
                        </CardContent>
                    </Card>
                    <Card sx={cardStyles('#607d8b')} onClick={() => navigate('/products')}>
                        <CardContent>
                            <h2 className="text-lg font-semibold">Out of Stock Products</h2>
                            {summaryData?.outOfStockProducts.length ?? 0 > 0
                                ? (<List>
                                    {summaryData?.outOfStockProducts.map(product => (
                                        <ListItem key={product.id}>
                                            <ListItemText
                                                primary={product.name}
                                                secondary={`Quantity: ${product.quantity}`}
                                            />
                                        </ListItem>
                                    ))}
                                </List>)
                                : (<p className="text-3xl font-bold">0</p>)
                            }
                        </CardContent>
                    </Card>
                </Grid>
                <Grid item xs={12} md={4}>
                    <Card sx={cardStyles('#9c27b0')} onClick={() => navigate('/orders')}>
                        <CardContent>
                            <h2 className="text-lg font-semibold">Recent Orders</h2>
                            <List>
                                {summaryData?.recentOrders.map(order => (
                                    <ListItem key={order.id}>
                                        <ListItemText
                                            primary={order.reference}
                                            secondary={`Date: ${new Date(order.orderDate).toLocaleDateString()}, Total: €${order.totalAmount.toFixed(2)}`}
                                        />
                                    </ListItem>
                                ))}
                            </List>
                        </CardContent>
                    </Card>
                </Grid>
            </Grid>
        </Container>
    );
};
