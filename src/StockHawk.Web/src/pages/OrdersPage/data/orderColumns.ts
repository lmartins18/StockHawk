import { GridColDef } from "@mui/x-data-grid";

export const orderColumns: GridColDef[] = [
  { field: "reference", headerName: "Reference", width: 150 },
  { field: "customerName", headerName: "Customer Name", width: 150 },
  {
    field: "orderDate",
    headerName: "Order Date",
    width: 200,
    valueFormatter: (_, row) => new Date(row.orderDate).toLocaleDateString(),
  },
  {
    field: "shippingCost",
    headerName: "Shipping Cost",
    type: "number",
    width: 130,
  },
  {
    field: "totalAmount",
    headerName: "Total Amount",
    type: "number",
    width: 130,
  },
  {
    field: "orderStatus",
    headerName: "Status",
    width: 130,
    valueGetter: (_, row) => row.orderStatus.name,
  },
  {
    field: "orderType",
    headerName: "Type",
    width: 130,
    valueGetter: (_, row) => row.orderType.name,
  },
];
