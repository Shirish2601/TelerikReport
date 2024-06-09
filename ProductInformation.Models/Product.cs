namespace ProductInformation.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductCategory { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductQuantity { get; set; }
        public string ProductBrand { get; set; }
        public decimal ProductWeight { get; set; }
        public string ProductDimensions { get; set; }
        public DateTime ProductReleaseDate { get; set; }
        public double ProductRating { get; set; }
    }
}
