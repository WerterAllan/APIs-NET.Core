using Flunt.Notifications;
using Flunt.Validations;

namespace WerterStore.Domain.ValueObject
{
    public sealed class Name : Notifiable
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            var camposForamPreenchidos = 
                !string.IsNullOrEmpty(firstName) &&
                !string.IsNullOrEmpty(lastName);
           
            if (camposForamPreenchidos)
            {
                AddNotifications(new Contract()
                   .HasMinLen(firstName, 3, "FirstName", "Nome é um campo obrigatório")
                   .HasMaxLen(lastName, 30, "FirstName", "Nome é um campo obrigatório")
                   .HasMinLen(lastName, 3, "FirstName", "Nome é um campo obrigatório")
                   .HasMaxLen(firstName, 3, "FirstName", "Nome é um campo obrigatório"));

            }
            



            if (string.IsNullOrEmpty(firstName))
                AddNotification("FistName", "Nome é um campo obrigatório");

            if (string.IsNullOrEmpty(lastName))
                AddNotification("LastName", "Sobrenome é um campo obrigatório");
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
