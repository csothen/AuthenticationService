import React, { Component } from "react";
import { Provider } from "react-redux";

// COMPONENTS
import Footer from "./Footer";
import Navbar from "./Navbar";

// STYLES
import "../App.css";

export default class App extends Component {
  constructor(props) {
    super(props);
  }

  render() {
    return (
      <div className="AppPage">
        <h1>HELLO WORLD!</h1>
      </div>
    );
  }
}
