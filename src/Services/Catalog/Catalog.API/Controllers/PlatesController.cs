using Catalog.API.Interfaces;
using Catalog.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;

namespace Catalog.API.Controllers
{
   [Microsoft.AspNetCore.Mvc.Route("api/[controller]/[action]")]
    [ApiController]
    public class PlatesController :ControllerBase
    {
        private IPlateRepository _plateRepository;
        private IPromoCodeService _promoCodeService;
        public PlatesController(IPlateRepository plateRepository, IPromoCodeService promoCodeService) 
        {
            _plateRepository = plateRepository;
            _promoCodeService = promoCodeService;
        }

        //[HttpGet]
        public List<PlateRecord> GetAllPlates()
        {
           
            return _plateRepository.GetAllPlates();
        }

        //[HttpPost]
        public List<PlateRecord> GetPlates(string reg = "")
        {
            var result = _plateRepository.GetPlates(reg);

            return  result;

        }

        public List<PlateRecord> GetPromoDeals(string reg = "", string promoCode = "")
        {
            var result = _plateRepository.GetPlates(reg);

            //add promotion
            if (promoCode == "DISCOUNT" || promoCode == "PERCENTOFF")
            {
                if (promoCode == "DISCOUNT")
                    return _promoCodeService.ApplyDiscountPromo(result);

                if (promoCode == "PERCENTOFF")
                    return _promoCodeService.ApplyPercentOffPromo(result);

            }
            return result;
        }

        public decimal GetRevenue()
        {
            return _plateRepository.GetPlatesRevenue();
        }
        public decimal GetAverageProfitMargin()
        {
            return _plateRepository.GetProfitMargin();
        }

        public PlateRecord SearchSoldPlate(string reg)
        {
            return _plateRepository.GetSoldPlate(reg);
        }

    }
}
