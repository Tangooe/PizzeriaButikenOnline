namespace PizzeriaButikenOnline.Models
{
    public class CartLine
    {
        public int Id { get; set; }
        public Dish Dish { get; set; }
        public int Quantity { get; set; }
    }
}