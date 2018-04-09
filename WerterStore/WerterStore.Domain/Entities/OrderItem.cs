using Flunt.Notifications;
using Flunt.Validations;

namespace WerterStore.Domain.StoreContext.Entities
{
    public class OrderItem : Notifiable
    {
        public OrderItem(Product product, decimal quantity)
        {
            Product = product;
            Quantity = quantity;
            Price = product.Price;

            AddNotifications(new Contract()
                .IsLowerThan(product.QuantityOnHand, Quantity, "Quantity", "Produto fora de estoque"));

        }

        public Product Product { get; private set; }
        public decimal Quantity { get; private set; }
        public decimal Price { get; private set; }
    }
}
