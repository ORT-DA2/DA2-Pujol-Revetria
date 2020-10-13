using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Administrator
    {
        public int Id { get; set; }
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
                    throw new NullInputException("Admin Email");
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
        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new NullInputException("Admin Password");
                }
                else
                {
                    _password = value.Trim();
                }
            }
        }
        public List<BookingStage> Entries { get; set; }

        public override bool Equals(object obj)
        {
            var result = false;
            if (obj is Administrator administrator)
            {
                result = this.Id == administrator.Id && this.Email == administrator.Email;
            }
            return result;
        }
    }
}
