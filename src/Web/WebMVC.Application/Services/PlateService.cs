using Catalog.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebMVC.Application.Interfaces;

namespace WebMVC.Application.Services
{
    public class PlateService : IPlateService
    {
        //IHttpClientFactory _factory;

        private readonly IHttpCallService _httpClientService;


        public PlateService(IHttpCallService httpClientService)
        {
            
            _httpClientService = httpClientService;
        }
     
        public async Task<decimal> GetAverageProfitMargin()
        {

            return await _httpClientService.GetProfitMargin();
        }

        public async Task<decimal> GetRevenue()
        {

            return await _httpClientService.GetRevenue();
        }

        public async Task<List<PlateRecord>> SearchPlates(string reg = "", string promoCode ="")
        {

                if (string.IsNullOrEmpty(reg) && string.IsNullOrEmpty(promoCode))
                {
     
                    return await _httpClientService.GetAllPlates();
                }
                else if (!string.IsNullOrEmpty(reg) && !string.IsNullOrEmpty(promoCode))
                {

                    return await _httpClientService.GetPromoCodeSearchPlates(reg, promoCode);
                }
                else
                {

                    return await _httpClientService.GetSearchPlates(reg);
                }            
        }

        public async Task<PlateRecord> SearchSoldPlate(string querystring)
        {

            return await _httpClientService.GetSoldPlates(querystring);
        }
    }
}
