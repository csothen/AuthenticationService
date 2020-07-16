import React, { Component } from "react";
import { Redirect } from "react-router-dom";

import { login, register } from "../../services/AuthService";
import { alertSuccess, alertError } from "../../services/AlertService";

export default class AuthenticationForm extends Component {
  constructor(props) {
    super(props);
    this.state = {
      isLogin: true,
      loggedIn: false,
      loginEmail: "",
      loginPassword: "",
      registerOrgName: "",
      registerEmail: "",
      registerPassword: "",
      registerConfirmPassword: "",
    };

    this.handleChange = this.handleChange.bind(this);
    this.handleSignin = this.handleSignin.bind(this);
    this.handleSignup = this.handleSignup.bind(this);
  }

  handleChange(event) {
    this.setState({ [event.target.name]: event.target.value });
  }

  async handleSignin(event) {
    event.preventDefault();

    await login(this.state.loginEmail, this.state.loginPassword)
      .then((response) => {
        this.props.login(response.data);
        alertSuccess("Signed In", "You logged in successfully").then(() => {
          this.setState({ loggedIn: true });
          window.location.reload();
        });
      })
      .catch((error) => {
        let status = error.response.status;
        if (status === 500) {
          alertError("Unknown error", "Please try again later").then(() => {
            this.setState({ loginPassword: "" });
          });
        } else {
          alertError(
            "Unauthorized",
            "The credentials you inserted were incorrect"
          ).then(() => {
            this.setState({ loginPassword: "" });
          });
        }
      });
  }

  async handleSignup(event) {
    event.preventDefault();

    if (this.state.registerPassword === this.state.registerConfirmPassword) {
      let response = await register(
        this.state.registerEmail,
        this.state.registerOrgName,
        this.state.registerPassword
      );
      if (response.status === 200) {
        this.props.login(response.data);
        alertSuccess("Signed Up", "Welcome to the platform").then(() => {
          this.setState({ loggedIn: true });
        });
      } else if (response.status === 500) {
        alertError("Unknown error", "Please try again later").then(() => {
          this.setState({ registerPassword: "", registerConfirmPassword: "" });
        });
      } else {
        alertError("Taken", "The email inserted is already being used").then(
          () => {
            this.setState({
              registerPassword: "",
              registerConfirmPassword: "",
            });
          }
        );
      }
    } else {
      console.log("Não são iguais");
    }
  }

  render() {
    return (
      <form className="auth-form">
        {this.state.loggedIn && <Redirect to="/" />}
        <div className="form-data-container">
          <div className="form-links">
            <a
              className={this.state.isLogin ? "active-link" : "inactive-link"}
              onClick={() => this.setState({ isLogin: true })}
            >
              Sign In
            </a>
            <a
              className={!this.state.isLogin ? "active-link" : "inactive-link"}
              onClick={() => this.setState({ isLogin: false })}
            >
              Sign Up
            </a>
          </div>
          {this.state.isLogin && (
            <div className="form">
              <div>
                <div>
                  <label>Email</label>
                  <input
                    className="u-full-width"
                    type="email"
                    name="loginEmail"
                    value={this.state.loginEmail}
                    onChange={this.handleChange}
                    placeholder=""
                    id="loginEmail"
                  />
                </div>
                <div>
                  <label>Password</label>
                  <input
                    className="u-full-width"
                    type="password"
                    name="loginPassword"
                    value={this.state.loginPassword}
                    onChange={this.handleChange}
                    placeholder=""
                    id="loginPassword"
                  />
                </div>
              </div>
              <div className="button-container">
                <input
                  className="u-full-width"
                  type="submit"
                  onClick={this.handleSignin}
                  value="Sign in"
                />
              </div>
              <div className="forgot-password">
                <a href="/auth/reset/password">Forgot your password?</a>
              </div>
            </div>
          )}
          {!this.state.isLogin && (
            <div className="form">
              <div>
                <label>Organization Name</label>
                <input
                  className="u-full-width"
                  type="text"
                  name="registerOrgName"
                  value={this.state.registerOrgName}
                  onChange={this.handleChange}
                  placeholder=""
                  id="registerOrgName"
                />
              </div>
              <div>
                <label>Email</label>
                <input
                  className="u-full-width"
                  type="email"
                  name="registerEmail"
                  value={this.state.registerEmail}
                  onChange={this.handleChange}
                  placeholder=""
                  id="registerEmail"
                />
              </div>
              <div>
                <label>Password</label>
                <input
                  className="u-full-width"
                  type="password"
                  name="registerPassword"
                  value={this.state.registerPassword}
                  onChange={this.handleChange}
                  placeholder=""
                  id="registerPassword"
                />
              </div>
              <div>
                <label>Confirm Password</label>
                <input
                  className="u-full-width"
                  type="password"
                  name="registerConfirmPassword"
                  value={this.state.registerConfirmPassword}
                  onChange={this.handleChange}
                  placeholder=""
                  id="registerConfirmPassword"
                />
              </div>
              <div className="button-container">
                <input
                  className="u-full-width"
                  type="submit"
                  value="Sign up"
                  onClick={this.handleSignup}
                />
              </div>
            </div>
          )}
        </div>
      </form>
    );
  }
}
