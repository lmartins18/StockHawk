import React from 'react'
import ReactDOM from 'react-dom/client'
import App from './App.tsx'
import './index.css'

// MSAL imports
import {
  PublicClientApplication,
  EventType,
  EventMessage,
  AuthenticationResult,
} from "@azure/msal-browser";
import { msalConfig } from "./authConfig";
import { HashRouter } from 'react-router-dom';

export const msalInstance = new PublicClientApplication(msalConfig);

msalInstance.initialize().then(() => {
  // Account selection logic is app dependent. Adjust as needed for different use cases.
  const accounts = msalInstance.getAllAccounts();
  if (accounts.length > 0) {
    msalInstance.setActiveAccount(accounts[0]);
  }

  msalInstance.addEventCallback((event: EventMessage) => {
    if (event.eventType === EventType.LOGIN_SUCCESS && event.payload) {
      const payload = event.payload as AuthenticationResult;
      const account = payload.account;
      msalInstance.setActiveAccount(account);
    }
  });

  ReactDOM.createRoot(document.getElementById('root')!).render(
    <React.StrictMode>
      <HashRouter>
        <App pca={msalInstance} />
      </HashRouter>
    </React.StrictMode>,
  )
});