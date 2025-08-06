using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GithubApiDLL
{
    class InvalidGithubTokenException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidGithubTokenException"/> class with a specified error message.
        /// </summary>
        /// <param name="_message">The error message that explains the reason for the exception.</param>
        public InvalidGithubTokenException(string _message) : base(_message)
        {

        }
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidGithubTokenException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="_message">The error message that explains the reason for the exception.</param>
        /// <param name="_innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public InvalidGithubTokenException(string _message, Exception _innerException) : base(_message, _innerException)
        {
        }
    }
}
