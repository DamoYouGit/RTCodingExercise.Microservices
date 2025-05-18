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
using Xunit;

namespace WebMVC.UnitTests.ServiceTests
{
    public class PlateServiceTests
    {
        private readonly Mock<IHttpCallService> _mockHttpCallService;
        private readonly PlateService _sut;
        private readonly PlateRecord _searchPlateResponseObject1;
        private readonly PlateRecord _searchPlateResponseObject2;
        private readonly PlateRecord _searchPlateResponseObject3;
        private readonly PlateRecord _searchPlateResponseObject4;
        List<PlateRecord> _searchPlateResponse;
        List<PlateRecord> _searchPlateResponse1;
        public PlateServiceTests()
        {
            _mockHttpCallService = new Mock<IHttpCallService>();
            _sut = new PlateService(_mockHttpCallService.Object);

            _searchPlateResponseObject1 = new PlateRecord { Registration = "testReg1", SalePrice = 500, PurchasePrice = 260 };
            _searchPlateResponseObject2 = new PlateRecord { Registration = "testReg2", SalePrice = 700, PurchasePrice = 200 };
            _searchPlateResponseObject3 = new PlateRecord { Registration = "testReg3", SalePrice = 900, PurchasePrice = 250 };
            _searchPlateResponseObject4 = new PlateRecord { Registration = "testReg4", SalePrice = 200, PurchasePrice = 150 };

            _searchPlateResponse = new List<PlateRecord> { _searchPlateResponseObject1, _searchPlateResponseObject2 };
            _searchPlateResponse1 = new List<PlateRecord> { _searchPlateResponseObject1, _searchPlateResponseObject2, _searchPlateResponseObject3, _searchPlateResponseObject4 };

        }

        [Fact]
        public async Task SearchPlates_WithNoParams_ShouldCAllSearchPlatesAndReturnData()
        {
            //arrange
            _mockHttpCallService.Setup(x => x.GetAllPlates().Result).Returns(_searchPlateResponse);

            //act
            var result = await _sut.SearchPlates("", "");
            //assert

            Assert.NotNull(result);
            _mockHttpCallService.Verify(x => x.GetPromoCodeSearchPlates("", ""), Times.Never);
            _mockHttpCallService.Verify(x => x.GetSearchPlates(""), Times.Never);
        }

        [Fact]
        public async Task SearchPlates_WithRegAndPromoCode_shouldCallGetPromoCodeSearchPlatesMethodAndReturnData()
        {
            //arrange
            _mockHttpCallService.Setup(x => x.GetPromoCodeSearchPlates("REG", "PROMO").Result).Returns(_searchPlateResponse);

            //act
            var result = await _sut.SearchPlates("REG", "PROMO");
            //assert

            Assert.NotNull(result);
            _mockHttpCallService.Verify(x => x.GetAllPlates(), Times.Never);
            _mockHttpCallService.Verify(x => x.GetSearchPlates(""), Times.Never);
        }

        [Fact]
        public async Task SearchPlates_WithRegOnly_shouldCallGetSearchPlatesMethodAndReturnData()
        {
            //arrange
            _mockHttpCallService.Setup(x => x.GetSearchPlates("REG").Result).Returns(_searchPlateResponse);

            //act
            var result = await _sut.SearchPlates("REG");
            //assert

            Assert.NotNull(result);
            _mockHttpCallService.Verify(x => x.GetAllPlates(), Times.Never);
            _mockHttpCallService.Verify(x => x.GetPromoCodeSearchPlates("", ""), Times.Never);
        }

        [Fact]
        public async Task GetAverageProfitMargin_WhenCalled_ShouldReturnADecimal()
        {
            //arrange
            _mockHttpCallService.Setup(x => x.GetProfitMargin().Result).Returns(100);

            //act
            var result = await _sut.GetAverageProfitMargin();
            
            //assert
            Assert.NotNull(result);
            Assert.Equal(100, result);
        }

        [Fact]
        public async Task GetRevenue_WhenCalled_ShouldReturnADecimal()
        {
            //arrange
            _mockHttpCallService.Setup(x => x.GetRevenue().Result).Returns(500);

            //act
            var result = await _sut.GetRevenue();

            //assert
            Assert.NotNull(result);
            Assert.Equal(500, result);
        }

        [Fact]
        public async Task SearchSoldPlate_WhenCalled_ShouldReturnAPLateRecord()
        {
            //arrange
            _mockHttpCallService.Setup(x => x.GetSoldPlates("REG").Result).Returns(_searchPlateResponseObject4);

            //act
            var result = await _sut.SearchSoldPlate("REG");

            //assert
            Assert.NotNull(result);
            Assert.Equal(200, result.SalePrice);
        }

        [Fact]
        public async Task SearchSoldPlate_WhenCalledWithNoReg_ShouldReturnAPLateRecord()
        {
            //arrange
            _mockHttpCallService.Setup(x => x.GetSoldPlates("").Result).Returns(_searchPlateResponseObject4);

            //act
            var result = await _sut.SearchSoldPlate("");

            //assert
            Assert.NotNull(result);
            Assert.Equal(200, result.SalePrice);
        }


    }

}
