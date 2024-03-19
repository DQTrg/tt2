namespace TT2.Entity
{
    public class Schedule
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public string Code { get; set; }
        public int MovieId { get; set; }
        public string Name { get; set; }
        public int RoomId { get; set; }
        public bool IsActive { get; set; }

        public List<Ticket> Tickets { get; set; }
    }
}
