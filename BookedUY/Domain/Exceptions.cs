using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Domain
{
    public class APIException : Exception
    {
        public int StatusCode { get; set; }

        public APIException(string message, int statusCode) :base(message)
        {
            StatusCode = statusCode;
        }
    }
    public class NullInputException : Exception
    {
        public override string Message
        {
            get
            {
                return "The input received was empty";
            }
        }
    }

    public class AlreadyExistsException : APIException
    {
        public AlreadyExistsException(string entity) : base(String.Format("The {0} Already Exists", entity),409)
        { }
    }

    public class FutureDateException : Exception
    {
        public override string Message
        {
            get
            {
                return "The date entered is in the future";
            }
        }
    }

    public class InvalidDateException : Exception
    {
        public override string Message
        {
            get
            {
                return "The date entered is invalid";
            }
        }
    }

    public class NegativePriceException : Exception
    {
        public override string Message
        {
            get
            {
                return "The price entered is negative";
            }
        }
    }

    public class EmailException : Exception
    {
        public override string Message
        {
            get
            {
                return "The input is not an Email";
            }
        }
    }

    public class NegativeAmountException : Exception
    {
        public override string Message
        {
            get
            {
                return "The amount entered is negative";
            }
        }
    }

    public class InvalidImageException : Exception
    {
        public override string Message
        {
            get
            {
                return "Invalid Image";
            }
        }
    }

    public class NotFoundException : APIException
    {
        public NotFoundException(string entity) : base(String.Format("{0} Not Found",entity),404) { }
    }
}