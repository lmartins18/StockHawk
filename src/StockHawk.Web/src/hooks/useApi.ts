import axios from "axios";
import { loginRequest } from "../authConfig";
import { msalInstance } from "../main";

const useApi = async (baseUrl?: string) => {
  const account = msalInstance.getActiveAccount();
  if (!account) {
    throw Error(
      "No active account! Verify a user has been signed in and setActiveAccount has been called."
    );
  }
  const response = await msalInstance.acquireTokenSilent({
    ...loginRequest,
    account: account,
  });

  const bearer = `Bearer ${response.accessToken}`;
  const axiosInstance = axios.create({
    baseURL: `${baseUrl ?? import.meta.env.VITE_API_URL}`,
    headers: {
      "Content-Type": "application/json",
      Authorization: bearer,
    },
  });

  return { axiosInstance };
};
export default useApi;
