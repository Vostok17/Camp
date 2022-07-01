using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7.Exceptions
{
    internal class InvalidHeaderException : Exception
    {
        public string? FilePath { get; private set; }

        public InvalidHeaderException() : this(null, null) { }
        public InvalidHeaderException(string? message) : this(message, null) { }
        public InvalidHeaderException(string? message, string? filePath) : base(message)
        {
            FilePath = filePath;
        }
    }
}
