import React, { Component } from "react";

export default class AuthenticationForm extends Component {
  constructor(props) {
    super(props);
    this.state = {
      isLogin: true,
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
    this.validateRequest = this.validateRequest.bind(this);
  }

  validateRequest(request) {
    for (var el in request) {
      if (request[el] === "") {
        return false;
      }
    }
    return true;
  }

  handleChange(event) {
    this.setState({ [event.target.name]: event.target.value });
  }

  handleSignin(event) {
    event.preventDefault();

    const requestBody = {
      email: this.state.loginEmail,
      password: this.state.loginPassword,
    };

    const valid = this.validateRequest(requestBody);

    if (valid) {
      console.log(requestBody);
    } else {
      console.log("Inválido");
    }
  }

  handleSignup(event) {
    event.preventDefault();

    if (this.state.registerPassword === this.state.registerConfirmPassword) {
      const requestBody = {
        email: this.state.registerEmail,
        orgName: this.state.registerOrgName,
        password: this.state.registerPassword,
      };

      const valid = this.validateRequest(requestBody);

      if (valid) {
        console.log(requestBody);
      } else {
        console.log("Inválido");
      }
    } else {
      console.log("Não são iguais");
    }
  }

  render() {
    return (
      <form className="auth-form">
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
            <div className="signin-form">
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
            <div className="signup-form">
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
