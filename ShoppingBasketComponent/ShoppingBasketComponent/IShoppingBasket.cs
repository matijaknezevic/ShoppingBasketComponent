using ShoppingBasketComponent.Models;

namespace ShoppingBasketComponent
{
    public interface IShoppingBasket
    {
        /// <summary>
        /// Create shopping basket
        /// </summary>
        /// <returns></returns>
        Basket CreateBasket();

        /// <summary>
        /// Add product with this product ID to shopping basket
        /// </summary>
        /// <param name="basket">basket</param>
        /// <param name="productID">product ID</param>
        void AddProduct(Basket basket, int productID);

        /// <summary>
        /// Remove product with this product ID from shopping basket
        /// </summary>
        /// <param name="basket">basket</param>
        /// <param name="productID">product ID</param>
        void RemoveProduct(Basket basket, int productID);

        /// <summary>
        /// Get total price of products in shopping basket
        /// </summary>
        /// <param name="basket">basket</param>
        /// <returns>total price of products in shopping basket</returns>
        decimal GetTotalPrice(Basket basket);
    }
}