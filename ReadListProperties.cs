using System.Collections.Generic;
using System.Text;

namespace Connection.DataBase
{
    namespace Properties
    {
        public class ReadListProperties
        {
            private IDictionary<string, IDictionary<string, string>> properties;

            public ReadListProperties()
            {
                Init();
            }

            private void Init()
            {
                properties = new Dictionary<string, IDictionary<string, string>>();
            }

            /// <summary>
            /// Percorrer o dicionário e concatena a chave e o valor e mais ponto e vírgula (;) ex: key=value;
            /// valor Padrão BuildString("[database]")
            /// </summary>
            /// <returns>a concatenação de string</returns>
            public string BuildString()
            {
                return BuildString("[database]");
            }

            /// <summary>
            /// Percorrer o dicionário e concatena a chave e o valor e mais ponto e vírgula (;) ex: key=value;
            /// </summary>
            /// <param name="parameter"></param>
            /// <returns></returns>
            public string BuildString(string parameter)
            {
                StringBuilder sb = new StringBuilder();
                try
                {
                    foreach (var item in properties[parameter])
                    {
                        sb.Append(item.Key);
                        sb.Append("=");
                        sb.Append(item.Value);
                        sb.Append(";");
                    }
                }
                catch (System.Collections.Generic.KeyNotFoundException)
                {
                    throw new KeyNotFoundException("A chave fornecida não está presente no dicionário");
                }

                return sb.ToString();
            }

            /// <summary>
            /// Dicionarios de propriedades onde pode ser passado como parametros ou setar os valores.
            /// </summary>
            public IDictionary<string, IDictionary<string, string>> Properties { get => properties; set => properties = value; }
        }
    }
}
