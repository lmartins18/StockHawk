import React from 'react'
import ReactDOM from 'react-dom/client'
import App from './App.tsx'
import './index.css'
import {
  PublicClientApplication,
  EventType,
  EventMessage,
  AuthenticationResult,
} from "@azure/msal-browser";
import { b2cPolicies, msalConfig, b2cScopes } from './authConfig';
import { HashRouter } from 'react-router-dom';

export const msalInstance = new PublicClientApplication(msalConfig);

msalInstance.initialize().then(() => {
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
    else if (event.eventType === EventType.LOGIN_FAILURE) {
      if (event.error?.message.includes("AADB2C90118")) { // The user has forgotten their password.
        const authority = b2cPolicies.authorities.resetPassword.authority;
        msalInstance.loginRedirect({ scopes: b2cScopes, authority: authority })
      }
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