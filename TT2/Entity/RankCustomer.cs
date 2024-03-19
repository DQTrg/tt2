namespace TT2.Entity
{
    public class RankCustomer
    {
        public int Id { get; set; }
        public int Point { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public List<User> Users { get; set; }
        public List<Promotion> Promotions { get; set; }
    }
}
