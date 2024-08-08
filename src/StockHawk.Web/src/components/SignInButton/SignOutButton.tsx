import { useMsal } from "@azure/msal-react";
import LogoutIcon from "@mui/icons-material/Logout";
import { Button } from "@mui/material";

export const SignOutButton = () => {
    const { instance } = useMsal();

    const handleLogout = async () => await instance.logoutRedirect()

    return (
        <Button id="sign-out-button" variant="text" endIcon={<LogoutIcon />} color="inherit"
            onClick={handleLogout}>
            Sign out
        </Button>
    )
};
// Ref: https://github.com/AzureAD/microsoft-authentication-library-for-js/blob/dev/samples/msal-react-samples/typescript-sample/src/ui-components/SignInSignOutButton.tsx