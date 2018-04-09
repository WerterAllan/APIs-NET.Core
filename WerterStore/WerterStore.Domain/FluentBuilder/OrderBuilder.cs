using System;
using System.Collections.Generic;
using WerterStore.Domain.StoreContext.Entities;
using WerterStore.Domain.ValueObject;

namespace WerterStore.Domain.FluentBuilder
{
    public sealed class OrderBuilder : FluentBuilderBase<Order>
    {
        private string _firstName;
        private string _lastName;
        private string _number;
        private string _addressEmail;
        private string _phone;        
        private List<Tuple<Product, int>> _orderItems;

        public OrderBuilder()
        {
            _orderItems = new List<Tuple<Product, int>>();

        }

        public OrderBuilder Name(string firstName, string lastName)
        {
            _firstName = firstName;
            _lastName = lastName;
            return this;
        }

        public OrderBuilder Document(string number)
        {
            _number = number;
            return this;
        }

        public OrderBuilder Email(string address)
        {
            _addressEmail = address;
            return this;    
        }

        public OrderBuilder Phone(string phone)
        {
            _phone = phone;
            return this;
        }

        public OrderBuilder AddProduct(string title, string description, string image, decimal price, int quantityOnHand, int quantity)
        {
            var product = new Product(title, description, image, price, quantityOnHand);
            _orderItems.Add(new Tuple<Product, int>(product, quantity));            
            return this;
        }

        public OrderBuilder AddProduct(Product product, int quantity)
        {            
            _orderItems.Add(new Tuple<Product, int>(product, quantity));
            return this;
        }

        public override Order Build()
        {
            var name = new Name(_firstName, _lastName);
            var document = new Document(_number);
            var email = new Email(_addressEmail);
            var customer = new Customer(name, document, email, _phone);
            var order = new Order(customer);

            foreach (var item in _orderItems)
                order.AddItem(item.Item1, item.Item2);
            

            return order;

        }
    }
}
