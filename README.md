# _Animal Shelter API_

#### By _**Ella Tanttu**_

#### _A simple API to track shelter pets_

## Technologies Used

* _C#_
* _.Net5_
* _ASP.Net Core MVC_
* _ASP.Net Identity_
* _Razor View Engine_
* _CSS_
* _Markdown_
* _SQL_
* _MySQL_
* _EntityFrameworkCore_

## Description

Application that allows user to keep track of the pets in a shelter. User can:
- View all pets
- View individual pet
- Add pet
- Remove Pet
- Update pet information

NOTE TO GRADER: Further exploration was taken out and isn't mentioned in README because it was conflicting with successful API calls.

## Setup/Installation Requirements

### **Package Installations:**
1. _Download .NET 5 [here](https://dotnet.microsoft.com/en-us/download/dotnet/5.0)_
2. _You can find the Shelter.Solution github repository [here](https://github.com/ellajtanttu/Shelter.Solution)_
3. _Click the green code button, and copy the https link_
4. _In your preferred git terminal navigate to the directory you would like to store the project_
5. _Enter: "git clone" followed by the copied https link_
6. _Now that the repository is cloned to your computer, right click on the folder and click open with vs code_
7. _Once in the project, navigate to the `Shelter` directory within the terminal_
8. _Add the following packages in terminal:_
   - `dotnet add package Microsoft.EntityFrameworkCore -v 5.0.0`
   - `dotnet add package Pomelo.EntityFrameworkCore.MySql -v 5.0.0-alpha.2`
   - `dotnet add package Microsoft.EntityFrameworkCore.Proxies -v 5.0.0`
   - `dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore -v 5.0.0`
   - `dotnet tool install --global dotnet-ef --version 3.0.0`

### **Database Setup & Running the Application:**
1. _In terminal, navigate to the `Shelter` directory_
2. _Type `dotnet restore` to install dependencies_
3. _Type `dotnet build` to build project_
4. _In order to initalize a database you will need to create an appsettings.json file that looks like this*_
```
{
  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database={YOUR DATABASE NAME HERE};uid={YOUR USER ID HERE};pwd={YOUR PASSWORD HERE};"
  }
}
```
   _*NOTE: change {YOUR X} with corresponding information_

5. _Once you have the appsettings.json file— to create a database, type: `dotnet ef migrations add initial`_
6. _To update the database in MySQL type: `dotnet ef database update`_
7. _Initialize localhost:3306 in MySQL Workbench (download [here](https://dev.mysql.com/downloads/workbench/))_
8. _At this point you will now be able to access endpoints by typing `dotnet run` in the terminal_

### **Accessing Enpoints Using Postman**
1. To download Postman on your personal machine, go to the [Postman downloads page](https://www.postman.com/downloads/)
2. Install and open Postman
**(For the following instructions, make sure your database is up to date and the API is running, see previous steps)**
* To view a list of all pets: send a GET request at the URL: `http://localhost:5000/api/Pets`
* To view a single pet: send a Get request at the URL: `http://localhost:5000/api/Pets/1` (note: the last number is the id of the pet record you would like to see)
* To create a new pet record, send a POST request to the following URL: `http://localhost:5000/api/Pets`
    1. Click on the Body tab, select Raw, and in the dropdown menu select JSON.
    2. Create your animal using the following format:
```
{
    "type":"Cat",
    "name":"Harold Dunphy",
    "breed":"Domestic Shorthair",
    "age":8,
    "gender":"Male",
    "color":"brown",
    "intact":true
}
```
* To edit a pet record, send a POST request to the following URL: `http://localhost:5000/api/Pets/1` (note: the last number is the id of the pet record you would like to change) Follow the same steps as listed above for creating a new record. Be sure to include all of the properties and just leave the ones that aren't changing the same.

## Known Bugs

No known issues

## License

_MIT Copyright (c) 2021 Ella Tanttu_
_https://opensource.org/licenses/MIT_

## Contact Information

_Ella Tanttu ellajtanttu@gmail.com_