namespace Domain
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public List<Burger> Burgers { get; set; }
        public DateTime OrderDate { get; set; }
    }


}
