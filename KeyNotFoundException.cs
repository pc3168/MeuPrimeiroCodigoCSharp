using System;

namespace Connection.DataBase
{
    namespace CustomException
    {
        public class KeyNotFoundException : Exception
        {
            public KeyNotFoundException(string message) { }
        }
    }
    
}
