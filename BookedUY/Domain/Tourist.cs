using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Tourist
    {
        public int Id { get; set; }
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new NullInputException();
                }
                else
                {
                    _name = value.Trim();
                }
            }
        }
        private string _lastName;
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new NullInputException();
                }
                else
                {
                    _lastName = value.Trim();
                }
            }
        }
        private string _email;
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new NullInputException();
                }
                bool isEmail;
                try
                {
                    var addr = new System.Net.Mail.MailAddress(value);
                    isEmail = addr.Address == value;
                }
                catch (Exception)
                {
                    isEmail = false;
                }
                if (!isEmail)
                {
                    throw new EmailException();
                }
                else
                {
                    _email = value.Trim();
                }
            }
        }
        public List<Booking> Bookings { get; set; }
        public override bool Equals(object obj)
        {
            var result = false;
            if (obj is Tourist tourist)
            {
                result = this.Id == tourist.Id && this.Name == tourist.Name;
            }
            return result;
        }
    }
}
