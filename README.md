# About The Project 💭

This is a Quick Assessment Implemented using Clean Architecture and CQRS, created for Assessment Purposes.


## Table of Contents

[Getting Started](#getting-started)
 * [Using the GitHub Repository](#using-the-github-repository)
 * [Running Migrations](#running-migrations)
 * [Running The Application](#running-the-application)

# Getting Started

## Using the GitHub Repository
 
 To get started based on this repository, you need to get a copy locally. You have three options: fork, clone, or download. Most of the time, you probably just want to download.

You should **download the repository**, unblock the zip file, and extract it to a new folder if you just want to play with the project or you wish to use it as the starting point for an application.


## Running Migrations

In Visual Studio : 
* Set the `BH.Assessment.Api` as startup Project,
* Open the Package Manager Console
* In the Default Project select `BH.Assessment.Persistence`.
* Run `update-database` command to generate the sqlite database for you according to the migrations files.
* Just hit `F5` and will see the swagger UI appear to you 


To use SqlServer, change `options.UseSqlite(connectionString));` to `options.UseSqlServer(connectionString));` in the `BH.Assessment.Persistence.PersistenceServicesRegistration.cs` file.

## Running The Application

- Just hit `F5` and will see the swagger UI appear to you

 - You can Find `Postman Related Json Files` in `BH.Assessment.Api/Postman-related` folder and you can import it to `Postman` and play with the APIs
