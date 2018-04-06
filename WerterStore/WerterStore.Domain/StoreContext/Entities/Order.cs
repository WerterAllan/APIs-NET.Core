using System;
using System.Collections.Generic;
using System.Text;

namespace WerterStore.Domain.StoreContext.Entities
{
    public class Order
    {
        public string Number { get; set; }
        public string CreateDate { get; set; }
        public string Status { get; set; }
        public IList<OrderItem> Items { get; set; }
        public IList<Delivery> Deliveries { get; set; }        

        public Order()
        {

        }
        
        public void Place()
        {

        }

        
    }
}
