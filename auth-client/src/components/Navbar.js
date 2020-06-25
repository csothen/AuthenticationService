import React, { Component } from "react";
import { Link } from "react-router-dom";

export default class Navbar extends Component {
  constructor(props) {
    super(props);
  }
  render() {
    return (
      <div className="AppNavWrapper">
        <nav className="AppNavbar">
          <h1 className="logo">
            <Link to="/">Authentication</Link>
          </h1>
          {this.props.children}
        </nav>
      </div>
    );
  }
}
