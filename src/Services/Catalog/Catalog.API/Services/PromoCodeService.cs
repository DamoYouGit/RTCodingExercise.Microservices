using Catalog.API.Interfaces;

namespace Catalog.API.Services
{
    public class PromoCodeService : IPromoCodeService
    {
        public List<PlateRecord> ApplyDiscountPromo(List<PlateRecord> plates)
        {

            foreach (var plate in plates)
            {
                var promoPercentageThreshold = (plate.SalePrice / 100 * 90);
                if ((plate.SalePrice -25 )  > promoPercentageThreshold)
                {
                    plate.SalePrice = plate.SalePrice - 25;
                    plate.HasPromo = true;
                    plate.PromoName = "DISCOUNT";
                }          

            }
            return plates;
        }

        public List<PlateRecord> ApplyPercentOffPromo(List<PlateRecord> plates)
        {
            foreach (var plate in plates)
            {
                plate.SalePrice = plate.SalePrice - (plate.SalePrice / 100 * 15);
                plate.HasPromo = true;
                plate.PromoName = "PERCENTOFF";

            }
            return plates;
        }
    }
}
