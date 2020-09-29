using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
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

    public class AlreadyExistsException : Exception
    {
        public override string Message
        {
            get
            {
                return "The object trying to be created already exists";
            }
        }
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
}