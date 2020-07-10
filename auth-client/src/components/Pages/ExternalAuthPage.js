import React from "react";

import ExternalAuthForm from "../Containers/ExternalAuthForm";

const ExternalAuthPage = (props) => {
  const orgRef = props.match.params.orgRef;
  return <ExternalAuthForm orgRef={orgRef} />;
};

export default ExternalAuthPage;
