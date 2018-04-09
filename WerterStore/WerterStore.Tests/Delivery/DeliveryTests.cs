using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WerterStore.Domain.FluentBuilder;
using WerterStore.Domain.StoreContext.Entities;

namespace WerterStore.Tests.Delivery
{
    [TestClass]
    public class DeliveryTests : TestBase
    {

        private OrderBuilder MontarPedidoBasico()
        {
            return new OrderBuilder()
               .Name("Werter", "Bonfim")
               .Document("12345678900")
               .Email("hello@wertersa.io")
               .Phone("11999995309");
        }

        private Product UmProdutoComEstoque(int quantidadeEmEstoque)
        {
            return new Product("produto qualquer", "descrição", "asdf", 10, quantidadeEmEstoque);
        }

        [TestMethod]
        public void PedidoSemItens_DeveRetornarUmaNotificacao()
        {
            var order = MontarPedidoBasico()
                .Build();
            order.Invalid.Should().BeTrue(ExtractNotifications(order.Notifications));
        }


        [TestMethod]
        public void Teste1()
        {
            var order = MontarPedidoBasico()
                .AddProduct("Gigabyte GA-H97N-WIFI", "placa-mãe da Gigabyte", "image.png", 652.9M, 1, 1)
                .AddProduct("Intel Core i7-7700", "Processador Intel Core i7-7700 Kaby Lake 7a Geração, Cache 8MB, 3.6GHz (4.2GHz Max Turbo), LGA 1151 Intel HD Graphics BX80677I77700", "image.png", 1359.9M, 1, 1)
                .AddProduct("Memória Kingston HyperX Predator ", "Memória Kingston HyperX Predator 16GB (2x8GB) 3000Mhz DDR4 CL15 - HX430C15PB3K2/16", "image.png", 1199.9M, 1, 1)
                .Build();

            // Realiza o pedido
            order.Place();

            // Simula o pagamento
            order.Pay();

            // Simula o envio
            order.Ship();

            // Simula o cancelamento
            order.Cancel();

        }

        [TestMethod]
        public void PedidoComMaisItensQueOEstoque_DeveRetornarUmaNotificação()
        {

            var pedido = MontarPedidoBasico()
                .AddProduct(UmProdutoComEstoque(10), 20)
                .Build();

            pedido.Invalid.Should().BeTrue(ExtractNotifications(pedido.Notifications));

            
        }
    }
}
