import React from 'react';
import { DataGrid, GridColDef, GridToolbar, GridValidRowModel } from '@mui/x-data-grid';

interface CustomDataGridProps {
    loading: boolean;
    rows: readonly GridValidRowModel[];
    columns: GridColDef[];
    className?: string;
}

export const CustomDataGrid: React.FC<CustomDataGridProps> = ({ loading, rows, columns, className }) => {
    return (
        <DataGrid
            loading={loading}
            rows={rows}
            columns={columns}
            slots={{ toolbar: GridToolbar }}
            className={className ?? "flex-grow"}
            slotProps={{
                toolbar: {
                    showQuickFilter: true,
                },
                loadingOverlay: {
                    variant: 'linear-progress',
                    noRowsVariant: 'linear-progress',
                },
            }}
            initialState={{
                pagination: {
                    paginationModel: { page: 0, pageSize: 5 },
                },
            }}
            pageSizeOptions={[5, 10]}
        />
    );
};
