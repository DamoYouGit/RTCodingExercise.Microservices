using Catalog.Domain;
using Microsoft.IdentityModel.Tokens;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMVC.Application.Interfaces;
using WebMVC.Application.Services;
using WebMVC.Models;
using WebMVC.Services;
using Xunit;

namespace WebMVC.UnitTests.ServiceTests
{
    public class ViewModelBuilderTests
    {
        private readonly Mock<IPlateService> _MockPlateService = new Mock<IPlateService>();
        private readonly ViewModelBuilder _sut;
        private readonly PlateRecord _searchPlateResponseObject1;
        private readonly PlateRecord _searchPlateResponseObject2;
        private readonly PlateRecord _searchPlateResponseObject3;
        private readonly PlateRecord _searchPlateResponseObject4;
        List<PlateRecord> _searchPlateResponse;
        List<PlateRecord> _searchPlateResponse1;
        public ViewModelBuilderTests()
        {
            //the main (in) arranger lol
            _sut = new ViewModelBuilder(_MockPlateService.Object);
            _searchPlateResponseObject1 = new PlateRecord { Registration = "testReg1", SalePrice = 500, PurchasePrice = 260 };
            _searchPlateResponseObject2 = new PlateRecord { Registration = "testReg2", SalePrice = 700, PurchasePrice = 200 };
            _searchPlateResponseObject3 = new PlateRecord { Registration = "testReg3", SalePrice = 900, PurchasePrice = 250 };
            _searchPlateResponseObject4 = new PlateRecord { Registration = "testReg4", SalePrice = 200 , PurchasePrice = 150};

            _searchPlateResponse = new List<PlateRecord> { _searchPlateResponseObject1, _searchPlateResponseObject2 };
            _searchPlateResponse1 = new List<PlateRecord> { _searchPlateResponseObject1, _searchPlateResponseObject2, _searchPlateResponseObject3, _searchPlateResponseObject4 };
        }
        [Fact]
        public async Task ConfigureResultIndexViewModel_CalledWithNoData_ShouldReturnPLates() 
        {

            //arrange
            _MockPlateService.Setup(x => x.SearchPlates(null,null).Result).Returns(_searchPlateResponse);

            //act
            ResultsViewModel result = await _sut.ConfigureResultIndexViewModel(new ResultsViewModel(), false, null, null, null);

            //assert
            Assert.NotNull(result);
            Assert.Equal(2, result.TotalPlates);
      

        }

        [Fact]
        public async Task ConfigureResultIndexViewModel_CalledWithCheckSoldTrueAndReg_ShouldReturnOnePlate()
        {

            //arrange
            _MockPlateService.Setup(x => x.SearchSoldPlate("testReg1").Result).Returns(_searchPlateResponseObject1);

            //act
            ResultsViewModel result = await _sut.ConfigureResultIndexViewModel(new ResultsViewModel(), true, "testReg1", null, null);

            //assert
            Assert.NotNull(result);
            Assert.Equal(1, result.PlateRecords.Count());
            

        }

        [Fact]
        public async Task ConfigureResultIndexViewModel_CalledWithCheckSoldTrueAndInccorReg_ShouldReturnNoPlate()
        {

            //arrange
            _MockPlateService.Setup(x => x.SearchSoldPlate("testReg1").Result);

            //act
            ResultsViewModel result = await _sut.ConfigureResultIndexViewModel(new ResultsViewModel(), true, "testReg1", null, null);

            //assert
            Assert.NotNull(result);
            Assert.Equal(null, result.PlateRecords);


        }

        [Fact]
        public async Task ConfigureResultIndexViewModel_CalledWithPromoCodeRegAndSortBy_ViewModelShouldContainThisInformation()
        {

            //arrange

            _MockPlateService.Setup(x => x.SearchPlates("testReg1", "LUCKDIP").Result).Returns(_searchPlateResponse);

            //act
            ResultsViewModel result = await _sut.ConfigureResultIndexViewModel(new ResultsViewModel(), false, "testReg1", "TOP2TOE", "LUCKDIP");

            //assert
            Assert.NotNull(result);
            Assert.Equal(2, result.PlateRecords.Count());
            Assert.Equal("TOP2TOE", result.SortBy);
            Assert.Equal("LUCKDIP", result.PromoCode);
            Assert.Equal("testReg1", result.QueryString);


        }
        [Fact]
        public async Task ConfigureResultIndexViewModel_CallingPlateService_ToUpdateViewModelRevenueAndMargin()
        {
            //arrange
            _MockPlateService.Setup(x => x.SearchPlates("testReg1", "LUCKDIP").Result).Returns(_searchPlateResponse);
            _MockPlateService.Setup(x => x.GetAverageProfitMargin().Result).Returns(200);
            _MockPlateService.Setup(x => x.GetRevenue().Result).Returns(100);

            //act
            ResultsViewModel result = await _sut.ConfigureResultIndexViewModel(new ResultsViewModel(), false, "testReg1", "TOP2TOE", "LUCKDIP");

            //assert
            Assert.Equal("£200.00", result.AverageProfitMargin);
            Assert.Equal("£100.00", result.PlatesRevenue);
        }

        [Fact]
        public async Task ConfigureResultIndexViewModel_UsingSortBypPrice_desc_ShouldConfigureHighestPurchasePrice()
        {
            //arrange
            _MockPlateService.Setup(x => x.SearchPlates("testReg1", "LUCKDIP").Result).Returns(_searchPlateResponse1);
            _MockPlateService.Setup(x => x.GetAverageProfitMargin().Result).Returns(200);
            _MockPlateService.Setup(x => x.GetRevenue().Result).Returns(100);

            //act
            ResultsViewModel result = await _sut.ConfigureResultIndexViewModel(new ResultsViewModel(), false, "testReg1", "pPrice_desc", "LUCKDIP");

            //assert
            Assert.Equal(260, result.PlateRecords.FirstOrDefault().PurchasePrice);
        }



    }
}
