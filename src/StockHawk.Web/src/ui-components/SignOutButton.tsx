import { useMsal } from "@azure/msal-react";

export const SignOutButton = () => {
    const { instance } = useMsal();

    const logoutRequest = {
        postLogoutRedirectUri: "https://localhost:8080/",
    };

    const handleLogout = async () => await instance.logoutRedirect(logoutRequest)

    return (
        <div>
            <button
                onClick={handleLogout}
                color="inherit"
            >
                Logout
            </button>
        </div>
    )
};