import React from 'react';
import { Snackbar, Alert } from '@mui/material';

interface NotificationSnackbarProps {
    open: boolean;
    message: string | null;
    onClose: () => void;
    severity: 'success' | 'error';
}

export const NotificationSnackbar: React.FC<NotificationSnackbarProps> = ({ open, message, onClose, severity }) => {
    return (
        <Snackbar
            open={open}
            autoHideDuration={6000}
            onClose={onClose}
            anchorOrigin={{ vertical: 'top', horizontal: 'left' }}
        >
            <Alert
                onClose={onClose}
                severity={severity}
                className='w-full'
            >
                {message}
            </Alert>
        </Snackbar>
    );
};