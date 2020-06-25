import React from "react";
import ReactDOM from "react-dom";
import { createStore } from "redux";

// STYLES
import "./index.css";

// COMPONENTS
import Root from "./components/Root";
import counter from "./redux/reducers/example";

const store = createStore(counter);

ReactDOM.render(<Root store={store} />, document.getElementById("root"));
