using Catalog.API.Interfaces;
using System.Web.Http;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;


namespace Catalog.API.Controllers
{
    //[Microsoft.AspNetCore.Mvc.Route("[controller]")]
    //[ApiController]
    public class HomeController : ControllerBase
    {
        private ApplicationDbContext _context;
        private IPlateRepository _plateRepository;
        public HomeController(ApplicationDbContext context, IPlateRepository plateRepository) 
        {
            _context = context;
            _plateRepository = plateRepository;
        }

        //[System.Web.Http.HttpGetAttribute]
        //public IActionResult Index()
        //{
        //    return new RedirectResult("~/swagger");
        //}

        //[System.Web.Http.HttpGet]
        //[System.Web.Http.Route("[controller]/GetAllPlates")]

        //[HttpGet]
        //public List<Plate> GetAllPlates()
        //{
                       
        //    return _plateRepository.GetAllPlates();
        //}

        //[System.Web.Http.HttpPost]
        //[System.Web.Http.Route("[controller]/SearchPlates")]
        //[HttpPost]
        //public List<Plate> SearchPlates(Plate plate)
        //{

        //    return  _plateRepository.GetPlates(plate.Registration);
        //}


    }

    
}
