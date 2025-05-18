namespace Catalog.API.Interfaces
{
    public interface IPromoCodeService
    {
        public List<PlateRecord> ApplyDiscountPromo(List<PlateRecord> plates);
        public List<PlateRecord> ApplyPercentOffPromo(List<PlateRecord> plates);
    }
}
