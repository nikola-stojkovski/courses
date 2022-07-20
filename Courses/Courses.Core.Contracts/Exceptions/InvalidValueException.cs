namespace Courses.Core.Contracts.Exceptions
{
    using System;
    using System.Globalization;

    public class InvalidValueException : Exception
    {
        public InvalidValueException() : base() { }

        public InvalidValueException(string message) : base(message) { }

        public InvalidValueException(string message, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
