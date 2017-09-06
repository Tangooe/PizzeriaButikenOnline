namespace PizzeriaButikenOnline.Core.ViewModels
{
    public class IngredientViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsSelected { get; set; }
        public bool IsDefault { get; set; }
    }
}
