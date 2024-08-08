import React from 'react';
import landingImage from './../../assets/landing.svg';

export const UnauthenticatedHome: React.FC = () => {
    return (
        <div className="flex flex-col md:flex-row items-center w-full h-full p-6">
            <div className="flex-1 text-center md:text-left p-6">
                <h1 className="sm:flex-start text-4xl md:text-5xl font-extrabold text-gray-900 mb-4">
                    Welcome to StockHawk
                </h1>
                <p className="text-lg text-gray-700">
                    We're excited to have you here! Explore our features and enjoy our services.
                </p>
            </div>

            <div className="flex-1">
                <img src={landingImage} alt="Landing" className="w-full max-w-md mx-auto" />
            </div>
        </div>
    );
};
