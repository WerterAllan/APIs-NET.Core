using Flunt.Notifications;
using Flunt.Validations;

namespace WerterStore.Domain.StoreContext.ValueObject
{
    public sealed class Email : Notifiable
    {
        public Email(string address)
        {
            Address = address;

            AddNotifications(new Contract()
                   .IsEmail(address, "Email", "O E-mail é inválido"));
        }

        public string Address { get; private set; }

        public override string ToString()
        {
            return Address;
        }
    }
}
