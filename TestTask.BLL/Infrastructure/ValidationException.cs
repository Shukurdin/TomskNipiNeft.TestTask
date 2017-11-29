using System;

namespace TestTask.BLL.Infrastructure
{
    public class ValidationException : Exception
    {
        public string PropertyName { get; protected set; }

        public ValidationException(string message, string propertyName)
            : base(message)
        {
            PropertyName = propertyName;
        }
    }
}