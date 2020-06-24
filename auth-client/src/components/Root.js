import React, { Component } from "react";
import { BrowserRouter as Router, Route, Switch } from "react-router-dom";
import { Provider } from "react-redux";

import App from "./App";

export default class Root extends Component {
  constructor(props) {
    super(props);
  }

  render() {
    return (
      <Provider store={this.props.store}>
        <Router>
          <Switch>
            <Route path="/" component={App} />
          </Switch>
        </Router>
      </Provider>
    );
  }
}
