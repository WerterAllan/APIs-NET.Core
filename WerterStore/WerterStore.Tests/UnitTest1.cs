using FluentAssertions;
using Flunt.Notifications;
using Flunt.Validations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WerterStore.Domain.StoreContext.Entities;

namespace WerterStore.Tests
{
    public class Testes : Notifiable
    {
        public Testes()
        {
            AddNotifications(new Contract()               
               .AreNotEquals(0, 0, "0", "AreNotEquals"));

            AddNotifications(new Contract()
               .IsGreaterThan(3, 10, "quantidade", "IsGreaterThan - 10 é maior que 3")
               .AreEquals(0, 0, "0", "AreEquals"));
        }
    }

    [TestClass]
    public class UnitTest1 : TestBase
    {
        [TestMethod]
        public void Rascunho()
        {
            var teste = new Testes();
            teste.Invalid.Should().BeTrue(ExtractNotifications(teste.Notifications));
        }
    }
}
