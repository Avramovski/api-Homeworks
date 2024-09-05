
using Domain;
namespace Dtos.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string IsDelivered { get; set; }
        public string Location { get; set; }
        public List<Burger> Burgers { get; set; }
    }
}
