import React from "react";

import AuthenticationForm from "../Containers/AuthenticationForm";

const AuthenticationPage = (props) => {
  return <AuthenticationForm login={props.loginHandler} />;
};

export default AuthenticationPage;
