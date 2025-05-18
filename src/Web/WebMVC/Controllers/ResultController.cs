using Catalog.Domain;
using IntegrationEvents;
using MassTransit;
using MassTransit.Registration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Globalization;
using System.Threading.Tasks;
using WebMVC.Application.Interfaces;
using WebMVC.Models;
using WebMVC.Services;
using static Humanizer.On;

namespace WebMVC.Controllers
{
    public class ResultController : Controller
    {
        private readonly IPlateService _plateService;
        
        private readonly IProducerService _producerService;
        private readonly IViewModelBuilder _modelBuilder;


        public ResultController(IPlateService plateService, IProducerService producerService, IViewModelBuilder modelBuilder) 
        {
            _plateService = plateService;
            
            _producerService = producerService;
            _modelBuilder = modelBuilder;
        }  
        public async Task <IActionResult> Index(bool checkSold, string? queryString = null, string? sortBy = null, string? promoCode = null)
        {
            ResultsViewModel vmodel = new ResultsViewModel();

            var result = await _modelBuilder.ConfigureResultIndexViewModel(vmodel, checkSold, queryString, sortBy, promoCode);

            if (result.PlateRecords != null) 
            {
                return View(result);
            }

            return RedirectToAction("NoPlateFound", "result", new { reg = queryString });
        }
       


        public IActionResult FailedPromoCode(string promoCode)
        {
            ViewData["promoCode"] = promoCode;
            return View();
        }

        public IActionResult NoPlateFound(string NoPlateFound)
        {
            ViewData["Registration"] = NoPlateFound;
            return View();
        }

        public IActionResult SearchPlate(string Registration, string? PromoCode)
        {
            //promocode should be stored in a database preferably 
            if (PromoCode != "DISCOUNT" && PromoCode != "PERCENTOFF" && !string.IsNullOrWhiteSpace(PromoCode))
            {
                return RedirectToAction("FailedPromoCode" ,"result", new { promoCode = PromoCode });
            }

           //var plates = await _plateService.SearchPlates(plate);

            return RedirectToAction("index", "result", new { queryString = Registration, sortby = "", promoCode = PromoCode } );
        }

        public IActionResult SearchSoldPlates(string Registration)
        {
            return RedirectToAction("index", "result", new { queryString = Registration, checkSold = true });
        }
        [HttpPost]
        public async Task<IActionResult> AddPlate(PlateViewModel model)
        {
            
            Sample evt = new()
            {
                Id = new Guid(),
                Registration = model.Registration,
                SalePrice = model.SalePrice,
                PurchasePrice = model.PurchasePrice,
                Letters = model.Letters,
                Numbers = model.Numbers,

            };
            var result = await _producerService.AddPlate(evt);

            if (result != true)
                return RedirectToAction("Error", "home");

            return RedirectToAction("index", "home");
        }

        public async Task<IActionResult> ReservePlate(string reg, string queryString, string sortBy = "")
        {
            await _producerService.ReservePlate(reg);
            await Task.Delay(3000);
            return RedirectToAction("index", "result", new { QueryString = queryString, sortby = sortBy });
        }

        public async Task<IActionResult> UnreservePlate(string reg, string queryString, string sortBy = "")
        {
            await _producerService.UnreservePlate(reg);
            await Task.Delay(3000);
            return RedirectToAction("index", "result", new { QueryString = queryString, sortby = sortBy });
        }

        public async Task<IActionResult> SellPlate(string reg, string sortBy)
        {
            await _producerService.SellPlate(reg);
            await Task.Delay(3000);
            return RedirectToAction("index", "result", new { sortby = sortBy });
        }
        

    }
}
