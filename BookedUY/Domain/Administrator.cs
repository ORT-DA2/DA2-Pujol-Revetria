using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Administrator
    {
        public int Id { get; set; }
        public string Email
        {
            get { return this.Email; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Email cannot be empty");
                }else if (value.Contains("@"))
                {
                    throw new Exception("It must be an Email");
                }
                else
                {
                    this.Email = value.Trim();
                }
            }
        }
        public string Password { get; set; }
        public List<BookingStage> Entries { get; set; }
    }
}
