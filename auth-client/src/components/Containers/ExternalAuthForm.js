import React, { Component } from "react";

export default class ExternalAuthForm extends Component {
  constructor(props) {
    super(props);
    //orgRef é uma prop para guardar a referência da empresa
    this.state = {
      orgName: "Google",
      orgLink: "https://www.google.com",
      isLogin: true,
      loginUsername: "",
      loginPassword: "",
      template: [],
      loginElements: [],
      elements: [],
    };

    this.handleSignin = this.handleSignin.bind(this);
    this.handleSignup = this.handleSignup.bind(this);
  }

  async componentDidMount() {
    // Get template for organization and associate to state
    var response = await fetch(
      "https://localhost:5001/template/org/" + this.props.orgRef
    );
  }

  async handleSignin() {
    console.log("Sign in");
  }

  async handleSignup() {
    console.log("Sign up");
  }

  render() {
    return (
      <div>
        <h1 className="header">{this.state.orgName}</h1>
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
                className={
                  !this.state.isLogin ? "active-link" : "inactive-link"
                }
                onClick={() => this.setState({ isLogin: false })}
              >
                Sign Up
              </a>
            </div>
            {this.state.isLogin && (
              <div className="form">
                <div>{this.state.loginElements}</div>
                <div className="button-container">
                  <input
                    className="u-full-width"
                    type="submit"
                    value="Sign in"
                    onClick={this.handleSignin}
                  />
                </div>
              </div>
            )}
            {!this.state.isLogin && (
              <div className="form">
                <div>{this.state.elements}</div>
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
      </div>
    );
  }
}
