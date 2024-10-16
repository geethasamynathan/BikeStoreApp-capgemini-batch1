using System.ComponentModel.DataAnnotations;

namespace BikeStoreApp_BackEnd.Models
{
    public class Inventory
    {
        [Key]
        public int InventoryId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int Quantity { get; set; } = 0;

        public DateTime? RestockDate { get; set; }

        // Navigation Properties
        public Product Product { get; set; }
    }
}
