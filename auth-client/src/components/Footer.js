import React, { Component } from "react";

export default class Footer extends Component {
  constructor(props) {
    super(props);
  }
  render() {
    return <footer className="AppFooter">{this.props.children}</footer>;
  }
}
