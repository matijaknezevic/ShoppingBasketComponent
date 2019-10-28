using System.Collections.Generic;

namespace ShoppingBasketComponent.Models
{
    public class Basket
    {
        /// <summary>
        /// Products
        /// </summary>
        internal List<BasketProduct> Products { get; set; }

        internal Basket()
        {
            Products = new List<BasketProduct>();
        }
    }
}