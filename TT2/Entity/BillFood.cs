namespace TT2.Entity
{
    public class BillFood
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int BillId { get; set; }
        public int FoodId { get; set; }

        public virtual Bill Bill { get; set; }
        public virtual Food Food { get; set; }
    }
}
