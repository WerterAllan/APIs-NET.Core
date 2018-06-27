using Flunt.Notifications;
using Flunt.Validations;

namespace WerterStore.Domain.StoreContext.Entities
{
    public class OrderItem : Notifiable
    {
        public OrderItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
            Price = product.Price;
            product.RemoveFromStock(quantity);

            AddNotifications(new Contract()
                .IsLowerThan(product.QuantityOnHand, Quantity, "Quantity", "Produto fora de estoque"));



        }

        public Product Product { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }
    }
}
