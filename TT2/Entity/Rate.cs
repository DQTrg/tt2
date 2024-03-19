namespace TT2.Entity
{
    public class Rate
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }

        public List<Movie> Movies { get; set; }
    }
}
