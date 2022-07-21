namespace Courses.Core.Contracts
{
    public static class ErrorMessages
    {
        public static string VALIDATION_ERROR = "One or more validation failures have occurred.";

        public static string INVALID_PARTICIPANT_EMAIL_VALUE = "Emails are not valid.";

        #region Courses
        public const string INVALID_COURSE_DATES = "Course dates are not valid.";

        public const string COURSE_NOT_FOUND = "Course not found.";
        #endregion
    }
}
