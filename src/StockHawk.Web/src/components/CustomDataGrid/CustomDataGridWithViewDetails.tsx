import React from 'react';
import { GridActionsCellItem, GridColDef, GridRenderCellParams, GridValidRowModel } from '@mui/x-data-grid';
import VisibilityIcon from '@mui/icons-material/Visibility';
import { CustomDataGrid } from "./CustomDataGrid";

interface CustomDataGridWithViewDetailsProps {
    loading: boolean;
    rows: readonly GridValidRowModel[];
    columns: GridColDef[];
    className?: string;
    onViewDetails: (id: number) => void;
}

export const CustomDataGridWithViewDetails: React.FC<CustomDataGridWithViewDetailsProps> = ({ loading, rows, columns, className, onViewDetails }) => {
    const actionColumns: GridColDef[] = [
        {
            field: 'actions',
            type: 'actions',
            width: 50,
            renderCell: (params: GridRenderCellParams) => (
                <GridActionsCellItem icon={<VisibilityIcon />} label="Edit" onClick={() => onViewDetails(params.id as number)} />
            ),
        },
    ];

    return (
        <CustomDataGrid
            loading={loading}
            rows={rows}
            columns={[...actionColumns, ...columns]}
            className={className}
        />
    );
};

