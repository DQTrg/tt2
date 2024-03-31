namespace TT2.Payload.DataRequest.Promotion
{
    public class Request_AddPromotion
    {
        public int Percent { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public int RankCustomerId { get; set; }
    }
}
