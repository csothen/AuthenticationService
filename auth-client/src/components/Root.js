import React, { Component } from "react";
import { BrowserRouter as Router, Route, Switch, Link } from "react-router-dom";
import { Provider } from "react-redux";

import App from "./App";
import Footer from "./Footer";
import Navbar from "./Navbar";

import "../App.css";

export default class Root extends Component {
  constructor(props) {
    super(props);
  }

  render() {
    return (
      <Provider store={this.props.store}>
        <Router>
          <Navbar>
            <ul>
              <li>
                <Link to="/about">About</Link>
              </li>
              <li>
                <Link to="/login">Login</Link>
              </li>
            </ul>
          </Navbar>
          <Switch>
            <Route path="/" component={App} />
          </Switch>
          <Footer>Informação importante para aqui??? Copyright e assim?</Footer>
        </Router>
      </Provider>
    );
  }
}
