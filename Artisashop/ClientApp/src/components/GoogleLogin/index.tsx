import React from "react";
import {GoogleLogin} from "react-google-login";
import {Google as GoogleConfig} from "conf";

const cookiePolicy = "single_host_origin";

const GoogleLoginButton = () => {
  const responseGoogle = (response: any) => 
    console.log(response);

  return (
    <GoogleLogin
      clientId={GoogleConfig.clientId}
      buttonText="Se connecter avec Google"
      onSuccess={responseGoogle}
      onFailure={responseGoogle}
      cookiePolicy={cookiePolicy}
    />
  );
}

export default GoogleLoginButton;
