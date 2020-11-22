using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics.CodeAnalysis;

namespace Domain
{
    public class Review
    {
        public int Id { get; set; }
        public Booking Booking { get; set; }
        public int BookingId { get; set; }
        public int Score
        {
            get { return _score; }
            set
            {
                if (value < 1 || value > 5)
                {
                    throw new InvalidScoreException("Review Score");
                }
                else
                {
                    _score = value;
                }
            }
        }
        private int _score;
        public string Comment
        {
            get { return _comment; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new NullInputException("Review Comment");
                }
                else
                {
                    _comment = value.Trim();
                }
            }
        }
        private string _comment;

        public override bool Equals(object obj)
        {
            return obj is Review review &&
                   Id == review.Id;
        }
        [ExcludeFromCodeCoverage]
        public override int GetHashCode()
        {
            int hashCode = 1444669335;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Booking>.Default.GetHashCode(Booking);
            hashCode = hashCode * -1521134295 + BookingId.GetHashCode();
            hashCode = hashCode * -1521134295 + Score.GetHashCode();
            hashCode = hashCode * -1521134295 + _score.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Comment);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(_comment);
            return hashCode;
        }
    }
}
