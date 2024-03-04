namespace TT2.Entity
{
    public class Bill
    {
        public int Id { get; set; }
        public double TotalMoney { get; set; }
        public string TradingCode { get; set; }
        public DateTime CreateTime { get; set; }
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public DateTime UpdateTime { get; set; }
        public int PromotionId { get; set; }
        public int BillStatusId { get; set; }
        public bool IsActive { get; set; }

        public virtual User Customer { get; set; }
        public virtual BillStatus BillStatus { get; set; }
        public virtual Promotion Promotion { get; set; }
    }
}
