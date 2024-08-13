namespace Dtos.ViewModels
{
    public class CreateBurgerVM
    {
        public int Id { get; set; }  // For edit scenarios; default to 0 for new burgers
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsVegetarian { get; set; }
        public bool IsVegan { get; set; }
        public bool HasFries { get; set; }
        public int LocationId { get; set; }
    }
}
