namespace TT2.Entity
{
    public class ConfirmEmail
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime RequiredTime { get; set; }
        public DateTime ExpiredTime { get; set; }
        public string ConfirmCode { get; set; }
        public bool IsConfirm { get; set; }

        public virtual User User { get; set; }
    }
}
