using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TcpSupport
{
    public class CustomTcpException
    {
        public class TaskInterupptByUser : Exception
        {
            public TaskInterupptByUser():base(){}
            public TaskInterupptByUser(string message):base(message){}
            public TaskInterupptByUser(string message, Exception innerException):base(message, innerException){}
        }
    }
}