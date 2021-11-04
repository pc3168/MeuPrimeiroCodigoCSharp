using System;
using System.Collections.Generic;
using System.Text;

namespace Connection.DataBase
{
    namespace Properties
    {
        public class ReadListPropertiesFile : ReadListProperties
        {

            private System.IO.StreamReader file;

            /// <summary>
            /// Passar o caminho de um arquivo de texto com suas propriedades de chave e valor.
            /// Encoding padrão é Encoding.UTF8
            /// ex: key=value
            /// </summary>
            /// <param name="path"></param>
            public ReadListPropertiesFile(string path) : this(path, Encoding.UTF8) { }

            /// <summary>
            /// Passar o caminho de um arquivo de texto com suas propriedades de chave e valor e usar uma codificação Encoding.UTF8 ou Encoding.GetEncoding("iso-8859-1")
            /// ex: key=value
            /// </summary>
            /// <param name="path"></param>
            /// <param name="encoding"></param>
            public ReadListPropertiesFile(string path, Encoding encoding)
            {
                file = new System.IO.StreamReader(path, encoding);
                Init();
            }

            private void Init()
            {
                ReadFile();
            }

            /// <summary>
            /// Lê o conteúdo do arquivo e separando por colchetes [] e adiciona o conteúdo em um dicionário separando por chave e valor a partir de um igual ( = )
            /// </summary>
            private void ReadFile()
            {
                String line;
                Dictionary<String, String> value = null;
                String key = null;
                while ((line = file.ReadLine()) != null)
                {
                    //retirar linhas em branco ou == ou com #
                    if (line.Length == 0 || line.Contains("==") || line.Contains("#"))
                    {
                        continue;
                    }
                    if (line.Contains("["))
                    {
                        createProperties(key, value);
                        key = line.Trim();
                        value = new Dictionary<String, String>();
                    }
                    else
                    {
                        if (value != null)
                        {
                            String[] values = line.Split('=');
                            value.Add(values[0], values[1]);
                        }
                    }

                }
                file.Close();
                createProperties(key, value);

            }


            private void createProperties(String key, Dictionary<String, String> value)
            {
                if (value != null)
                {
                    Properties.Add(key, value);
                }
            }

        }
    }
}
