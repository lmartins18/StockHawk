import { GridColDef } from '@mui/x-data-grid';


export const supplierColumns: GridColDef[] = [
    { field: 'id', headerName: 'ID', width: 70 },
    { field: 'name', headerName: 'Name', width: 200 },
    { field: 'contactNumber', headerName: 'Contact Number', width: 200 },
    { field: 'email', headerName: 'Email', width: 200 },
    { field: 'address', headerName: 'Address', width: 250 },
];
