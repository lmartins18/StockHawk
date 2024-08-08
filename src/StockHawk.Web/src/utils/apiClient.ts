import axios from "axios";
import { msalInstance } from "../main";
import { loginRequest } from "../authConfig";
import { InteractionRequiredAuthError } from "@azure/msal-browser";

const baseURL = import.meta.env.VITE_API_URL;

export const apiClient = axios.create({
  baseURL,
  headers: {
    "Content-Type": "application/json",
  },
});

apiClient.interceptors.request.use(
  async (config) => {
    const account = msalInstance.getActiveAccount();
    if (!account) {
      window.location.replace("/");
      throw new Error(
        "No active account! Verify a user has been signed in and setActiveAccount has been called."
      );
    }

    try {
      const response = await msalInstance.acquireTokenSilent({
        ...loginRequest,
        account: account,
      });

      config.headers["Authorization"] = `Bearer ${response.accessToken}`;
    } catch (error) {
      if (error instanceof InteractionRequiredAuthError) {
        await msalInstance.acquireTokenRedirect(loginRequest);
      } else {
        console.error("Error acquiring token:", error);
      }
    }
    return config;
  },
  (error) => {
    return Promise.reject(error);
  }
);
