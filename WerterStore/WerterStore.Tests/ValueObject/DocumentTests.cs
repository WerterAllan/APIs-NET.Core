using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using WerterStore.Domain.StoreContext.ValueObject;
using Bogus.Extensions.Brazil;

namespace WerterStore.Tests.ValueObject
{
    [TestClass]
    public class DocumentTests : TestBase
    {
        /// <summary>
        /// Deve retornar uma notificação para um documento 
        /// inválido
        /// </summary>
        [TestMethod]
        public void DocumentoInvalido()
        {
            var document = new Document("12345678900");
            document.Invalid.Should().BeTrue(ExtractNotifications(document));
        }

        /// <summary>
        /// Não deve retonar nenhuma notificação para um
        /// documento valido
        /// </summary>
        [TestMethod]
        public void DocumentoValido()
        {
            var document = new Document(Fake.Person.Cpf());
            document.Valid.Should().BeTrue(ExtractNotifications(document));
        }
    }
}
