using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.DTOs
{
    public class ReviewModelIn
    {
        public int BookingId { get; set; }
        public string Comment { get; set; }
        public int Score { get; set; }

        public Review ToReview()
        {
            Review review = new Review()
            {
                BookingId = this.BookingId,
                Comment = this.Comment,
                Score = this.Score
            };
            return review;
        }
    }
}
