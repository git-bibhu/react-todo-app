# TODO Application UI

>**Pre-Requisites:**
  API should be running on the port mentioned in the .env file

## Environment File
Update the API base endpoint in the .env file
REACT_APP_API=https://host:port/api/

## Available Scripts

Navigate to project directory, then run the below to start the application  

> `yarn start`
or
 `npm start`

Runs the app in the development mode.

Open [http://localhost:3000](http://localhost:3000) to view it in the browser. 

The page will reload if you make edits. 

> `yarn build`
or
 `npm build`

Builds the app for production to the `build` folder.

It correctly bundles React in production mode and optimizes the build for the best performance.

The build is minified and the filenames include the hashes.

## Functional Description:

 - Default landing page is Dashboard page which shows all the available
   tasks and their respective information such as name, due date,
   priority.
   https://ibb.co/5j2g6Jv
   
  - Add Task button on Toolbar will open a popup which will add a new
   task with respective information.
   
   - Edit Task button on each task record will open the popup with pre
   filled task details which is editable and user can save it.
   
   - Delete Task button on each task record will hard delete the task from
   database.
   https://ibb.co/qRLTqtR

>**Out of Scope:
UI validation logic.
Unit Test.
Authentication.**