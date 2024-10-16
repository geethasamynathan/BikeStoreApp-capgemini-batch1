namespace BikeStoreApp_FrontEnd.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public int UserId { get; set; }

        public DateTime OrderDate { get; set; }

        public double TotalPrice { get; set; }

        public string OrderStatus { get; set; } = null!;

        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public virtual User User { get; set; } = null!;
    }
}
