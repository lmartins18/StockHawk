import { AuthenticatedTemplate, UnauthenticatedTemplate } from "@azure/msal-react";
import { NavLink } from "react-router-dom";

export function Home() {
  return (
    <>
      <AuthenticatedTemplate>
        <NavLink to={"/weather"}>Request Profile Information</NavLink>
      </AuthenticatedTemplate>

      <UnauthenticatedTemplate>
        <h6>Please sign-in to see your profile information.</h6>
      </UnauthenticatedTemplate>
    </>
  );
}