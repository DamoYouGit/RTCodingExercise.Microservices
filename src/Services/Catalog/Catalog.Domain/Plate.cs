namespace Catalog.Domain
{
    public class Plate
    {
        public Guid Id { get; set; }

        public string? Registration { get; set; }

        public decimal PurchasePrice { get; set; }

        public decimal SalePrice { get; set; }

        public string? Letters { get; set; }

        public int Numbers { get; set; }
        public bool Sold { get; set; }
        public bool Reserved { get; set; }
        //public string? PromoName { get; set; }
        //public bool HasPromo { get; set; } = false;

    }
}