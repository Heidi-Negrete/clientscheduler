# Client Scheduler

Winforms .NET application  
_Object-Oriented Application Development with Advanced C# C969 WGU_

- Uses Entity Framework to reverse-engineer a provided database schema in order to scaffold entity type classes and a DbContext class.

## Assumptions and Notes
- Build and run project using Visual Studio 2022 as provided in the class PA Lab environment.
- If you do not wish the program to clear the database and seed fresh data on each launch, comment this line from Program.cs: ``repository.SeedTestData();``
- The username is always "test" and the password is always "test".
- IMPORTANT: To test localization, please be sure to properly set the region to Germany. Open the Control Panel, select Region, and then under Format select German (Germany).
- A customer is marked "active" if they have had any appointments in the last 6 months or scheduled in the next 6 months.
- The log file with the date-time stamps of each login can be located on the Desktop as "Login_History.txt".

## Login Form
(note, the username and password are both "test")
![Login form](./img/loginform.png)
