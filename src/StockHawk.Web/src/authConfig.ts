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

export const msalConfig: Configuration = {
  auth: {
    clientId: "442ec3d1-77b1-408d-8728-3426e40aeacf",
    authority: b2cPolicies.authorities.signUpSignIn.authority,
    knownAuthorities: [b2cPolicies.authorityDomain],
    redirectUri: "/",
  },
};
// Add here scopes for id token to be used at MS Identity Platform endpoints.
export const loginRequest: RedirectRequest = {
  scopes: [
    "https://stockhawkorg.onmicrosoft.com/api-gateway/Inventory.Read.All",
    "https://stockhawkorg.onmicrosoft.com/api-gateway/Order.ReadWrite.All",
    "https://stockhawkorg.onmicrosoft.com/api-gateway/Organization.Read.All",
    "https://stockhawkorg.onmicrosoft.com/api-gateway/Product.ReadWrite.All",
    "https://stockhawkorg.onmicrosoft.com/api-gateway/Supplier.ReadWrite.All",
    "https://stockhawkorg.onmicrosoft.com/api-gateway/User.ReadWrite.All",
  ],
};
export const graphConfig = {
  graphMeEndpoint: "https://graph.microsoft.com/v1.0/me",
};
