1. Download repository to a local machine.
2. Create new Db named [EventsDb]. In the root directory of the project you will find 'script.sql' file. Run it in MSSQL management studio. It will create the datatables with stored procedures and data.
3. Your server name should be 'localhost' in the ~\AL.EVENTS\AL.Events.DAL\AL.Events.DAL.Connections.config config file.
4. Set WEB and WCF projects as startup.
5. Run the app.

---Optional steps---

4. Now you can create the user with admin role and db_owner(don't forget to switch to 'SQL Server and Windows Authentication mode'.
5. Add login and password to connection string in config file ~\AL.EVENTS\AL.Events.DAL\AL.Events.DAL.Connections.config
