import React from "react";

import { types } from "../../enums/types";

const TemplateAttribute = (props) => {
  const options = Object.keys(types).map((type, i) => (
    <option key={props.ID + "_" + i} value={type}>
      {types[type]}
    </option>
  ));
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
      <div className="five columns">
        <select
          className="u-full-width"
          onChange={(e) => props.selectHandler(e, props.ID)}
        >
          {options}
        </select>
      </div>
      <div className="one columns">
        <button onClick={(e) => props.removeHandler(e, props.ID)}>
          <span role="img" aria-label="Remove">
            ❌
          </span>
        </button>
      </div>
    </div>
  );
};

export default TemplateAttribute;
