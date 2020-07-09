import React from "react";

const TemplateAttribute = (props) => {
  const options = Object.keys(props.options).map((option, i) => (
    <option key={props.ID + "_" + i} value={option}>
      {props.options[option]}
    </option>
  ));
  console.log(props.ID);

  return (
    <div className="row">
      <div className="six columns">
        <input
          className="u-full-width"
          type="text"
          placeholder="Name of the attribute"
          onChange={(e) => props.inputHandler(e, props.ID)}
          name={"attr_" + props.ID}
        />
      </div>
      <div className="six columns">
        <select
          className="u-full-width"
          onChange={(e) => props.selectHandler(e, props.ID)}
        >
          {options}
        </select>
      </div>
    </div>
  );
};

export default TemplateAttribute;
