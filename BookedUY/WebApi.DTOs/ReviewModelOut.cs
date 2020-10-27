using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.DTOs
{
    public class ReviewModelOut
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public int Score { get; set; }
        public string Name { get; set; }

        public ReviewModelOut(Review r)
        {
            Id = r.Id;
            Comment = r.Comment;
            Score = r.Score;
            Name = r.Booking.HeadGuest.Name + " " + r.Booking.HeadGuest.LastName;
        }

        public static List<ReviewModelOut> ReviewsToOut((double,IEnumerable<Review>) reviews)
        {
            List<ReviewModelOut> outReviews = new List<ReviewModelOut>();
            foreach (var r in reviews.Item2)
            {
                outReviews.Add(new ReviewModelOut(r));
            }
            return outReviews;
        }
    }
}
