import React, { forwardRef } from "react";
import { Form, Button, Modal, FormGroup } from "react-bootstrap";
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";

const TaskModalPopUp = (props) => {
  const ref = React.createRef();

  const CustomDateInput = forwardRef(({ onClick, value }, ref) => (
    <Form.Control
      style={{ width: "267px" }}
      type="text"
      value={value}
      onChange={onClick}
      onClick={onClick}
      ref={ref}
    />
  ));
  const handleDateChange = (date) => {
    props.onDateChange(date);
  };
  return (
    <Modal size="sm" show={props.show} animation={false}>
      <Modal.Header>
        <Modal.Title>Add/Edit Task</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <Form className="space-elements-bottom">
          <FormGroup>
            <Form.Label>Name</Form.Label>
            <Form.Control
              type="text"
              placeholder="Task Name"
              value={props.task.name}
              onChange={props.onHandleChange}
            />
          </FormGroup>
          <FormGroup>
            <Form.Label>Priority</Form.Label>
            <Form.Control
              as="select"
              custom
              value={props.task.priority}
              onChange={props.onPriorityChange}
            >
              <option>None</option>
              <option>Low</option>
              <option>Medium</option>
              <option>High</option>
            </Form.Control>
          </FormGroup>

          <FormGroup>
            <Form.Label>Due Date</Form.Label>
            <DatePicker
              minDate={new Date()}
              selected={new Date(props.task.dueDate)}
              dateFormat="MMMM d, yyyy"
              onChange={(date) => handleDateChange(date)}
              customInput={<CustomDateInput ref={ref} />}
            />
          </FormGroup>
        </Form>
      </Modal.Body>
      <Modal.Footer>
        <Button variant="primary" onClick={props.onSave}>
          Save
        </Button>
        <Button variant="secondary" onClick={props.onHide}>
          Close
        </Button>
      </Modal.Footer>
    </Modal>
  );
};

export default TaskModalPopUp;
