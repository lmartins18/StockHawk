import { useMsal } from "@azure/msal-react";
import { loginRequest } from "../authConfig";

export const SignInButton = () => {
    const { instance } = useMsal();
    const handleLogin = () => instance.loginRedirect(loginRequest)

    return (
        <div>
            <button
                onClick={handleLogin}
            >
                Login
            </button>
        </div>
    )
};