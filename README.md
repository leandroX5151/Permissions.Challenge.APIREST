# Permissions.Challenge.APIREST
API Rest - .Net Core 3.1 Project

# Initial installation in database
In MS SQL Server, create the database "TestDb" or open the database to work.
Open Managment Studio and log in with administrator permissions and run the following scripts (located inside the "Permissions.Challenge.Data \ Scripts" folder)::
1 - "Script-Initial-Tables.sql"
2 - "Script-Initial-Inserts.sql"

# Config file for DataBase connection
In the configuration file (for development environment, "appsettings.Development.json" - located inside the "Permissions.Challenge.Api" folder-), open it for editing and configure in the "DefaultConnection" string:
1 - The Database server (DATABASE_SERVER)
2 - The database name (DATABASE_NAME)
3 - The data user access, user (USER_NAME) and password (PASSWORD)
