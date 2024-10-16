using System.ComponentModel.DataAnnotations;

namespace BikeStoreApp_FrontEnd.Models
{
    public class ShoppingCart
    {
      
        public int CartId { get; set; }

        public int UserId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public virtual Product Product { get; set; } = null!;

        public virtual User User { get; set; } = null!;
    }
}
