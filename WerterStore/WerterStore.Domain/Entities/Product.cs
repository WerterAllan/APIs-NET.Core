using System;
using System.Collections.Generic;
using System.Text;

namespace WerterStore.Domain.StoreContext.Entities
{
    public class Product
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Image { get; private set; }
        public decimal Price { get; private set; }
        public string QuantityOnHand { get; private set; }
        

        public Product(string title, string description, string image, decimal price, string quantityOnHand)
        {
            Title = title;
            Description = description;
            Image = image;
            Price = price;
            QuantityOnHand = quantityOnHand;
        }

        public override string ToString()
        {
            return Title;
        }
    }
}
