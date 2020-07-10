import React, { Component } from "react";
import { BrowserRouter as Router, Route, Switch, Link } from "react-router-dom";

// COMPONENTS
import HomePage from "./Pages/HomePage";
import Navbar from "./Presentational/Navbar";
import Footer from "./Presentational/Footer";
import UserTemplateCreationPage from "./Pages/UserTemplateCreationPage";
import AuthenticationPage from "./Pages/AuthenticationPage";
import ExternalAuthPage from "./Pages/ExternalAuthPage";
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
        <div className="app-page">
          <Switch>
            <Route path="/external/auth/:orgRef" component={ExternalAuthPage} />
            <Route exact path="/auth" component={AuthenticationPage} />
            <Route path="/templates" component={UserTemplateCreationPage} />
            <Route exact path="/" component={HomePage} />
            <Route path="/" component={Page404} />
          </Switch>
        </div>
      </Router>
    );
  }
}
