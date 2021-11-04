using System.Data.SqlClient;

namespace Connection.DataBase
{
    public class ConnectionSql : ConnectionDB<SqlConnection>
    {
        private static SqlConnection dbConnection;

        public ConnectionSql(string stringConnection) : base(dbConnection = new SqlConnection(stringConnection)) { }

        public override SqlConnection DbConnection()
        {
            return dbConnection;
        }
    }

}