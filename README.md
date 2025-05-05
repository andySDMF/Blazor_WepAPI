# Blazor App & WebAPI

# Setup

You will need to setup an SQLServer database.

Select the connection string from properties, open the appsettings.json under the WebAPI project and change the 'DefaultConnection'.

The solution requires a migration to add the tables into the database (or manually add them).

You can either 'RunQuery' directly on the Database to INSERT entities or run the application and add them at runtime. 

The solution should be setup to run the 2 projects simultaniously. To check this then right click on the solution and navigate to the 'Properties'. It should look like this:

<img width="584" alt="image" src="https://github.com/user-attachments/assets/c478ef9d-7f06-4284-8de6-8b489578075f" />
