﻿using System;
using System.Collections.Generic;
using System.Text;

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
    }
}