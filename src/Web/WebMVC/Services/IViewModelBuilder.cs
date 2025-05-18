using WebMVC.Application.Interfaces;
using WebMVC.Models;

namespace WebMVC.Services
{
    public interface IViewModelBuilder
    {
        public Task<ResultsViewModel> ConfigureResultIndexViewModel(ResultsViewModel vmResult, bool checkSold, string? queryString = null, string? sortBy = null, string? promoCode = null);
    }
}
