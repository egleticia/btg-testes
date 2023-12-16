using btg_testes_auto.Discount;
using FluentAssertions;
using NSubstitute;

namespace btg_test.ClientDiscountTest
{
    public class DiscountServiceTest
    {
        private readonly ICustomerService _mockCustomerService;
        private readonly DiscountService _sut;

        public DiscountServiceTest()
        {
            _mockCustomerService = Substitute.For<ICustomerService>();
            _sut = new DiscountService(_mockCustomerService);
        }


        [Fact(DisplayName = "No Discount")]
        public void GetDiscount_OthersCustomer_ReturnRegularPrice()
        {
            _mockCustomerService.GetCustomerType(0).Returns(CustomerType.Others);

            double result = _sut.GetDiscount(0, 1000);

            result.Should().Be(0);
            _mockCustomerService.Received().GetCustomerType(0);
        }

        [Fact(DisplayName = "5% Discount")]
        public void GetDiscount_RegularCustomer_ReturnPriceWith5PercetOff()
        {
            _mockCustomerService.GetCustomerType(1).Returns(CustomerType.Regular);

            double result = _sut.GetDiscount(1, 1000);

            result.Should().Be(50);
            _mockCustomerService.Received().GetCustomerType(1);
        }

        [Fact(DisplayName = "10% Discount")]
        public void GetDiscount_PremiumCustomer_ReturnPriceWith10PercetOff()
        {
            _mockCustomerService.GetCustomerType(2).Returns(CustomerType.Premium);

            double result = _sut.GetDiscount(2, 1000);

            result.Should().Be(100);
            _mockCustomerService.Received().GetCustomerType(2);
        }
    }
}
