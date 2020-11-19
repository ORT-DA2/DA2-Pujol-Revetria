using System;
using System.Collections.Generic;

namespace Domain
{
    public class Administrator
    {
        public int Id { get; set; }
        private string _email;
        
        private void CheckEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new NullInputException("Admin Email");
            }
            bool isEmail;
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                isEmail = addr.Address == email;
            }
            catch (Exception)
            {
                isEmail = false;
            }
            if (!isEmail)
            {
                throw new EmailException("Admin Email");
            }
        }
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                CheckEmail(value);
                _email = value.Trim();
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

        public override int GetHashCode()
        {
            int hashCode = -569678601;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_email);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Email);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_password);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Password);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<BookingStage>>.Default.GetHashCode(Entries);
            return hashCode;
        }
    }
}