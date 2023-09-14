# Task management system
## Project set up
Ensure you have .Net 7 Sdk installed on your machine as the target framework for this project is .Net 7.0.

Clone the project to your local machine. Open a command prompt in any directory of your choice, type 'git clone https://github.com/Fesor24/task-management-system.git'. Press Enter. Open the project in any IDE of your choice (Visual Studio, VS Code). Follow the instructions contained in the 'Instructions.txt' file in the root directory of this project to set up your database. Click [https://github.com/Fesor24/task-management-system/blob/main/Instructions.txt]here to visit the file.After you have successfully set up your database, you can run the project. When the project is run and a console pops-up, you should be redirected to swagger.

## Testing
At the top right, where you see 'Select a definition', click on the dropdown and select 'Account endpoints'. All endpoints require authorization. Register an account. Enter your credentials and send the request, you should get a 'jwt' in the response. Copy the token. Navigate back to 'Main endpoints' from the top right. Click on any lock, when the modal appears, type 'Bearer -your_token-'. **Remember to leave a space between 'Bearer' and the token you copied** which you will paste after the space. Click on 'Authorize'. You can now start testing the api
