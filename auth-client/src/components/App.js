import React, { Component } from "react";
import { Provider } from "react-redux";

// COMPONENTS
import Footer from "./footer";
import Navbar from "./navbar";

// STYLES
import "../App.css";

export default class App extends Component {
  constructor(props) {
    super(props);
  }

  render() {
    return (
      <div className="App">
        <Navbar></Navbar>
        <div className="MainContainer">
          <h1>HELLO WORLD!</h1>
        </div>
        <Footer>O melhor footer de sempre</Footer>
      </div>
    );
  }
}
