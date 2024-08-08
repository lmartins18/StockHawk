import { useMsal } from "@azure/msal-react";
import { loginRequest } from "../../authConfig";
import LoginIcon from '@mui/icons-material/Login';
import { Button } from "@mui/material";

export const SignInButton = () => {
    const { instance } = useMsal();
    const handleLogin = () => instance.loginRedirect(loginRequest)

    return (
        <Button id="sign-in-button" variant="text" endIcon={<LoginIcon />} color="inherit"
            onClick={handleLogin}>
            Sign In
        </Button>
    )
};

// Ref: https://github.com/AzureAD/microsoft-authentication-library-for-js/blob/dev/samples/msal-react-samples/typescript-sample/src/ui-components/SignInSignOutButton.tsx