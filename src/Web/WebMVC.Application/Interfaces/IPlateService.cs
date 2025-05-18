using Catalog.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WebMVC.Application.Interfaces
{
    public interface IPlateService
    {
        public Task<List<PlateRecord>> SearchPlates(string querystring, string promoCode);
        public Task<decimal> GetRevenue();
        public Task<decimal> GetAverageProfitMargin();
        public Task<PlateRecord> SearchSoldPlate(string querystring);
    }
}
