import { CreateOrderItemDto } from "./CreateOrderItemDto.ts";

export interface CreateOrderDto {
  reference: string;
  customerId: number;
  orderDate?: string;
  shippingCost?: number;
  totalAmount?: number;
  orderStatusId: number;
  orderTypeId: number;
  orderItems: CreateOrderItemDto[];
}
