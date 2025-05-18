using System.Globalization;
using WebMVC.Application.Interfaces;
using WebMVC.Application.Services;
using WebMVC.Models;

namespace WebMVC.Services
{
    public class ViewModelBuilder : IViewModelBuilder
    {
        private readonly IPlateService _plateService;
        public ViewModelBuilder(IPlateService plateService)
        {
            _plateService = plateService;
        }
        public async Task<ResultsViewModel> ConfigureResultIndexViewModel(ResultsViewModel vmResult, bool checkSold, string? queryString = null, string? sortBy = null, string? promoCode = null)
        {
            var margin = await _plateService.GetAverageProfitMargin();
            var revenue = await _plateService.GetRevenue();

            vmResult.QueryString = queryString;
            vmResult.SortBy = sortBy;
            vmResult.PlatesRevenue = revenue.ToString("C", CultureInfo.GetCultureInfo("en-GB"));
            vmResult.AverageProfitMargin = margin.ToString("C", CultureInfo.GetCultureInfo("en-GB"));
            vmResult.PromoCode = promoCode;

            if (checkSold)
            {
                var plate = await _plateService.SearchSoldPlate(queryString);
                if (plate == null)
                {
                    return vmResult;
                }
                vmResult.PlateRecords = new List<PlateRecord> { plate };

            }
            else
            {
                vmResult.PlateRecords = await _plateService.SearchPlates(queryString, promoCode);
            }

            vmResult.TotalPlates = vmResult.PlateRecords.Count();

            vmResult.PlateRecords = sortModel(sortBy, vmResult.PlateRecords);

            vmResult.PlateRecords = AddTax(vmResult.PlateRecords);

            return vmResult;
        }

        private List<PlateRecord> sortModel(string sortBy, List<PlateRecord> plates)
        {
            switch (sortBy)
            {
                case "pPrice_desc":
                    plates = plates.OrderByDescending(s => s.PurchasePrice).ToList();
                    break;
                case "pPrice_asc":
                    plates = plates.OrderBy(s => s.PurchasePrice).ToList();
                    break;
                case "sPrice_desc":
                    plates = plates.OrderByDescending(s => s.SalePrice).ToList();
                    break;
                case "sPrice_asc":
                    plates = plates.OrderBy(s => s.SalePrice).ToList();
                    break;
                default:
                    //plates = plates.OrderBy(s => s.SalePrice).ToList();
                    break;
            }
            return plates;
        }

        private List<PlateRecord> AddTax(List<PlateRecord> model)
        {
            foreach (PlateRecord plate in model)
            {
                plate.SalePrice = Math.Round( plate.SalePrice + (plate.SalePrice / 100 * 20), 2);
            }
            return model;
        }
    }
}
