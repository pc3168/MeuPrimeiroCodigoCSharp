using System;
using System.Text;

namespace Connection.DataBase
{
    namespace Properties
    {
        public class ReadPropertiesFile : ReadProperties
        {

            private System.IO.StreamReader file;

            /// <summary>
            /// Passar o caminho de um arquivo de texto com suas propriedades de chave e valor.
            /// Encoding padrão é Encoding.UTF8
            /// ex: key=value
            /// </summary>
            /// <param name="path"></param>
            public ReadPropertiesFile(string path) : this(path, Encoding.UTF8) { }

            /// <summary>
            /// Passar o caminho de um arquivo de texto com suas propriedades de chave e valor e usar uma codificação Encoding.UTF8 ou Encoding.GetEncoding("iso-8859-1")
            /// ex: key=value
            /// </summary>
            /// <param name="path"></param>
            /// <param name="encoding"></param>
            public ReadPropertiesFile(string path, Encoding encoding)
            {
                file = new System.IO.StreamReader(path, encoding);
                Init();
            }

            private void Init()
            {
                ReadFile();
            }

            /// <summary>
            /// Lê o conteúdo do arquivo e adiciona em um dicionário separando por chave e valor a partir de um igual ( = )
            /// </summary>
            private void ReadFile()
            {
                String line;
                while ((line = file.ReadLine()) != null)
                {
                    String[] values = line.Split('=');
                    Properties.Add(values[0], values[1]);
                }
                file.Close();
            }


        }
    }
}
