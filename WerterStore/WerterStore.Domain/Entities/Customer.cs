using System;
using System.Collections.Generic;
using WerterStore.Domain.Entities;
using WerterStore.Domain.ValueObject;

namespace WerterStore.Domain.StoreContext.Entities
{
    public class Customer
    {
        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public string Phone { get; private set; }
        
        public IReadOnlyCollection<Address> Addresses { get; private set; }

        public Customer(Name name, Document document, Email  email, string phone)
        {
            this.Name = name;
            this.Document = document;
            this.Email = email;
            this.Phone = phone;
            this.Addresses = new List<Address>();
        }

        


    }
}
