using Flunt.Notifications;
using System.Collections.Generic;
using System.Linq;
using WerterStore.Domain.StoreContext.ValueObject;

namespace WerterStore.Domain.StoreContext.Entities
{
    public class Customer : Notifiable
    {
        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public string Phone { get; private set; }

        private readonly IList<Address> _address;
        public IReadOnlyCollection<Address> Addresses => _address.ToList();

        public Customer(Name name, Document document, Email email, string phone)
        {
            this.Name = name;
            this.Document = document;
            this.Email = email;
            this.Phone = phone;
            this._address = new List<Address>();
        }

        public void AddAddress(Address address)
        {

        }




    }
}
