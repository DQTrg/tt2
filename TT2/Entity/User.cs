namespace TT2.Entity
{
    public class User
    {
        public int Id { get; set; }
        public int Point { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public int RankCustomerId { get; set; }
        public int UserStatusId { get; set; }
        public bool IsActive { get; set; }
        public int RoleId { get; set; }

        public List<Bill> Bills { get; set; }
    }
}
