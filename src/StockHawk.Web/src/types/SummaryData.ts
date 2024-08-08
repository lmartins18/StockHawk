import { Order, ProductSummary } from ".";

export interface SummaryData {
  totalOrders: number;
  totalProducts: number;
  totalCategories: number;
  totalSales: number;
  recentOrders: Order[];
  lowStockProducts: ProductSummary[];
  outOfStockProducts: ProductSummary[];
}
