namespace Dtos.Dtos
{
    public class FilterDto
    {
        public List<BurgerDto> Burgers { get; set;}
        public List<OrderDto> Orders { get; set;}
        public int? OrderId { get; set;} =0;
        public int? BurgerId { get; set; } = 0;
    }
}
