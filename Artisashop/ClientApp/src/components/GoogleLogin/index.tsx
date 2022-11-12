import React from "react";
import { GoogleLogin } from "react-google-login";
import { REACT_APP_GOOGLE_CLIENT_ID } from "conf";

const cookiePolicy = "single_host_origin";

const GoogleLoginButton = () => {
  const responseGoogle = (response: any) =>
    console.log(response);

  return (
    <GoogleLogin
      clientId={REACT_APP_GOOGLE_CLIENT_ID}
      buttonText="Se connecter avec Google"
      onSuccess={responseGoogle}
      onFailure={responseGoogle}
      cookiePolicy={cookiePolicy}
    />
  );
}

export default GoogleLoginButton;
