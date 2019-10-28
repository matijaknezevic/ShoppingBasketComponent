using ShoppingBasketComponent.Models;
using ShoppingBasketComponent.Service;
using System;
using System.Linq;

namespace ShoppingBasketComponent
{
    public class ShoppingBasket : IShoppingBasket
    {
        private ProductService _productService;
        private PriceCalculationService _priceCalculationService;
        private LogService _logService;

        public ShoppingBasket()
        {
            _productService = new ProductService();
            _priceCalculationService = new PriceCalculationService();
            _logService = new LogService();
        }

        /// <summary>
        /// Create shopping basket
        /// </summary>
        /// <returns>basket</returns>
        public Basket CreateBasket()
        {
            var basket = new Basket();
            return basket;
        }

        /// <summary>
        /// Add product with this product ID to shopping basket
        /// </summary>
        /// <param name="basket">basket</param>
        /// <param name="productID">product ID</param>
        public void AddProduct(Basket basket, int productID)
        {
            if (basket == null)
            { 
                var errorMsg = "basket doesnt exists";
                throw new Exception(errorMsg);
            }            

            var product = _productService.GetProductByID(productID);
            var basketContainsProduct = basket.Products
                .Any(x => x.ProductID == productID);

            if (basketContainsProduct)
            {
                ChangeBasketProductQuantity(basket, productID, 1);
            }
            else
            {
                basket.Products.Add(new BasketProduct{
                        ProductID = productID,
                        Product = product
                });
            }
        }

        /// <summary>
        /// Remove product with this product ID from shopping basket
        /// </summary>
        /// <param name="basket">basket</param>
        /// <param name="productID">product ID</param>
        public void RemoveProduct(Basket basket, int productID)
        {
            if (basket == null)
            {
                var errorMsg = "basket doesnt exists";
                throw new Exception(errorMsg);
            }

            var basketContainsManyProducts = basket.Products
                .Any(x => x.ProductID == productID && x.Quantity > 1);

            if (basketContainsManyProducts)
            {
                ChangeBasketProductQuantity(basket, productID, -1);
            }
            else
            {
                basket.Products.RemoveAll(x => x.ProductID == productID);
            }
        }

        /// <summary>
        /// Get total price of products in shopping basket
        /// </summary>
        /// <param name="basket">basket</param>
        /// <returns>total price of products in shopping basket</returns>
        public decimal GetTotalPrice(Basket basket)
        {
            var totalPriceWithoutDiscount = _priceCalculationService.GetBasketTotalPrice(basket);
            var discount = _priceCalculationService.GetBasketDiscount(basket);
            var totalPrice = totalPriceWithoutDiscount - discount;

            var productIDs = string.Join(",", basket.Products.Select(x => x.ProductID).ToArray());
            var logMessage = string.Format("Total price requested at {0};productIDs {1};discount {2}$;total {3}$;",
                DateTime.Now, productIDs, discount, totalPrice);
            _logService.InsertLog(logMessage);

            return totalPrice;
        }

        /// <summary>
        /// Change quantity of this product in shopping basket
        /// </summary>
        /// <param name="basket">basket</param>
        /// <param name="productID">product ID</param>
        /// <param name="quantityDifference">quantity difference</param>
        private void ChangeBasketProductQuantity(Basket basket, int productID, int quantityDifference)
        {
            var basketProduct = basket.Products
                .Where(x => x.ProductID == productID)
                .FirstOrDefault();

            if (basketProduct == null)
            {
                var errorMsg = string.Format("basket product with productID {0} doesnt exist", productID);
                throw new Exception(errorMsg);
            }

            basketProduct.Quantity += quantityDifference;
        }
    }
}