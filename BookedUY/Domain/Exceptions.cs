﻿using System;

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

    public class ImportParseException : APIException
    {
        public ImportParseException() : base("The file selected could not be parsed, please read the documentation to keep with the format.", 400)
        { }
    }

    public class NoImplementationException : APIException
    {
        public NoImplementationException() : base("There's no valid implementation in the DLL folder", 400)
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
    public class FailedReportException : APIException
    {
        public FailedReportException() : base(String.Format("The report failed because there were no bookings between the dates selected in the Touristic Spot selected."), 404)
        {
        }
    }
    
}