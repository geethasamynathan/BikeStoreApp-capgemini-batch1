namespace BikeStoreApp_FrontEnd.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; } = null!;

        public virtual ICollection<Brand> Brands { get; set; } = new List<Brand>();

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
