using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WerterStore.Domain.StoreContext.ValueObject;

namespace WerterStore.Tests.ValueObject
{
    [TestClass]
    public sealed class NameTests : TestBase
    {
        [TestMethod]
        public void NomeValido()
        {
            var nome = new Name("Werter", "Bonfim");
            nome.Valid.Should().BeTrue(ExtractNotifications(nome));
        }

        [TestMethod]
        public void NomeInvalido()
        {
            var nome = new Name("", "falso");
            nome.Invalid.Should().BeTrue(ExtractNotifications(nome));
        }
    }
}
