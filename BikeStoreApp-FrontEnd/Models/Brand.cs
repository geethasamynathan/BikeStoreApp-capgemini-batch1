namespace BikeStoreApp_FrontEnd.Models
{
    public class Brand
    {
        public int BrandId { get; set; }

        public string BrandName { get; set; } = null!;

        public int? CategoryId { get; set; }

        public virtual Category? Category { get; set; }

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
