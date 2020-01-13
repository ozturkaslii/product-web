namespace ProductCatalog.UI.Models
{
    public class ProductUpdateRequestModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public decimal Price { get; set; }
    }
}