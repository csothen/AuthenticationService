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

    this.handleSubmit = this.handleSubmit.bind(this);
    this.handleInputChanges = this.handleInputChanges.bind(this);
    this.handleSelectChanges = this.handleSelectChanges.bind(this);
    this.appendAttribute = this.appendAttribute.bind(this);
    this.removeAttribute = this.removeAttribute.bind(this);
    this.validateAttributes = this.validateAttributes.bind(this);

    this.state = {
      counter: 0,
      elements: [
        <TemplateAttribute
          ID={0}
          options={options}
          inputHandler={this.handleInputChanges}
          selectHandler={this.handleSelectChanges}
          removeHandler={this.removeAttribute}
        />,
      ],
      attributes: [
        {
          id: 0,
          name: "",
          type: 0,
        },
      ],
    };
  }

  validateAttributes() {
    for (let i = 0; i < this.state.attributes.length; i++) {
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
              removeHandler={this.removeAttribute}
            />,
          ],
          attributes: [
            ...this.state.attributes,
            {
              id: this.state.counter,
              name: "",
              type: 0,
            },
          ],
        });
      }
    );
  }

  removeAttribute(event, id) {
    event.preventDefault();
    let elements = [...this.state.elements];
    let attributes = [...this.state.attributes];
    attributes = attributes.filter((value, i, arr) => {
      if (value.id === id) {
        elements.splice(i, 1);
        return false;
      }
      return true;
    });
    this.setState({
      elements,
      attributes,
    });
  }

  handleInputChanges(event, id) {
    let attributes = [...this.state.attributes];
    for (let i = 0; i < attributes.length; i++) {
      let attribute = attributes[i];
      if (attribute.id === id) {
        attribute.name = event.target.value;
        attributes[i] = attribute;
        this.setState({ attributes });
        break;
      }
    }
  }

  handleSelectChanges(event, id) {
    let attributes = [...this.state.attributes];
    for (let i = 0; i < attributes.length; i++) {
      let attribute = attributes[i];
      if (attribute.id === id) {
        attribute.type = parseInt(event.target.value);
        attributes[i] = attribute;
        this.setState({ attributes });
        break;
      }
    }
  }

  async handleSubmit(event) {
    event.preventDefault();
    if (this.validateAttributes()) {
      let response = await fetch("https://localhost:5001/template", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({ attributes: this.state.attributes }),
      });
      console.log(response.json());
    } else {
      console.log("Verificar que todos os campos estão preenchidos");
    }
  }

  render() {
    return (
      <form style={{ marginTop: "5rem" }}>
        {this.state.elements}
        <div className="row" style={{ paddingTop: "15px" }}>
          <input
            className="u-full-width six columns"
            type="submit"
            onClick={(e) => this.handleSubmit(e)}
            value="Create"
          />
          <input
            className="u-full-width five columns"
            type="submit"
            onClick={(e) => this.appendAttribute(e)}
            value="Add"
          />
        </div>
      </form>
    );
  }
}
