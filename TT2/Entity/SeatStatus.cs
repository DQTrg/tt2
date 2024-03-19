namespace TT2.Entity
{
    public class SeatStatus
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string NameStatus { get; set; }

        public List<Seat> Seats { get; set; }
    }
}
