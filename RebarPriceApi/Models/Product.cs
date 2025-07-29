namespace RebarPriceApi.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Size { get; set; }
        public string Form { get; set; }
        public string Standard { get; set; }
        public string Warehouse { get; set; }
        public string Unit { get; set; }
        public int price { get; set; }
        public DateTime LastPriceDate { get; set; }
    }
}
