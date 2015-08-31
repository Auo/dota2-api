using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dota2Api.Exceptions
{
    public class ServiceUnavailableException : Exception
    {
        public ServiceUnavailableException()
            : base()
        {
        }
        public ServiceUnavailableException(string message)
            : base(message)
        {
        }
        public ServiceUnavailableException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
