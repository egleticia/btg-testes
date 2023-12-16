using btg_testes_auto.ShippingCost;
using FluentAssertions;
using NSubstitute;

namespace btg_test.ShippingCostTest
{
    public class ShippingServiceTest
    {
        private readonly IDeliveryCostCalculator _mockDeliveryCostCalculator;
        private readonly ShippingService _sut;

        public ShippingServiceTest()
        {
            _mockDeliveryCostCalculator = Substitute.For<IDeliveryCostCalculator>();
            _sut = new ShippingService(_mockDeliveryCostCalculator);
        }

        [Fact(DisplayName = "Regular type and less than 200km")]
        public void CalculateShippingCost_LessThan200kmRegularTypeOfDelivery_ReturnRegularCost()
        {
            var cost = _mockDeliveryCostCalculator.CalculateCost(100, DeliveryType.Ordinary).Returns(1000);

            double result = _sut.CalculateShippingCost(100, DeliveryType.Ordinary);

            result.Should().Be(1000);
            _mockDeliveryCostCalculator.Received().CalculateCost(100, DeliveryType.Ordinary);
        }

        [Fact(DisplayName = "Regular type and greater than 200km")]
        public void CalculateShippingCost_GreaterThan200kmRegularTypeOfDelivery_ReturnRegularCost()
        {
            var cost = _mockDeliveryCostCalculator.CalculateCost(300, DeliveryType.Ordinary).Returns(1000);

            double result = _sut.CalculateShippingCost(300, DeliveryType.Ordinary);

            result.Should().Be(1000);
            _mockDeliveryCostCalculator.Received().CalculateCost(300, DeliveryType.Ordinary);
        }

        [Fact(DisplayName = "Express type and less than 200km")]
        public void CalculateShippingCost_LessThan200kmExpressTypeOfDelivery_ReturnRegularCost()
        {
            var cost = _mockDeliveryCostCalculator.CalculateCost(100, DeliveryType.Express).Returns(1000);

            double result = _sut.CalculateShippingCost(100, DeliveryType.Express);

            result.Should().Be(1000);
            _mockDeliveryCostCalculator.Received().CalculateCost(100, DeliveryType.Express);
        }

        [Fact(DisplayName = "Express type and greater than 200km")]
        public void CalculateShippingCost_GreaterThan200kmExpressTypeOfDelivery_ReturnCostWithDiscount()
        {
            var cost = _mockDeliveryCostCalculator.CalculateCost(300, DeliveryType.Express).Returns(1000);

            double result = _sut.CalculateShippingCost(300, DeliveryType.Express);

            result.Should().Be(500);
            _mockDeliveryCostCalculator.Received().CalculateCost(300, DeliveryType.Express);
        }

    }
}
