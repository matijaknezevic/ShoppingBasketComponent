using ShoppingBasketComponent;
using ShoppingBasketComponent.Models;
using Xunit;

namespace XUnitTests
{
    public class UnitTests
    {
        private ShoppingBasket sbComponent;
        private Basket basket;

        /// <summary>
        /// Scenario1: 1 bread, 1 butter, 1 milk
        /// </summary>
        [Fact]
        public void TestTotalPriceScenario1()
        {
            SetupTests();
            AddProductsToBasketHelper(sbComponent, basket, 1, 1);
            AddProductsToBasketHelper(sbComponent, basket, 2, 1);
            AddProductsToBasketHelper(sbComponent, basket, 3, 1);

            var totalPrice = sbComponent.GetTotalPrice(basket);
            var expectedResult = 2.95m;
            Assert.Equal(expectedResult, totalPrice);
        }

        /// <summary>
        /// Scenario2: 2 butter, 2 bread
        /// </summary>
        [Fact]
        public void TestTotalPriceScenario2()
        {
            SetupTests();
            AddProductsToBasketHelper(sbComponent, basket, 1, 2);
            AddProductsToBasketHelper(sbComponent, basket, 3, 2);

            var totalPrice = sbComponent.GetTotalPrice(basket);
            var expectedResult = 3.10m;
            Assert.Equal(expectedResult, totalPrice);
        }

        /// <summary>
        /// Scenario3: 4 milk
        /// </summary>
        [Fact]
        public void TestTotalPriceScenario3()
        {
            SetupTests();
            AddProductsToBasketHelper(sbComponent, basket, 2, 4);

            var totalPrice = sbComponent.GetTotalPrice(basket);
            var expectedResult = 3.45m;
            Assert.Equal(expectedResult, totalPrice);
        }

        /// <summary>
        /// Scenario1: 2 butter, 1 bread, 8 milk
        /// </summary>
        [Fact]
        public void TestTotalPriceScenario4()
        {
            SetupTests();
            AddProductsToBasketHelper(sbComponent, basket, 1, 2);
            AddProductsToBasketHelper(sbComponent, basket, 3, 1);
            AddProductsToBasketHelper(sbComponent, basket, 2, 8);

            var totalPrice = sbComponent.GetTotalPrice(basket);
            var expectedResult = 9m;
            Assert.Equal(expectedResult, totalPrice);
        }

        /// <summary>
        /// Setup tests
        /// </summary>
        private void SetupTests()
        {
            sbComponent = new ShoppingBasket();
            basket = sbComponent.CreateBasket();
        }

        /// <summary>
        /// Add products to basket
        /// </summary>
        /// <param name="sbComponent">Shopping basket Component</param>
        /// <param name="basket">basket</param>
        /// <param name="productID">productID</param>
        /// <param name="quantity">quantity</param>
        private void AddProductsToBasketHelper(ShoppingBasket sbComponent, Basket basket, int productID, int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                sbComponent.AddProduct(basket, productID);
            }
        }
    }
}
