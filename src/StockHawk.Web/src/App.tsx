import './App.css'

// MSAL imports
import { MsalProvider } from "@azure/msal-react";
import { IPublicClientApplication } from "@azure/msal-browser";
import { CustomNavigationClient } from "./utils/NavigationClient";

// other imports
import { Route, Routes, useNavigate } from 'react-router-dom'
import { Home } from './pages/Home';
import { PageLayout } from './ui-components/PageLayout';
import ThemeContextProvider from './contexts/ThemeContext/ThemeContextProvider.tsx';
import { Weather } from "./pages/Weather.tsx";

type AppProps = {
    pca: IPublicClientApplication;
};

function App({ pca }: AppProps) {
    // TODO: check context has to be valid.
    // The next 3 lines are optional. This is how you configure MSAL to take advantage of the router's navigate functions when MSAL redirects between pages in your app
    const navigate = useNavigate();
    const navigationClient = new CustomNavigationClient(navigate);
    pca.setNavigationClient(navigationClient);

    return (
        <MsalProvider instance={pca}>
            <ThemeContextProvider>
                <PageLayout>
                    <Pages />
                </PageLayout>
            </ThemeContextProvider>
        </MsalProvider>
    );
}

function Pages() {
    return (
        <Routes>
            <Route path="/" element={<Home />} />
            <Route path="/weather" element={<Weather />} />
        </Routes>
    );
}

export default App;