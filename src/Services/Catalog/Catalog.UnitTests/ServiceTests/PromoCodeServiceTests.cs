using Catalog.API.Services;
using Catalog.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Catalog.UnitTests.ServiceTests
{
    public class PromoCodeServiceTests
    {
        private readonly PromoCodeService _sut;
        private  PlateRecord _discountCriteriaObject1, _discountCriteriaObject2;
        private  PlateRecord _noDiscountCriteriaObject1, _noDiscountCriteriaObject2;
        //private readonly PlateRecord _searchPlateResponseObject3;
        //private readonly PlateRecord _searchPlateResponseObject4;
        List<PlateRecord> _noDiscountList;
        List<PlateRecord> _searchPlateResponse1;
        public PromoCodeServiceTests()
        {
            _sut = new PromoCodeService();

        }

        [Fact]
        public void ApplyDiscountPromo_WithValidDiscountCriteria_shouldContainPromoData()
        {
            //arrange

            _discountCriteriaObject1 = new PlateRecord { Registration = "testReg1", SalePrice = 500, PurchasePrice = 260 };
            _discountCriteriaObject2 = new PlateRecord { Registration = "testReg2", SalePrice = 700, PurchasePrice = 200 };
            _searchPlateResponse1 = new List<PlateRecord> { _discountCriteriaObject1, _discountCriteriaObject2 };
            //act
            var result = _sut.ApplyDiscountPromo(_searchPlateResponse1);
            //assert
            Assert.Equal(2, result.Count());
            Assert.Equal(2, result.Where(x => x.HasPromo).Count());
            Assert.Equal("DISCOUNT", result.Select(x => x.PromoName).FirstOrDefault());
        }

        [Fact]
        public void ApplyDiscountPromo_WithNonValidDiscountCriteria_shouldContainPromoData()
        {
            //arrange

            _noDiscountCriteriaObject1 = new PlateRecord { Registration = "testReg1", SalePrice = 250, PurchasePrice = 260 };
            _noDiscountCriteriaObject2 = new PlateRecord { Registration = "testReg2", SalePrice = 200, PurchasePrice = 200 };
            _noDiscountList = new List<PlateRecord> { _noDiscountCriteriaObject1, _noDiscountCriteriaObject2 };
            //act
            var result = _sut.ApplyDiscountPromo(_noDiscountList);
            //assert
            Assert.Equal(2, result.Count());
           Assert.Equal(0, result.Where(x => x.HasPromo).Count());
        }

        [Fact]
        public void ApplyPercentOffPromo_WithNonValidDiscountCriteria_shouldContainPromoData()
        {
            //arrange

            _discountCriteriaObject1 = new PlateRecord { Registration = "testReg1", SalePrice = 250, PurchasePrice = 260 };
            _discountCriteriaObject2 = new PlateRecord { Registration = "testReg2", SalePrice = 200, PurchasePrice = 200 };
            _noDiscountList = new List<PlateRecord> { _discountCriteriaObject1, _discountCriteriaObject2 };
            //act
            var result = _sut.ApplyPercentOffPromo(_noDiscountList);
            //assert
            Assert.Equal(2, result.Count());
            Assert.Equal(2, result.Where(x => x.HasPromo).Count());
            Assert.Equal("PERCENTOFF", result.Select(x => x.PromoName).FirstOrDefault());
        }

    }
}
