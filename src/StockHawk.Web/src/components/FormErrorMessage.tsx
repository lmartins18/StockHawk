import { Typography } from "@mui/material";

export const FormErrorMessage = ({ error }: { error: string; }) => (
    <Typography color="error" className="mb-4 text-left">{error}</Typography>
)