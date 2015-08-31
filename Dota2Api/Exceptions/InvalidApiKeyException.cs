using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dota2Api.Exceptions
{
    public class InvalidApiKeyException : Exception
    {
        public InvalidApiKeyException()
        {
        }

        public InvalidApiKeyException(string message)
            : base(message)
        {
        }

        public InvalidApiKeyException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
