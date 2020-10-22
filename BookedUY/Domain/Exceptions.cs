using System;

namespace Domain
{
    public class APIException : Exception
    {
        public int StatusCode { get; set; }

        public APIException(string message, int statusCode) : base(message)
        {
            StatusCode = statusCode;
        }
    }

    public class NullInputException : APIException
    {
        public NullInputException(string entity) : base(String.Format("The {0} cannot be null", entity), 400)
        { }
    }

    public class AlreadyExistsException : APIException
    {
        public AlreadyExistsException(string entity) : base(String.Format("The {0} Already Exists", entity), 400)
        { }
    }

    public class FutureDateException : APIException
    {
        public FutureDateException(string entity) : base(String.Format("The {0} entered is in the future", entity), 400)
        { }
    }

    public class InvalidDateException : APIException
    {
        public InvalidDateException(string entity) : base(String.Format("The {0} entered is invalid", entity), 400)
        { }
    }

    public class NegativePriceException : APIException
    {
        public NegativePriceException(string entity) : base(String.Format("The {0} entered was negative", entity), 400)
        { }
    }

    public class EmailException : APIException
    {
        public EmailException(string entity) : base(String.Format("The {0} was invalid", entity), 400)
        { }
    }

    public class NegativeAmountException : APIException
    {
        public NegativeAmountException(string entity) : base(String.Format("The {0} entered was negative", entity), 400)
        { }
    }

    public class InvalidScoreException : APIException
    {
        public InvalidScoreException(string entity) : base(String.Format("The {0} entered was invalid", entity), 400)
        { }
    }

    public class InvalidImageException : APIException
    {
        public InvalidImageException(string entity) : base(String.Format("The {0} entered was negative", entity), 400)
        { }
    }

    public class NotFoundException : APIException
    {
        public NotFoundException(string entity) : base(String.Format("{0} Not Found", entity), 404)
        {
        }
    }
}