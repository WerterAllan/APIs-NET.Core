using Flunt.Notifications;
using Flunt.Validations;

namespace WerterStore.Domain.StoreContext.ValueObject
{
    public sealed class Name : Notifiable
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            if (string.IsNullOrEmpty(firstName))
                AddNotification("FistName", "Nome é um campo obrigatório");

            if (string.IsNullOrEmpty(lastName))
                AddNotification("LastName", "Sobrenome é um campo obrigatório");

            var camposNaoForamPreenchidos =
                string.IsNullOrEmpty(firstName) &&
                string.IsNullOrEmpty(lastName);

            if (camposNaoForamPreenchidos)
                return;

            AddNotifications(new Contract()
               .HasMinLen(firstName, 3, "FirstName", "O nome deve ter mais de 3 caracteres")
               .HasMaxLen(firstName, 30, "FirstName", "O nome tem mais de 30 caracteres")
               .HasMinLen(lastName, 0, "LastName", "O sobre nome deve conter mais de 1 caractere ")
               .HasMaxLen(lastName, 30, "LastName", "O sobre nome não pode ter mais de 30 caracteres"));

        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
