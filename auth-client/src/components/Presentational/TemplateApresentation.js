import React, { useState } from "react";

import { FaChevronDown, FaChevronUp } from "react-icons/fa";
import { types } from "../../enums/types";

const TemplateApresentation = (props) => {
  const [open, toggleDropdown] = useState(false);

  const template = props.template;

  const attributes = template.attributes.map((attr, i) => (
    <div key={template._tid + "_" + i} className="row">
      <div className="six columns">{attr.name}</div>
      <div className="six columns">{types[attr.type]}</div>
    </div>
  ));

  function drop() {
    toggleDropdown(!open);
  }

  return (
    <div className="row">
      <button className="u-full-width profile-dropbutton" onClick={drop}>
        {template._tid}
        {open ? <FaChevronUp /> : <FaChevronDown />}
      </button>
      <div
        className="profile-dropdown-content"
        style={open ? { display: "block" } : { display: "none" }}
      >
        <div className="row profile-content-header">
          <div className="six columns">Name</div>
          <div className="six columns">Type</div>
        </div>
        {attributes}
      </div>
    </div>
  );
};

export default TemplateApresentation;
