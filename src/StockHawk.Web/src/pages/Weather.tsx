import { useEffect, useState } from "react";

// Msal imports
import { MsalAuthenticationTemplate, useMsal } from "@azure/msal-react";
import { InteractionStatus, InteractionType, InteractionRequiredAuthError, AccountInfo } from "@azure/msal-browser";

// Sample app imports
import { Loading } from "../ui-components/Loading";
import { ErrorComponent } from "../ui-components/ErrorComponent";
import { fetchData } from "../utils/MsGraphApiCall";

import { loginRequest } from "../authConfig";

interface WeatherData {
    "dateFormatted": string;
    "temperatureC": number;
    "summary": string;
    "temperatureF": number;
}

const WeatherContent = () => {
    const { instance, inProgress } = useMsal();
    const [weatherData, setWeatherData] = useState<null | WeatherData>(null);

    useEffect(() => {
        if (!weatherData && inProgress === InteractionStatus.None) {
            fetchData("/api/weatherforecast").then(response => setWeatherData(response)).catch((e) => {
                if (e instanceof InteractionRequiredAuthError) {
                    instance.acquireTokenRedirect({
                        ...loginRequest,
                        account: instance.getActiveAccount() as AccountInfo
                    });
                }
            });
        }
    }, [inProgress, weatherData, instance]);

    return (
        <>
            {weatherData ? <>{JSON.stringify(weatherData)}</> : null}
        </>
    );
};

export function Weather() {
    const authRequest = {
        ...loginRequest
    };

    return (
        <MsalAuthenticationTemplate
            interactionType={InteractionType.Redirect}
            authenticationRequest={authRequest}
            errorComponent={ErrorComponent}
            loadingComponent={Loading}
        >
            <WeatherContent />
        </MsalAuthenticationTemplate>
    )
}