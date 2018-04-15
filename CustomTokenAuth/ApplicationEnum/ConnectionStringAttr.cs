using System;

namespace CustomTokenAuth.ApplicationEnum
{
    public class ConnectionStringAttr : Attribute
    {
        public ConnectionStringAttr(ApplicationDatabase app)
        {
            switch (app)
            {
                case ApplicationDatabase.DbTest:
                ConnectionString = "Server=(localdb)\\MSSQLLocalDB;Database=testDB;Trusted_connection=true;MultipleActiveResultSets=true";
                break;
                case ApplicationDatabase.DbRelease:
                ConnectionString = "";
                break;
                case ApplicationDatabase.DbExternal:
                ConnectionString = "";
                break;
                default:
                ConnectionString = "";
                break;

            }
        }
        public string ConnectionString { get; private set; }
    }


    public enum ApplicationDatabase
    {
        DbTest,DbRelease,DbExternal
    }
}