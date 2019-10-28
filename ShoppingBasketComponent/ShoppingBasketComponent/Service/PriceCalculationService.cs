using ShoppingBasketComponent.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingBasketComponent.Service
{
    internal class PriceCalculationService
    {
        //mocked discount list (in real case scenarion discounts would be stored in database)
        private List<Discount> _discounts = new List<Discount>
        {
            new Discount {
                ConditionProductID = 1,
                ConditionQuantity = 2,
                DiscountProductID = 3,
                DiscountPercentage = 0.5m
            },
             new Discount {
                ConditionProductID = 2,
                ConditionQuantity = 3,
                DiscountProductID = 2,
                DiscountPercentage = 0m
            }
        };

        /// <summary>
        /// Get total price of products in shopping basket
        /// </summary>
        /// <param name="basket">basket</param>
        /// <returns>total price of products in shopping basket</returns>
        internal decimal GetBasketTotalPrice(Basket basket)
        {
            if (basket == null)
            {
                var errorMsg = "basket doesnt exists";
                throw new Exception(errorMsg);
            }

            var totalPrice = basket.Products
                .Sum(x => x.Product.UnitPrice * x.Quantity);

            return totalPrice;
        }

        /// <summary>
        /// Get discount of products in shopping basket
        /// </summary>
        /// <param name="basket">basket</param>
        /// <returns>total discount of products in shopping basket</returns>
        internal decimal GetBasketDiscount(Basket basket)
        {
            if (basket == null)
            {
                var errorMsg = "basket doesnt exists";
                throw new Exception(errorMsg);
            }

            var tempBasket = new Basket
            {
                Products = basket.Products.Select(x => new BasketProduct
                {
                    Product = x.Product,
                    ProductID = x.ProductID,
                    Quantity = x.Quantity
                }).ToList()
             };

            var discountAmount = 0m;
            var discountCalculationActive = true;
            while (discountCalculationActive)
            {
                discountCalculationActive = false;
                foreach (var discount in _discounts)
                {
                    var conditionProduct = tempBasket.Products
                        .Where(x => x.ProductID == discount.ConditionProductID)
                        .FirstOrDefault();

                    if (conditionProduct == null)
                        continue;

                    if (conditionProduct.Quantity < discount.ConditionQuantity)
                        continue;

                    var discountProduct = tempBasket.Products
                        .Where(x => x.ProductID == discount.DiscountProductID)
                        .FirstOrDefault();

                    if (discountProduct == null)
                        continue;

                    var productUnitPrice = discountProduct.Product.UnitPrice;
                    var productPriceOnDiscount = productUnitPrice * discount.DiscountPercentage;
                    discountAmount += (productUnitPrice - productPriceOnDiscount);

                    discountCalculationActive = true;
                    conditionProduct.Quantity -= discount.ConditionQuantity;
                    discountProduct.Quantity--;
                }
            }

            return discountAmount;
        }
    }
}