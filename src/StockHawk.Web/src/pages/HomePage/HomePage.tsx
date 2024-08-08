import { useMsal } from "@azure/msal-react"
import { UnauthenticatedHome } from "./UnauthenticatedHome";
import { AuthenticatedHome } from "./AuthenticatedHome";

export const HomePage = () => {
    const { accounts } = useMsal();

    return accounts.length > 0
        ? <AuthenticatedHome />
        : <UnauthenticatedHome />
}