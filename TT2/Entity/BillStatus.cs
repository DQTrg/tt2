﻿namespace TT2.Entity
{
    public class BillStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Bill> Bills { get; set; }
    }
}