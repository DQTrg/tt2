using Microsoft.Identity.Client;

namespace TT2.Entity
{
    public class Seat
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int SeatStatusId { get; set; }
        public string Line {  get; set; }
        public int RoomId { get; set; }
        public bool? IsActive { get; set; }
        public int SeatTypeId { get; set; }
        public int TicketId { get; set; }

    }
}
