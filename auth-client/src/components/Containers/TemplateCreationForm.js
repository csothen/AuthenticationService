import React, { Component } from "react";
import TemplateAttribute from "../Presentational/TemplateAttribute";

const options = {
  0: "Username",
  1: "Email",
  2: "Password",
  3: "Text",
  4: "Date",
  5: "Integer",
  6: "Decimal number",
};

export default class TemplateCreationForm extends Component {
  constructor(props) {
    super(props);
    this.state = {
      counter: 0,
      elements: [],
      attributes: [
        {
          name: "",
          type: 0,
        },
      ],
    };

    this.handleSubmit = this.handleSubmit.bind(this);
    this.handleInputChanges = this.handleInputChanges.bind(this);
    this.handleSelectChanges = this.handleSelectChanges.bind(this);
    this.appendAttribute = this.appendAttribute.bind(this);
    this.validateAttributes = this.validateAttributes.bind(this);
  }

  validateAttributes() {
    for (var i = 0; i < this.state.attributes.length; i++) {
      const attr = this.state.attributes[i];
      if (attr["name"] === "") {
        return false;
      }
    }
    return true;
  }

  appendAttribute(event) {
    event.preventDefault();
    this.setState(
      {
        counter: this.state.counter + 1,
      },
      () => {
        this.setState({
          elements: [
            ...this.state.elements,
            <TemplateAttribute
              ID={this.state.counter}
              options={options}
              inputHandler={this.handleInputChanges}
              selectHandler={this.handleSelectChanges}
            />,
          ],
          attributes: [
            ...this.state.attributes,
            {
              name: "",
              type: 0,
            },
          ],
        });
      }
    );
  }

  handleInputChanges(event, id) {
    let attributes = [...this.state.attributes];
    let attribute = { ...attributes[id] };
    attribute.name = event.target.value;
    attributes[id] = attribute;
    this.setState({ attributes });
  }

  handleSelectChanges(event, id) {
    let attributes = [...this.state.attributes];
    let attribute = { ...attributes[id] };
    attribute.type = parseInt(event.target.value);
    attributes[id] = attribute;
    this.setState({ attributes });
  }

  async handleSubmit(event) {
    event.preventDefault();
    if (this.validateAttributes()) {
      var response = await fetch("https://localhost:5001/template", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({ attributes: this.state.attributes }),
      });
      console.log(response.body);
    } else {
      console.log("Verificar que todos os campos estão preenchidos");
    }
  }

  render() {
    return (
      <form style={{ marginTop: "5rem" }}>
        <TemplateAttribute
          ID={0}
          options={options}
          inputHandler={this.handleInputChanges}
          selectHandler={this.handleSelectChanges}
        />
        {this.state.elements}
        <div className="button-container">
          <input
            className="u-full-width six columns"
            type="submit"
            onClick={(e) => this.handleSubmit(e)}
            value="Create"
          />
          <input
            className="u-full-width six columns"
            type="submit"
            onClick={(e) => this.appendAttribute(e)}
            value="Add"
          />
        </div>
      </form>
    );
  }
}
