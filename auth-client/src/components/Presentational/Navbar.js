import React, { Component } from "react";
import { FaAlignRight } from "react-icons/fa";
import { alertSuccess } from "../../services/AlertService";

export default class NavBar extends Component {
  constructor(props) {
    super(props);
    this.state = {
      user: this.props.user,
    };

    this.links = this.links.bind(this);
    this.handleLogout = this.handleLogout.bind(this);
  }

  links() {
    if (this.state.user) {
      return (
        <ul className="links">
          <li>
            <a href="/templates">Create Template</a>
          </li>
          <li>
            <a href="/profile">{this.props.user.organization.name}</a>
          </li>
          <li>
            {" "}
            <a onClick={this.handleLogout}>Logout</a>
          </li>
        </ul>
      );
    } else {
      return (
        <ul className="links">
          <li>
            <a href="/auth">Sign in / Sign up</a>
          </li>
        </ul>
      );
    }
  }

  handleLogout() {
    this.props.logoutHandler();
    alertSuccess("Logged out", "Logged out successfully");
    this.setState({ user: null });
  }

  render() {
    return (
      <>
        <div className="navBar">
          <div className="logo">
            <a href="/">AuthS</a>
          </div>
          {this.links()}
        </div>
      </>
    );
  }
}
