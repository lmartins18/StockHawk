import React from 'react';
import { Dialog, DialogActions, DialogContent, DialogTitle, Button } from '@mui/material';

interface DeleteConfirmationDialogProps {
    open: boolean;
    onClose: () => void;
    onDelete: () => void;
    title: string;
    message: string;
}

export const DeleteConfirmationDialog: React.FC<DeleteConfirmationDialogProps> = ({
    open,
    onClose,
    onDelete,
    title,
    message
}) => {
    return (
        <Dialog open={open} onClose={onClose}>
            <DialogTitle className="text-lg font-bold">{title}</DialogTitle>
            <DialogContent>
                <p className="text-sm text-gray-700">{message}</p>
            </DialogContent>
            <DialogActions>
                <Button onClick={onClose} className="text-blue-600">Cancel</Button>
                <Button onClick={() => { onDelete(); onClose(); }} color="error" variant="contained">
                    Delete
                </Button>
            </DialogActions>
        </Dialog>
    );
};
