namespace ShoppingBasketComponent.Models
{
    internal class Discount
    {
        /// <summary>
        /// Condition product ID
        /// </summary>
        internal int ConditionProductID { get; set; }

        /// <summary>
        /// Condition quantity
        /// </summary>
        internal int ConditionQuantity { get; set; }

        /// <summary>
        /// Discount product ID
        /// </summary>
        internal int DiscountProductID { get; set; }

        /// <summary>
        /// Discount percentage
        /// </summary>
        internal decimal DiscountPercentage { get; set; }
    }
}
