using btg_testes_auto.CartDiscount;
using FluentAssertions;
using NSubstitute;

namespace btg_test.CartDiscountTest
{
    public class CartDiscountServiceTest
    {
        private readonly IDiscountService _mockDiscountService;
        private readonly CartService _sut;

        public CartDiscountServiceTest()
        {
            _mockDiscountService = Substitute.For<IDiscountService>();
            _sut = new CartService(_mockDiscountService);
        }

        [Fact(DisplayName = "Discount value")]
        public void CalculateTotalWithDiscount_CartPrice100_ReturnPriceValue()
        {
            CartItem cartItem = new CartItem()
            {
                ProductId = "01",
                Price = 100
            };

            List<CartItem> cartItems = new() { cartItem, cartItem, cartItem, cartItem };

            _mockDiscountService.CalculateDiscount(cartItems).Returns(40);

            double result = _sut.CalculateTotalWithDiscount(cartItems);

            result.Should().Be(360);
            _mockDiscountService.Received().CalculateDiscount(cartItems);
        }
    }
}
