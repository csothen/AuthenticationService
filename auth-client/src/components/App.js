import React, { Component } from "react";
import { BrowserRouter as Router, Route, Switch } from "react-router-dom";

// COMPONENTS
import HomePage from "./Pages/HomePage";
import Navbar from "./Containers/Navbar";
import UserTemplateCreationPage from "./Pages/UserTemplateCreationPage";
import AuthenticationPage from "./Pages/AuthenticationPage";
import ExternalAuthPage from "./Pages/ExternalAuthPage";
import Page404 from "./Pages/Page404";
import ProfilePage from "./Pages/ProfilePage";
// STYLES
import "../App.css";

export default class App extends Component {
  constructor(props) {
    super(props);
    this.state = {
      loggedIn: false,
    };

    this.handleLogin = this.handleLogin.bind(this);
  }

  handleLogin(user) {
    localStorage.setItem("user", JSON.stringify(user));
    this.setState({ loggedIn: true });
  }

  handleLogout() {
    localStorage.removeItem("user");
  }

  render() {
    let user = JSON.parse(localStorage.getItem("user"));
    return (
      <Router>
        <Navbar user={user} logoutHandler={this.handleLogout} />
        <div className="app-page">
          <Switch>
            <Route path="/auth/external/:orgRef" component={ExternalAuthPage} />
            <Route
              exact
              path="/auth"
              render={(props) => (
                <AuthenticationPage
                  {...props}
                  loginHandler={this.handleLogin}
                />
              )}
            />
            <Route
              path="/templates"
              render={(props) => (
                <UserTemplateCreationPage {...props} user={user} />
              )}
            />
            <Route
              path="/profile"
              render={(props) => <ProfilePage {...props} user={user} />}
            />
            <Route exact path="/" component={HomePage} />
            <Route path="/" component={Page404} />
          </Switch>
        </div>
      </Router>
    );
  }
}
