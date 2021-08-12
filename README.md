# Portal
> A .NET Core MVC portal using a PostgreSQL database, Bootstrap, and Razor Pages.

## Features

* A homepage with apps (links) to frequently used sites and resources
* Easily create, and manage apps using the app management screen
* A fast and intuitive search (easily search for apps, people, and more)
* Create roles and assign users to roles
* Restrict access to site areas using [role-based authorization](https://docs.microsoft.com/en-us/aspnet/core/security/authorization/roles?view=aspnetcore-5.0)
* Mobile friendly, responsive design

![Home.png](./Screenshots/home.png?raw=true "Home Page")


## Requirements
* [.NET 5.0](https://dotnet.microsoft.com/download/dotnet/5.0)
* [PostgreSQL](https://www.postgresql.org/download/)
* [pgAdmin](https://www.pgadmin.org/download/) (optional)

## Install
* Import the database from the /Database folder
* Modify the database connection string in appsettings.json

## Configure
* Specify a username and password for an admin account in /Portal/Seeds/DefaultUsers.cs
* Login using the admin account
* Create applications and users using the admin screen
* Restrict access to site areas by modifying [authorize attributes](https://docs.microsoft.com/en-us/aspnet/core/security/authorization/simple?view=aspnetcore-5.0) for site controllers under /Portal/Controllers/

## Customize
* Modify the site colour scheme and appearance in /Portal/wwwroot/css/site.css
* Modify the site template in Portal/Views/Shared/_Layout.cshtm

## License
[![License](http://img.shields.io/:license-mit-blue.svg?style=flat-square)](http://badges.mit-license.org)

- **[MIT license](http://opensource.org/licenses/mit-license.php)**
