using System.Data.Common;

namespace Connection.DataBase
{
    public abstract class ConnectionDB<T> : IConnection
    {
        private DbConnection dbConnection;
        private DbTransaction transaction;

        public ConnectionDB(DbConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }

        public abstract T DbConnection();
        public DbTransaction Transaction { get => transaction; }

        public void OpenConnection()
        {
            dbConnection.Open();
        }

        public void CloseConnection()
        {
            dbConnection.Close();
        }

        public void BeginTransaction()
        {
            this.transaction = dbConnection.BeginTransaction();
        }
        public void Commit()
        {
            this.transaction.Commit();
        }

        public void Rollback()
        {
            this.transaction.Rollback();
        }
    }
}
