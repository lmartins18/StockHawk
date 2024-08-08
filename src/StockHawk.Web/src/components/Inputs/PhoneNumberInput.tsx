import React from 'react';
import { TextField } from '@mui/material';
import { UseFormRegister, FieldErrors } from 'react-hook-form';

interface PhoneNumberInputProps {
    label: string;
    name: string;
    register: UseFormRegister<any>;
    errors: FieldErrors;
    required?: boolean;
    pattern?: RegExp;
    className?: string;
}

export const PhoneNumberInput: React.FC<PhoneNumberInputProps> = ({
    label,
    name,
    register,
    errors,
    required = true,
    pattern = /^(\+\d{1,2}\s?)?1?\-?\.?\s?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$/, // Ref: https://stackoverflow.com/a/56450924/15862625
    className
}) => {
    const defaultErrorMessage = "Please enter a valid phone number";

    return (
        <TextField
            className={className}
            label={label}
            fullWidth
            margin="dense"
            {...register(name, {
                required: required ? `${label} is required` : false,
                pattern: {
                    value: pattern,
                    message: defaultErrorMessage
                }
            })}
            error={!!errors[name]}
            helperText={errors[name]?.message as string}
        />
    );
};