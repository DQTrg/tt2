namespace TT2.Entity
{
    public class Role
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string RoleName { get; set; }

        public List<User> Users { get; set; }
    }
}
