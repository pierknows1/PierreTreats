Pierre Treats

By : Pier Rodriguez

Description
This web application uses many to many relationships by combining Flavors and Treats together  in any fashion the user chooses. It also has full CRUD capablility to alter the data however the user sees fit. It currently has authorization to the extent that the user must create an account to alter any data but outside viewers can view existing data.


Technologies Used
C#
Entity Framework Core
ASP .NET6
ASP Identity
MySQL
Html
CSS

Setup/Installation Requirements

Clone this repo to your local machine.

Connect to your SQL workbench.

To connect your database, create file appsettings.json in the PierreTreats directory. 

Fill in the file with the following code: Be sure to replace the required fields marked with [] that must contain the database name, user id, and password.

{
    "ConnectionStrings": {
        "DefaultConnection": "Server=localhost;Port=3306;database=[DB-NAME-HERE];uid=[YOUR-USERNAME-HERE];pwd=[YOUR-PASSWORD-HERE];"
    }
}

cd into PierreTreats 

$ run dotnet build 
$ run - dotnet watch run 

Known Bugs
The delete functionality only works from its own link not from inside the edit button.

License
MIT

Copyright (c) 2023 Pier Rodriguez