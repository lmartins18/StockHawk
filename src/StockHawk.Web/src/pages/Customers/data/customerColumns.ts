import { GridColDef } from "@mui/x-data-grid";

export const customerColumns: GridColDef[] = [
  { field: "id", headerName: "ID", width: 70 },
  { field: "firstName", headerName: "First Name", width: 150 },
  { field: "lastName", headerName: "Last Name", width: 150 },
  { field: "email", headerName: "Email", width: 200 },
  { field: "phoneNumber", headerName: "Phone Number", width: 150 },
  { field: "address", headerName: "Address", width: 200 },
];
