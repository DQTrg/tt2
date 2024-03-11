﻿namespace TT2.Entity
{
    public class Room
    {
        public int Id { get; set; }
        public int Capacity { get; set; }
        public int Type { get; set; }
        public string Description { get; set; }
        public int CinemaId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public List<Schedule> Schedules { get; set; }
        public List<Seat> Seats { get; set; }
    }
}
