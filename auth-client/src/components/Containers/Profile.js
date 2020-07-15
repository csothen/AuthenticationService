import React, { Component } from "react";
import { Redirect } from "react-router-dom";

import { getByOrganization } from "../../services/TemplatesService";
import { alertError } from "../../services/AlertService";

export default class Profile extends Component {
  constructor(props) {
    super(props);
    this.state = {
      templates: [],
    };
  }

  componentDidMount() {
    if (this.props.user) {
      getByOrganization(this.props.user.organization.email)
        .then((response) => {
          console.log(response);
        })
        .catch((error) => {
          alertError("Error", "Failed to load your profile");
        });
    }
  }

  render() {
    if (!this.props.user) {
      return <Redirect to="/auth" />;
    } else {
      return <h1>ola</h1>;
    }
  }
}
