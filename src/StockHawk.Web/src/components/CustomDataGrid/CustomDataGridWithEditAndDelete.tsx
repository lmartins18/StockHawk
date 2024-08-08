import React from 'react';
import { GridActionsCellItem, GridColDef, GridRenderCellParams, GridValidRowModel } from '@mui/x-data-grid';
import EditIcon from '@mui/icons-material/Edit';
import DeleteIcon from '@mui/icons-material/Delete';
import { CustomDataGrid } from './CustomDataGrid';
import { Divider } from "@mui/material";

interface CustomDataGridWithEditAndDeleteProps {
    loading: boolean;
    rows: readonly GridValidRowModel[];
    columns: GridColDef[];
    className?: string;
    onEdit: (id: number) => void;
    onDelete: (id: number) => void;
}

export const CustomDataGridWithEditAndDelete: React.FC<CustomDataGridWithEditAndDeleteProps> = ({ loading, rows, columns, className, onEdit, onDelete }) => {
    const actionColumns: GridColDef[] = [
        {
            field: 'actions',
            type: 'actions',
            width: 75,
            renderCell: (params: GridRenderCellParams) => (
                <>
                    <GridActionsCellItem icon={<EditIcon />} label="Edit" onClick={() => onEdit(params.id as number)} />
                    <GridActionsCellItem icon={<DeleteIcon />} label="Delete" onClick={() => onDelete(params.id as number)} />
                    <Divider orientation="vertical" variant="middle" flexItem />
                </>
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