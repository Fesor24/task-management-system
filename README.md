# Task management system
## Project set up

**1. Install .NET 7 SDK** 
Make sure you have .Net 7 Sdk installed on your computer. This project uses .NET 7.0. You can download if from the official (website)[https://dotnet.microsoft.com/en-us/download/dotnet/7.0] if you haven't already.

**2 Clone the Project**
To get the project onto your computer, open a command prompt in any folder of your choice and enter the following command

git clone https://github.com/Fesor24/task-management-system.git

Then press Enter. The project will be cloned to your system.

**3 Open the Project in your IDE**
Open the project in any Integrated Development Environment(IDE) of your choice (Visual Studio, VS Code). Follow the instructions contained in the 'Instructions.txt' file in the root directory of this project to set up your database. Click [here](https://github.com/Fesor24/task-management-system/blob/main/Instructions.txt) to access the file.

**4 Run the Project**
After successfullt setting up the database, you can run the project. When you do, your browser should open and you should be redirected to Swagger.

**5 Register an account**
At the top right corner in Swagger, you'll find a dropdown menu labeled 'Select a definition', click on it and choose 'Account endpoints' from the options. All endpoints require authorization. Register an account using the 'endpoint', if registration is successful, you will get a token in the response. Copy it to your clipboard. 

**6 Test API**
Navigate back to 'Main endpoints' from the top right corner in the swagger documentation. Click on any lock icon, when a modal appears, type the following: 'Bearer [your-token]' (without the bracket or quote). **Make sure to include a space between 'Bearer' and your token**. Click on the 'Authorize button'. This step is important as all endpoints require Authorization. Now you can test the various endpoints.
