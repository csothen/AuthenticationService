import React, { Component } from "react";
import { BrowserRouter as Router, Route, Switch, Link } from "react-router-dom";

// COMPONENTS
import HomePage from "./Pages/HomePage";
import Navbar from "./Presentational/Navbar";
import Footer from "./Presentational/Footer";
import UserTemplateCreationPage from "./Pages/UserTemplateCreationPage";
import AuthenticationPage from "./Pages/AuthenticationPage";
import Page404 from "./Pages/Page404";
// STYLES
import "../App.css";

export default class App extends Component {
  constructor(props) {
    super(props);
  }

  render() {
    return (
      <Router>
        <Switch>
          <Route path="/auth">
            <AuthenticationPage />
          </Route>
          <Route path="/templates">
            <UserTemplateCreationPage />
          </Route>
          <Route exact path="/">
            <HomePage />
          </Route>
          <Route path="/">
            <Page404 />
          </Route>
        </Switch>
      </Router>
    );
  }
}
