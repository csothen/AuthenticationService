import React, { Component } from "react";
import { Redirect } from "react-router-dom";

import { getByOrganization } from "../../services/TemplatesService";
import { alertError } from "../../services/AlertService";
import TemplateApresentation from "../Presentational/TemplateApresentation";

import loading from "../../img/loading.gif";

export default class Profile extends Component {
  constructor(props) {
    super(props);
    this.state = {
      loading: true,
      templates: [],
      elements: [],
    };

    this.setElements = this.setElements.bind(this);
  }

  componentDidMount() {
    if (this.props.user) {
      getByOrganization(
        this.props.user.organization.email,
        this.props.user.token
      )
        .then((response) => {
          this.setState(
            {
              loading: false,
              templates: response.data,
            },
            () => {
              this.setElements();
            }
          );
        })
        .catch((error) => {
          alertError("Error", "Failed to load the profile");
        });
    }
  }

  setElements() {
    let templates = [...this.state.templates];
    let elements = templates.map((template, i) => {
      return <TemplateApresentation template={template} />;
    });
    this.setState({ elements: elements });
  }

  render() {
    if (!this.props.user) {
      return <Redirect to="/auth" />;
    } else {
      return (
        <div>
          <h1 className="profile-header">
            {this.props.user.organization.name}'s profile
          </h1>
          {this.state.loading && <img src={loading} alt="loading. . ." />}
          <div className="show-template">
            {!this.state.loading && this.state.elements}
          </div>
        </div>
      );
    }
  }
}
