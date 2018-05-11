using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using WerterStore.Domain.StoreContext.Enums;
using WerterStore.Shared.Extensions;

namespace WerterStore.Domain.StoreContext.Entities
{
    public class Order : Notifiable
    {
        public Order(Customer customer)
        {
            Customer = customer;
            
            Status = EOrderStatus.Created;
            _items = new Queue<OrderItem>();
            _deliveries = new List<Delivery>();            

        }

        public Customer Customer { get; private set; }
        public string Number { get; private set; }
        public DateTime CreateDate { get; private set; }
        public EOrderStatus Status { get; private set; }

        private Queue<OrderItem> _items;
        //public IReadOnlyCollection<OrderItem> Items => _items.ToList(); 
        private IList<Delivery> _deliveries;
        public IReadOnlyCollection<Delivery> Deliveries => _deliveries.ToList();
      
        /// <summary>
        /// Cria um pedido
        /// </summary>
        public void Place()
        {
            Number = Guid.NewGuid()
                .ToString()
                .Replace("-", "")
                .Substring(0, 8)
                .ToUpper();

            AddNotifications(new Contract()
               .IsGreaterThan(_items.Count, 0, "Order", "Este pedido não possui itens"));

        }

        /// <summary>
        /// Pagar um pedido
        /// </summary>
        public void Pay()
        {
            Status = EOrderStatus.Paid;
            

        }
        public void Ship()
        {
            
            var packageForDelivery = _items.DequeueChunk(5);
            foreach (var item in packageForDelivery)
                AddDelivery(new Delivery(DateTime.Now.AddDays(5)));

            foreach (var delivery in _deliveries)
                delivery.Ship();            

        }

        public void AddItem(Product product, decimal quantity)
        {            
            AddNotifications(new Contract()
               .IsGreaterOrEqualsThan(product.QuantityOnHand, quantity, "Order", $"Produto {product.Title} não tem {quantity} itens em estoque."));

            this._items.Enqueue(new OrderItem(product, quantity));
        }

        public void AddDelivery(Delivery delivery)
        {
            this._deliveries.Add(delivery);
        }

        public void Cancel()
        {
            Status = EOrderStatus.Cancelad;
            foreach (var delivery in Deliveries)
                delivery.Cancel();
            
        }

        



    }
}
