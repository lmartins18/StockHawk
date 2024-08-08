import React from 'react';
import { TextField } from '@mui/material';
import { UseFormRegister, FieldErrors } from 'react-hook-form';

interface NumberInputProps {
    label: string;
    name: string;
    register: UseFormRegister<any>;
    errors: FieldErrors;
    minValue?: number;
    integerOnly?: boolean;
    className?: string;
}

export const NumberInput: React.FC<NumberInputProps> = ({
    label,
    name,
    register,
    errors,
    minValue = 1,
    integerOnly = true,
    className

}) => {
    const defaultErrorMessage = "Please write a non-negative number";

    return (
        <TextField
            className={className}
            label={label}
            type="number"
            fullWidth
            margin="dense"
            {...register(name, {
                required: `${label} is required`,
                valueAsNumber: true,
                validate: value => {
                    if (value < minValue) return defaultErrorMessage;
                    if (integerOnly && !Number.isInteger(value)) return `Please write an integer`;
                    return true;
                }
            })}
            error={!!errors[name]}
            helperText={errors[name]?.message as string}
        />
    );
};