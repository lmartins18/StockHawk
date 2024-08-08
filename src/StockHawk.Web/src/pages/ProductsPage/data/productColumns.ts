import { GridColDef } from "@mui/x-data-grid";

export const productColumns: GridColDef[] = [
  { field: "id", headerName: "ID", width: 70 },
  { field: "name", headerName: "Name", width: 130 },
  { field: "description", headerName: "Description", width: 200 },
  { field: "price", headerName: "Price", type: "number", width: 100 },
  { field: "quantity", headerName: "Quantity", type: "number", width: 100 },
  {
    field: "lowStockThreshold",
    headerName: "Low Stock Threshold",
    type: "number",
    width: 150,
  },
  {
    field: "category",
    headerName: "Category",
    width: 150,
    valueGetter: (_, row) => row.category.name,
  },
  {
    field: "supplier",
    headerName: "Supplier",
    width: 150,
    valueGetter: (_, row) => row.supplier.name,
  },
];
