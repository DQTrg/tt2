namespace TT2.Entity
{
    public class UserStatus
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public List<User> Users { get; set; }
    }
}
