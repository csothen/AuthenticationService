import React from "react";
import TemplateCreationForm from "../Containers/TemplateCreationForm";

const UserTemplateCreationPage = (props) => {
  return (
    <div>
      <h1 className="header">Create your own user template</h1>
      <TemplateCreationForm user={props.user} />
    </div>
  );
};

export default UserTemplateCreationPage;
