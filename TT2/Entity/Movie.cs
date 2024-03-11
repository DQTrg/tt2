namespace TT2.Entity
{
    public class Movie
    {
        public int Id { get; set; }
        public int MovieDuration { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime PremierDate { get; set; }
        public string Description { get; set; }
        public string Director { get; set; }
        public string Image {  get; set; }
        public string HeroImage { get; set; }
        public int MovieTypeId { get; set; }
        public string Name { get; set; }
        public int RateId { get; set; }
        public string Trailer {  get; set; }
        public bool IsActive { get; set; }

        public List<Schedule> Schedules { get; set; }
    }
}
