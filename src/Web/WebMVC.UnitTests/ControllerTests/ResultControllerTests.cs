using Catalog.Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMVC.Application.Interfaces;
using WebMVC.Controllers;
using WebMVC.Models;
using WebMVC.Services;
using Xunit;
namespace WebMVC.UnitTests.ControllerTests
{
    public class ResultControllerTests
    {
        //[Fact]
        //public async Task CallingIndex_WithNoParams_ShouldReturnAllPlates()
        //{
        //    //arrange
        //    var mockPlateService = new Mock<IPlateService>();
        //    var mockProducerService = new Mock<IProducerService>();
        //    var mockViewModelBuilder = new Mock<IViewModelBuilder>();


        //    var list = new List<PlateRecord>();
        //    var plate = new PlateRecord();
        //    var mockVmodel = new ResultsViewModel();

        //    var returnModel = new ResultsViewModel { TotalPlates = 10};


        //    //var mock

        //    mockViewModelBuilder.Setup(x => x.ConfigureResultIndexViewModel(mockVmodel, mockPlateService.Object, false, null, null, null).Result).Returns(returnModel);

        //    //mockViewModelBuilder.Setup

        //    mockPlateService.Setup(x => x.GetAverageProfitMargin().Result).Returns(1.000m);
        //    mockPlateService.Setup(x => x.GetRevenue().Result).Returns(1.000m);
        //    mockPlateService.Setup(x => x.SearchPlates("", "").Result).Returns(list);
        //    //mockPlateService.Setup(x => x.SearchSoldPlate("anytext").Result).Returns(plate);



        //    //act

        //    //assert





        //    var sut = new ResultController(mockPlateService.Object, mockProducerService.Object, mockViewModelBuilder.Object);
        //    ////act
        //    var c = await sut.Index(false);
           
        //    //await sut.Index(false);
        //    ////assert
        //    mockViewModelBuilder.Verify(x => x.ConfigureResultIndexViewModel(mockVmodel, mockPlateService.Object, false, null, null, null), Times.Once());
        //    //mockPlateService.Verify(x => x.SearchSoldPlate("anytext"), Times.Never());
        //}

        //[Fact]
        //public async Task CallingIndex_WithCheckSold_ShouldCallSearchSoldPlateMethod()
        //{
        //    //arrange
        //    var mockPlateService = new Mock<IPlateService>();
        //    var mockProducerService = new Mock<IProducerService>();
        //    var plate = new PlateRecord();
        //    var list = new List<PlateRecord> { plate };
            
        //    //var mock

        //    mockPlateService.Setup(x => x.GetAverageProfitMargin().Result).Returns(1.000m);
        //    mockPlateService.Setup(x => x.GetRevenue().Result).Returns(1.000m);
        //    //mockPlateService.Setup(x => x.SearchPlates(null, null).Result).Returns(list);
        //    mockPlateService.Setup(x => x.SearchSoldPlate("HEY").Result).Returns(plate);

        //    //var sut = new ResultController(mockPlateService.Object, mockProducerService.Object, mockViewModelBuilder.Object);
        //    ////act
        //    //await sut.Index(true);
        //    ////assert
        //    ////mockPlateService.Verify(x => x.SearchPlates(null, null), Times.Never());
        //    //mockPlateService.Verify(x => x.SearchSoldPlate("HEY"), Times.Once());
        //}
    }
}
