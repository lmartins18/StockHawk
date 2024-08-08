import { IPublicClientApplication } from "@azure/msal-browser";
import { MsalProvider } from "@azure/msal-react";
import { useNavigate } from "react-router-dom";
import { AppRoutes } from "./AppRoutes";
import { ColorModeProvider, PageLayout } from "./components";
import { CustomNavigationClient } from "./utils/NavigationClient";

type AppProps = {
    pca: IPublicClientApplication;
};

function App({ pca }: AppProps) {
    const navigate = useNavigate();
    const navigationClient = new CustomNavigationClient(navigate);
    pca.setNavigationClient(navigationClient);

    return (
        <MsalProvider instance={pca}>
            <ColorModeProvider>
                <PageLayout>
                    <AppRoutes />
                </PageLayout>
            </ColorModeProvider>
        </MsalProvider>
    );
}

export default App;