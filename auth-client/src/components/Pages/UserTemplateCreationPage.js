import React from "react";
import TemplateCreationForm from "../Containers/TemplateCreationForm";

const UserTemplateCreationPage = (props) => {
  return (
    <div>
      <h1 className="header">Create your own user template</h1>
      <TemplateCreationForm />
    </div>
  );
};

export default UserTemplateCreationPage;
