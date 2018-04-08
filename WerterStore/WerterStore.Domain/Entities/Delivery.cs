using System;
using WerterStore.Domain.StoreContext.Enums;

namespace WerterStore.Domain.StoreContext.Entities
{
    public class Delivery
    {
        public DateTime CreateDate { get; private set; }
        public DateTime EstimatedDeliveryDate { get; private set; }
        public EDeliveryStatus Status { get; private set; }

        public Delivery(DateTime estimatedDeliveryDAte)
        {
            CreateDate = DateTime.Now;
            EstimatedDeliveryDate = estimatedDeliveryDAte;
            Status = EDeliveryStatus.Waiting;
        }
    }
}
