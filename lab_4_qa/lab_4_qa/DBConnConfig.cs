using IIG.CoSFE.DatabaseUtils;

namespace integrationTests.SqlConn
{
    class DBConnConfig
    {
        public static FlagpoleDatabaseUtils GetDBConnection()
        {
            //sql connect str args
            string Server = @"STRIX\SQLEXPRESS";
            string Database = @"IIG.CoSWE.FlagpoleDB";
            bool IsTrusted = true;
            string Login = @"coswe";
            string Password = @"L}EjpfCgru9X@GLj";
            int ConnectionTimeout = 75;
            FlagpoleDatabaseUtils _databaseConnection = new FlagpoleDatabaseUtils(Server, Database, IsTrusted, Login, Password, ConnectionTimeout);

            return _databaseConnection;
        }
    }
}

