namespace Courses.Core.Contracts.Exceptions
{
    using System;
    using System.Collections.Generic;
    using FluentValidation.Results;

    public class ValidationException : Exception
    {
        public List<string> Errors { get; }

        public ValidationException() : base(ErrorMessages.VALIDATION_ERROR)
        {
            Errors = new List<string>();
        }

        public ValidationException(IEnumerable<ValidationFailure> failures)
            : this()
        {
            foreach (var failure in failures)
            {
                Errors.Add(failure.ErrorMessage);
            }
        }
    }
}
