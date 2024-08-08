import { Configuration, RedirectRequest } from "@azure/msal-browser";

/**
 * Enter here the user flows and custom policies for your B2C application
 * To learn more about user flows, visit: https://docs.microsoft.com/en-us/azure/active-directory-b2c/user-flow-overview
 * To learn more about custom policies, visit: https://docs.microsoft.com/en-us/azure/active-directory-b2c/custom-policy-overview
 */
export const b2cPolicies = {
  names: {
    signUpSignIn: "B2C_1_stockhawk_signupsignin",
    resetPassword: "B2C_1_stockhawk_passwordreset",
  },
  authorities: {
    signUpSignIn: {
      authority:
        "https://stockhawkorg.b2clogin.com/stockhawkorg.onmicrosoft.com/B2C_1_stockhawk_signupsignin",
    },
    resetPassword: {
      authority:
        "https://stockhawkorg.b2clogin.com/stockhawkorg.onmicrosoft.com/B2C_1_stockhawk_passwordreset",
    },
  },
  authorityDomain: "stockhawkorg.b2clogin.com",
};
export const b2cScopes = import.meta.env.VITE_B2C_SCOPES?.split(" ") || [];

export const msalConfig: Configuration = {
  auth: {
    clientId: "442ec3d1-77b1-408d-8728-3426e40aeacf",
    authority: b2cPolicies.authorities.signUpSignIn.authority,
    knownAuthorities: [b2cPolicies.authorityDomain],
    redirectUri: "/",
  },
};

export const loginRequest: RedirectRequest = {
  scopes: b2cScopes,
};
