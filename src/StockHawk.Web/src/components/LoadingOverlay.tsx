import React from 'react';
import CircularProgress from '@mui/material/CircularProgress';

export const LoadingOverlay: React.FC = () => (
    <div className="fixed inset-0 flex items-center justify-center bg-main bg-opacity-10 z-auto">
        <CircularProgress />
    </div>
);