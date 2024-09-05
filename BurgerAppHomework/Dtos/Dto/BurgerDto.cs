using Domain;

namespace Dtos.Dtos
{
    public class BurgerDto
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public int Price { get; set; }
        public string IsVegetarian { get; set; }
        public string IsVegan { get; set; }
        public string HasFries { get; set; }


    }
}
 