import React, { useEffect, useState } from "react";
import {
  Form,
  Button,
  Navbar,
  ListGroup,
  Row,
  Col,
  Card,
} from "react-bootstrap";

import TaskModalPopUp from "./modalPopUp";
import api from "../common/axiosApi";

const TaskDashboard = () => {
  const defaultTask = {
    id: 0,
    name: "",
    priority: "None",
    dueDate: new Date(),
  };

  const [tasks, setTasks] = useState([{}]);
  const [modalShow, setModalShow] = useState(false);
  const [task, setTask] = useState(defaultTask);

  useEffect(() => {
    console.log(process.env);
    (async () => {
      const res = await api.get("tasks");
      setTasks(res.data);
    })();
  }, []);

  const handleChange = (e) => {
    setTask({ ...task, name: e.target.value });
  };

  const handleOnSave = async (e) => {
    if (task.id > 0) {
      const success = await api.put(`tasks/${task.id}`, { ...task });
      if (success.data === 1) {
        const updatedTasks = tasks.map((x) => (x.id === task.id ? task : x));
        setTasks(updatedTasks);
      }
    } else {
      const res = await api.post("tasks", { ...task });
      setTasks([res.data, ...tasks]);
    }
    setModalShow(false);
  };

  const handleOnDeleteClick = (t) => async (e) => {
    const success = await api.delete(`tasks/${t.id}`);
    if (success.data === 1) {
      const modifiedTasks = tasks.filter((x) => x.id !== t.id);
      setTasks(modifiedTasks);
    }
  };

  const handleOnDateChange = (date) => {
    setTask({ ...task, dueDate: date });
  };

  const handlePriorityChange = (e) => {
    setTask({ ...task, priority: e.target.value });
  };

  const setCardBorder = (p) => {
    if (p === "High") return "danger";
    else if (p === "Medium") return "warning";
    else return "success";
  };

  return (
    <div className="space-elements-bottom">
      <Navbar bg="dark" className="justify-content-between" variant="dark">
        <Navbar.Brand href="#home">TODO Application</Navbar.Brand>
        <Form inline>
          <Button
            variant="primary"
            onClick={(e) => {
              setTask(defaultTask);
              setModalShow(true);
            }}
          >
            Add Task
          </Button>
        </Form>
      </Navbar>
      <Form className="space-elements-bottom">
        <TaskModalPopUp
          onSave={handleOnSave}
          task={task}
          onHandleChange={handleChange}
          show={modalShow}
          onHide={() => setModalShow(false)}
          onDateChange={handleOnDateChange}
          onPriorityChange={handlePriorityChange}
        />

        <h4 style={{ marginLeft: "1rem" }}>Task List</h4>

        <ListGroup>
          {tasks.map((t, i) => (
            <ListGroup.Item key={i}>
              <Row>
                <Col md="10">
                  <Card border={setCardBorder(t.priority)}>
                    <Card.Body>
                      <Card.Title>{t.name}</Card.Title>
                      <Card.Text>
                        {t.dueDate
                          ? `Due Date: ${new Date(t.dueDate).toDateString()}`
                          : ""}
                      </Card.Text>
                      <Card.Text>{`Priority: ${t.priority}`}</Card.Text>
                    </Card.Body>
                  </Card>
                </Col>
                <Col
                  md="2"
                  className="space-elements-side align-elements-center"
                >
                  <Button
                    variant="success"
                    onClick={(e) => {
                      setTask(t);
                      setModalShow(true);
                    }}
                  >
                    Edit
                  </Button>
                  <Button variant="danger" onClick={handleOnDeleteClick(t)}>
                    Delete
                  </Button>
                </Col>
              </Row>
            </ListGroup.Item>
          ))}
        </ListGroup>
      </Form>
    </div>
  );
};

export default TaskDashboard;
