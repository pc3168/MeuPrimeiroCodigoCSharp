using System.Collections.Generic;
using System.Text;

namespace Connection.DataBase
{
    namespace Properties
    {
        public class ReadProperties
        {
            private IDictionary<string, string> properties;

            public ReadProperties()
            {
                Init();
            }

            private void Init()
            {
                properties = new Dictionary<string, string>();
            }

            /// <summary>
            /// Percorrer o dicionário e concatena a chave e o valor e mais ponto e vírgula (;) ex: key=value;
            /// </summary>
            /// <returns>a concatenação de string</returns>
            public string BuildString()
            {
                StringBuilder sb = new StringBuilder();
                foreach (var item in properties)
                {
                    sb.Append(item.Key);
                    sb.Append("=");
                    sb.Append(item.Value);
                    sb.Append(";");
                }

                return sb.ToString();
            }

            /// <summary>
            /// Dicionarios de propriedades onde pode ser passado como parametros ou setar os valores.
            /// </summary>
            public IDictionary<string, string> Properties { get => properties; set => properties = value; }
        }
    }
}
