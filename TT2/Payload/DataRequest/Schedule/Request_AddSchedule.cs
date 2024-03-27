﻿namespace TT2.Payload.DataRequest.Schedule
{
    public class Request_AddSchedule
    {
        public double Price { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int RoomId { get; set; }
        public int MovieId { get; set; }
    }
}
