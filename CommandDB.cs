using System.Data;
using System.Data.Common;

namespace Connection.DataBase
{
    public class CommandDB
    {
        private DbCommand command;
        private IDataReader dataReader;
        private IConnection connection;
        private DataTable dataTable;


        public CommandDB(IConnection connection)
        {
            this.connection = connection;
        }

        public CommandDB(IConnection connection, DbCommand command) : this(connection)
        {
            this.command = command;
        }

        /// <summary>
        /// Método já está sendo executando dentro de uma conexão
        /// Retorna um DataTable passando a classe de comando.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public DataTable DataTable(DbCommand command)
        {

            connection.OpenConnection();
            dataReader = command.ExecuteReader();
            dataTable = new DataTable();
            dataTable.Load(dataReader);
            connection.CloseConnection();
            return dataTable;
        }

        /// <summary>
        /// Método já está sendo executando dentro de uma conexão
        /// Retorna um DataTable passando a classe de comando no construtor.
        /// </summary>
        /// <returns></returns>
        public DataTable DataTable()
        {
            return DataTable(this.command);
        }

        /// <summary>
        /// Método já está sendo executando dentro de uma conexão
        /// Executa uma ação passando como parâmetro um comando.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(DbCommand command)
        {
            this.connection.OpenConnection();
            int value = command.ExecuteNonQuery();
            this.connection.CloseConnection();
            return value;
        }

        /// <summary>
        /// Método já está sendo executando dentro de uma conexão
        /// Executa uma ação passando como parâmetro um comando.
        /// </summary>
        /// <returns></returns>
        public int ExecuteNonQuery()
        {
            return ExecuteNonQuery(this.command);
        }

        /// <summary>
        /// Método já está sendo executando dentro de uma conexão
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public object ExecuteScalar(DbCommand command)
        {
            this.connection.OpenConnection();
            object value = command.ExecuteScalar();
            this.connection.CloseConnection();
            return value;
        }

        /// <summary>
        /// Método já está sendo executando dentro de uma conexão
        /// </summary>
        /// <returns></returns>
        public object ExecuteScalar()
        {
            return ExecuteScalar(this.command);
        }
    }
}
