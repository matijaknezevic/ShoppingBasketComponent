using ShoppingBasketComponent.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingBasketComponent.Service
{
    internal class ProductService
    {
        //mocked product list (in real case scenarion products would be stored in database)
        private List<Product> _products = new List<Product>
        {
            new Product {
                ID = 1,
                Name = "Butter",
                UnitPrice = 0.80m
            },
             new Product {
                ID = 2,
                Name = "Milk",
                UnitPrice = 1.15m
            },
            new Product {
                ID = 3,
                Name = "Bread",
                UnitPrice = 1m
            }
        };

        /// <summary>
        /// Get product by product ID
        /// </summary>
        /// <param name="productID">productID</param>
        /// <returns>product with this ID</returns>
        internal Product GetProductByID(int productID)
        {
            var product = _products
                .Where(x => x.ID == productID)
                .Select(x => x)
                .FirstOrDefault();

            if (product == null)
            {
                var errorMsg = string.Format("product with productID {0} doesnt exist", productID);
                throw new Exception(errorMsg);
            }

            return product;
        }
    }
}