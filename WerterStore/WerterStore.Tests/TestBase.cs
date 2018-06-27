using Bogus;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using WerterStore.Domain.StoreContext.FluentBuilder;
using Bogus.Extensions.Brazil;
using WerterStore.Domain.StoreContext.Entities;

namespace WerterStore.Tests
{
    public abstract class TestBase
    {
        public const string Email_Fake = "werter@wertersa.com.br";
        public Faker Fake { get; }

        public TestBase()
        {
            Fake = new Faker("pt_BR");
        }
        public OrderBuilder MontarPedidoBasico()
        {
            return new OrderBuilder()
               .Name(Fake.Person.FirstName, Fake.Person.LastName)
               .Document(Fake.Person.Cpf())
               .Email(Fake.Person.Email)
               .Phone(Fake.Person.Phone);
        }

        public Product UmProdutoComEstoque(int quantidadeEmEstoque)
        {
            return new Product(Fake.Commerce.ProductName(), Fake.Lorem.Paragraph(1), "asdf", Fake.Random.Decimal(10, 4000), quantidadeEmEstoque);
        }

        public Order MontarUmPedidoSimples()
        {
            return MontarPedidoBasico()
                            .AddProduct(UmProdutoComEstoque(20), 5)
                            .Build();
        }

        public string ExtractNotifications<T>(T objetoNotificavel) where T : Notifiable
        {

            var descriptions = objetoNotificavel.Notifications
                .Select(x => $"Property: {x.Property} Message: {x.Message}")
                .ToList();

            var texto = string.Join("\n", descriptions);

            if (descriptions.Count > 0)
                Console.WriteLine(texto);

            return texto;
        }

        public static String GerarCpf()
        {
            int soma = 0, resto = 0;
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            Random rnd = new Random();
            string semente = rnd.Next(100000000, 999999999).ToString();

            for (int i = 0; i < 9; i++)
                soma += int.Parse(semente[i].ToString()) * multiplicador1[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            semente = semente + resto;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(semente[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            semente = semente + resto;
            return semente;
        }
    }
}