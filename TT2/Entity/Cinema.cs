﻿namespace TT2.Entity
{
    public class Cinema
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public string NameOfCinema { get; set; }
        public bool IsActive { get; set; }

        public List<Room> Rooms { get; set; }
    }
}
