using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

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
                    throw new NullInputException("Tourist Name");
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
                    throw new NullInputException("Tourist Last Name");
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
                    throw new NullInputException("Tourist Email");
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
                    throw new EmailException("Tourist Email");
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
        [ExcludeFromCodeCoverage]
        public override int GetHashCode()
        {
            int hashCode = 1546329232;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_lastName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(LastName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_email);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Email);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<Booking>>.Default.GetHashCode(Bookings);
            return hashCode;
        }
    }
}