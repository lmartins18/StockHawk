import { TextField } from "@mui/material";
import { FieldErrors, UseFormRegister } from "react-hook-form";

interface EmailInputProps {
    label: string;
    name: string;
    register: UseFormRegister<any>;
    errors: FieldErrors;
    minValue?: number;
    integerOnly?: boolean;
    className?: string;
}

export const EmailInput: React.FC<EmailInputProps> = ({
    label,
    name = "Email",
    register,
    errors,
    className
}) => {


    return (
        <TextField
            className={className}
            label="Email"
            type="email"
            fullWidth
            margin="dense"
            {...register(name, {
                required: `${label} is required`,
                pattern: {
                    value: /^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$/, // ref: https://regexr.com/3e48o
                    message: 'Invalid email address'
                }
            })}
            error={!!errors[name]}
            helperText={errors[name]?.message as string}
        />
    );
};