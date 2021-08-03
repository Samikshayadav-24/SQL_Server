# _*SQL Server*_
In this project we are building a simple command-line application that will read values from Databade which is stored from a CSV file,do some aggregation/filtering/grouping functions and print out the results in console table format. 

## _**Table of Contents**_
 - [General Info](#General_Info)
 - [Technology](#Technology)
 - [Setup Packages](#Setup_Packages)
 - [Steps](#Steps)
 - [Important Note](#Note)

 ### _**General Info**_
This project is simple project to retrive values from database and print result in the form for table in console.

### _**Technology**_
Project is created with:
- [Visual Studio 2019](https://visualstudio.microsoft.com/downloads/)
- [Microsoft SQL Server Management Studio18](https://aka.ms/ssmsfullsetup)

### _**Setup Packages**_
To run this project you need to install the [Csvhelper(27.1.1)](https://www.nuget.org/packages/CsvHelper/) and [ConsoleTable(2.4.2)](https://www.nuget.org/packages/Consoletables/) and [System.Configuration.ConfigurationManager](https://www.nuget.org/packages/system.configuration.configurationmanager/) from Nuget packages.
##### _**Steps to install the packages**_
1. Open the Visual Studio 2019
2. Create A project.
3. Right Click on project, select Manange Nuget Packages.
4. Browse for CsvHelper and ConsoleTable and System.Configuration.ConfigurationManager select them check if they have green tick and License as MIT, click on install.
5. If The packages are installed, you can check in installed tab or you can check in project dependencies in package sections.


### _**Steps**_
1. Open Visual Studio 2019
2. Go to _**Git**_ tab,select _**Clone repository**_ .
3. Enter the git hub link [Link here] (https://github.com/Samikshayadav-24/SQL_Server) in the repository location.
4. Then at the bottom, click Clone. 
This will open the solutions explorer.
5. Download the WestBengal.csv file from (https://data.gov.in/catalog/company-master-data).
6. Then select the .sin file. It will open all the .cs files in the solutions explorer.
7. Set up the Appconfig file from the Solutions Explorer add the set the server name and create a object of conn so you dont need to create for every queries.
8. Select .cs file and run the file.


#### _**Important Note**_
Run commands for single one if done with first done make first as comment
/* ----- */ and go for the second.  .