# ConexaoBancoDeDados

Projeto iniciado para ajudar o Sávio colega de trabalho a realizar conexões de vários bancos de dados só criar uma classe herdando da classe ConnectionDB<T> passando o tipo da classe do banco e também realizar a leitura de um arquivo estruturado com chave e valor.

## C#
  Foi um projeto para aprender a todos os recursos de orientação a objeto.
  
  No projeto foi utilizado Herança , polimorfismo , interface, sobrescrita de construtores 
  classe abstrata , sobre carga de métodos.
  
  
## arquivo para stringConnection

  #### properties
  ``` 
    Data Source=ip,port
    Initial Catalog=bancodedados
    User ID=usuario
    Password=senha
  ```
  
  ## Outras string de conexão
  ### postgres
  "Provider = PostgreSQL OLE DB Provider; Data Source = myServerAddress; location = myDataBase; User ID = myUsername; password = myPassword";
  ### Mysql
  "Server=myServerAddress;Database=myDataBase;Uid=myUsername;Pwd=myPassword";
  ### SqlServer
  "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\NORTHWND.MDF;Integrated Security=True; Connect Timeout=30;User Instance=True";
  
  **Data Source=ip,port;Initial Catalog=bancodedados;User ID=usuario;Password=senha;";**

## Conexão com o banco de dados Mysql criação da classe 
```c#
  public class ConnectionMysql : ConnectionDB<MySqlConnection>
    {
        private static MySqlConnection dbConnection;

        public ConnectionMysql(string stringConnection) : base(dbConnection)
        {
            dbConnection = new MySqlConnection(stringConnection);
        }

        public override MySqlConnection DbConnection()
        {
            return dbConnection;
        }
    }
```
## Como utilizar o código
  ```c#
    static void Main(string[] args)
   {

      ReadPropertiesFile rfp = new ReadPropertiesFile("properties");
      Console.WriteLine(rfp.BuildString());

      // Caso for usar Mysql 
      // ConnectionMysql con = new ConnectionMysql(rfp.BuildString());
      // MysqlCommand command = new MysqlCommand();
            
      //caso for usar SqlServer
      ConnectionSql con = new ConnectionSql(rfp.BuildString());
      SqlCommand command = new SqlCommand();
            
      command.Connection = con.DbConnection();
      command.CommandText = "select * from tabela";

      CommandDB cmd = new CommandDB(con, command);

      DataTable dt = cmd.DataTable();

      Console.Write(dt.Rows[0]["Coluna1"] + " - ");
      Console.Write(dt.Rows[0]["Coluna2"]);
      Console.WriteLine("");
      Console.Write(dt.Rows[1]["Coluna1"] + " - ");
      Console.Write(dt.Rows[1]["Coluna2"]);

    }
  ```
  ## Arquivo properties
  ```file
    [database]
    #isso é um comentário... linha em branco é ignorado
    Data Source=ip,port
    Initial Catalog=bancodedados
    User ID=usuario
    Password=senha
    
    [atualizacao]
    Endereco=http://dominium.algumlugar\atualizador
    
    [outros parametros]
    nome=joaquim
    Loja Default=100
    
  ```
  
  ## Como utilizar o código ReadListPropertiesFile
  ```c#
      public static void Main(String[] args)
      {

            ReadListPropertiesFile file = null;
            try
            {
                file = new ReadListPropertiesFile("properties");
                /// valor Padrão BuildString("[database]")
                Console.WriteLine(file.BuildString());
                Console.WriteLine("------------");
                foreach (var item in file.Properties["[database]"])
                {
                    Console.WriteLine("chave {0} e valor {1}",item.Key , item.Value);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
            Console.ReadKey();
        }

    }
  ```
  
## Autor
  Paulo César