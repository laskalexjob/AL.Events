1. Download repository to a local machine.
2. In the root directory you will find script.sql file. Create new Db named [EventsDb]. Run it in MSSQL management studio. It will create the database with data.
3. Now you should create the user with admin role and db_owner(don't forget to switch to 'SQL Server and Windows Authentication mode'.
4. Add login and password to connection string in config file ~\AL.EVENTS\AL.Events.DAL\AL.Events.DAL.Connections.config
