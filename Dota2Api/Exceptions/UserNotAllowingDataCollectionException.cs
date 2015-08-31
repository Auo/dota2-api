using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dota2Api.Exceptions
{
    public class UserNotAllowingDataCollectionException : Exception
    {


        public UserNotAllowingDataCollectionException()
        {
        }
        public UserNotAllowingDataCollectionException(string message)
            : base(message)
        {
        }

        public UserNotAllowingDataCollectionException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}
