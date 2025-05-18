using Catalog.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMVC.Application.Interfaces
{
    public interface IHttpCallService
    {
        public Task<List<PlateRecord>> GetAllPlates();
        public Task<List<PlateRecord>> GetPromoCodeSearchPlates(string reg, string code);
        public Task<List<PlateRecord>> GetSearchPlates(string reg);
        public Task<PlateRecord> GetSoldPlates(string reg);
        public Task<decimal> GetProfitMargin();
        public Task<decimal> GetRevenue();


    }
}
