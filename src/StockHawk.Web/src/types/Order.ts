import { OrderStatus } from "./OrderStatus.ts";
import { OrderType } from "./OrderType.ts";

export interface Order {
  id: number;
  reference: string;
  customerName: string;
  orderDate: string;
  shippingCost: number;
  totalAmount: number;
  orderStatus: OrderStatus;
  orderType: OrderType;
  orderItems: {
    productId: number;
    productName: string;
    quantity: number;
    productPrice: number;
    totalPrice: number;
  }[];
}
