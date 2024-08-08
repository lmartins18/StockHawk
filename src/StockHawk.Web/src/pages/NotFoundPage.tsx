import React from 'react';

export const NotFoundPage: React.FC = () => {
    return (
        <div className="flex flex-col items-center justify-start min-h-screen bg-gray-100 m-20">
            <div className="text-center">
                <h1 className="text-7xl font-mono font-extrabold text-main mb-4">404</h1>
                <p className="text-xl text-gray-700 mb-4">Oops! Page not found.</p>
                <p className="text-lg text-gray-500 mb-8">
                    The page you're looking for doesn't exist or has been moved. Please check the URL or go back to the homepage.
                </p>
                <a href="/" className="text-blue-500 hover:underline">
                    Go to Homepage
                </a>
            </div>
        </div>
    );
};
