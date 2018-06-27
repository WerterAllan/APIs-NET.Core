using System;
using System.Collections;
using System.Collections.Generic;
using WerterStore.Domain.StoreContext.Enums;

namespace WerterStore.Domain.StoreContext.Entities
{
    public class Delivery
    {
        public DateTime CreateDate { get; private set; }
        public DateTime EstimatedDeliveryDate { get; private set; }
        public EDeliveryStatus Status { get; private set; }

        public IList<OrderItem> Itens { get; private set; }


        public Delivery(DateTime estimatedDeliveryDate, IList<OrderItem> itens)
        {
            CreateDate = DateTime.Now;
            EstimatedDeliveryDate = estimatedDeliveryDate;
            Status = EDeliveryStatus.Waiting;
            Itens = itens;
        }

        public void Ship()
        {
            Status = EDeliveryStatus.Shipped;

        }

        public void Cancel()
        {
            // 
        }
    }
}
