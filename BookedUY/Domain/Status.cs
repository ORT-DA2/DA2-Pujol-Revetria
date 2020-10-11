using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public enum Status
    {
        Created, PaymentPending, Accepted, Rejected, Expired
    }

    public class StatusMethods
    {
        public static Status StringToStatus(string str)
        {
            foreach (Status status in (Status[])Enum.GetValues(typeof(Status)))
            {
                if (status.ToString().Equals(str))
                {
                    return status;
                }
            }
            throw new NotFoundException("Status");
        }
    }
}
