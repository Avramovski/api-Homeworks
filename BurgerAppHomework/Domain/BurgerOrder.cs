namespace Domain
{
    public class BurgerOrder
    {
        public int BurgerId { get; set; }
        public Burger Burger { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
    }

}
