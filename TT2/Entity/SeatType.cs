﻿namespace TT2.Entity
{
    public class SeatType
    {
        public int Id { get; set; }
        public string NameType { get; set; }

        public List<Seat> Seats { get; set; }
    }
}
