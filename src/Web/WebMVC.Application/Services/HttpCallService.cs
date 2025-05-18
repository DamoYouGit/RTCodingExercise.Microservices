using Catalog.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMVC.Application.Interfaces;

namespace WebMVC.Application.Services
{
    public class HttpCallService : IHttpCallService
    {
        private readonly HttpClient _client;
        public HttpCallService(HttpClient client) { _client = client; }
        public async Task<List<PlateRecord>> GetAllPlates()
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync("http://catalog-api:80/api/plates/getallplates");
                response.EnsureSuccessStatusCode();
                var jsonResult = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<PlateRecord>>(jsonResult);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            
        }

        public async Task<decimal> GetProfitMargin()
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync("http://catalog-api:80/api/plates/GetAverageProfitMargin");
                response.EnsureSuccessStatusCode();
                var jsonResult = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<decimal>(jsonResult);

            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task<List<PlateRecord>> GetPromoCodeSearchPlates(string reg, string code)
        {
            try
            {
                NameValueCollection queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);

                queryString.Add("reg", reg);
                queryString.Add("promoCode", code);
                HttpResponseMessage response = await _client.GetAsync($"http://catalog-api:80/api/plates/GetPromoDeals?{queryString.ToString()}");
                response.EnsureSuccessStatusCode();
                var jsonResult = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<PlateRecord>>(jsonResult);
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
           
        }

        public async Task<decimal> GetRevenue()
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync("http://catalog-api:80/api/plates/GetRevenue");
                response.EnsureSuccessStatusCode();
                var jsonResult = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<decimal>(jsonResult);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<PlateRecord>> GetSearchPlates(string reg)
        {
            try
            {
 
                HttpResponseMessage response = await _client.GetAsync($"http://catalog-api:80/api/plates/GetPlates?reg={reg}");
                response.EnsureSuccessStatusCode();
                var jsonResult = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<PlateRecord>>(jsonResult);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public async Task<PlateRecord> GetSoldPlates(string reg)
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync($"http://catalog-api:80/api/plates/SearchSoldPlate?reg={reg}");
                response.EnsureSuccessStatusCode();
                var jsonResult = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<PlateRecord>(jsonResult);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
