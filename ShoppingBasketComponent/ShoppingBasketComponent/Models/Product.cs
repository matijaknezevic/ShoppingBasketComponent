namespace ShoppingBasketComponent.Models
{
    internal class Product
    {
        /// <summary>
        /// ID
        /// </summary>
        internal int ID { get; set; }
        
        /// <summary>
        /// Name
        /// </summary>
        internal string Name { get; set; }

        /// <summary>
        /// Unit price
        /// </summary>
        internal decimal UnitPrice { get; set; }
    }
}