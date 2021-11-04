namespace Connection.DataBase
{
    public interface IConnection
    {

        void OpenConnection();

        void CloseConnection();

        void BeginTransaction();

        void Commit();

        void Rollback();

    }
}
