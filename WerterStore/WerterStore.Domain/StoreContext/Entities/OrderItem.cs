﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WerterStore.Domain.StoreContext.Entities
{
    public class OrderItem
    {
        public Product Product { get; set; }
        public string Quantity { get; set; }
        public string Price { get; set; }
    }
}