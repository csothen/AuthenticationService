import React from "react";
import { Link } from "react-router-dom";

const Navbar = (props) => {
  return (
    <div className="app-navbar-wrapper">
      <nav className="app-navbar">
        <h1>
          <Link to="/">Authentication</Link>
        </h1>
        {props.children}
      </nav>
    </div>
  );
};

export default Navbar;
