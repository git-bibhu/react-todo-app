import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import TaskDashboard from "./components/task/taskDashboard";
import "./App.scss";

function App() {
  return (
    <Router>
      <div className="root-container">
        <div className="main-content">
          <Switch>
            <Route path="/" exact component={TaskDashboard} />
          </Switch>
        </div>
      </div>
    </Router>
  );
}

export default App;
