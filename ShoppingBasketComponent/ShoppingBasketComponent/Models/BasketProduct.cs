namespace ShoppingBasketComponent.Models
{
    internal class BasketProduct
    {
        /// <summary>
        /// Product ID
        /// </summary>
        internal int ProductID { get; set; }

        /// <summary>
        /// Product
        /// </summary>
        internal Product Product { get; set; }

        /// <summary>
        /// Quantity
        /// </summary>
        internal int Quantity { get; set; }

        internal BasketProduct()
        {
            Quantity = 1;
        }
    }
}