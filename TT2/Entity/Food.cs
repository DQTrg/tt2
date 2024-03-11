using System.Globalization;

namespace TT2.Entity
{
    public class Food
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string Image {  get; set; }
        public string NameOfFood { get; set; }
        public bool IsActive { get; set; }
    }
}
