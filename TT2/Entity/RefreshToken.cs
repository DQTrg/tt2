﻿namespace TT2.Entity
{
    public class RefreshToken
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public DateTime ExpiredTime { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}