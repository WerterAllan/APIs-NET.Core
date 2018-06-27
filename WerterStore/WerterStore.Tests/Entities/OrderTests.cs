using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WerterStore.Domain.StoreContext.Entities;
using WerterStore.Domain.StoreContext.Enums;

namespace WerterStore.Tests.Entities
{
    [TestClass]
    public class OrderTests : TestBase
    {
        /// <summary>
        /// Deve criar um pedido quando ele for valido
        /// </summary>
        [TestMethod]
        public void CriarUmNovoPedido()
        {
            var order = MontarPedidoBasico()
                .Build();

            order.Valid.Should().BeTrue(ExtractNotifications(order));

        }

        [TestMethod]
        public void OStatusDeveSerCreatedAoCriarUmPedido()
        {
            var order = MontarPedidoBasico()
                .Build();

            EOrderStatus.Created.Should().BeEquivalentTo(order.Status, ExtractNotifications(order));
        }

        // Ao adicionar um novo item, a quantidade de itens deve mudar. ??????        
        [TestMethod]
        public void DeveConterAMesmaQuantidadeDeItens()
        {
            var order = MontarPedidoBasico()
                .AddProduct(UmProdutoComEstoque(10), 5)
                .AddProduct(UmProdutoComEstoque(10), 5)
                .Build();

            order.Items.Count.Should().Be(2, ExtractNotifications(order));
        }

        [TestMethod]
        public void QuantidadeDeProdutosEmEstoqueDeveDiminuirACadaItemAdicionado()
        {
            var produto = UmProdutoComEstoque(10);
            var order = MontarPedidoBasico()
               .AddProduct(produto, 5)               
               .Build();

            produto.QuantityOnHand.Should().Be(5, "Tenho 10 produtos em estoque, comprei 5 devo ter 5 em estoque");

        }

        [TestMethod]
        public void DeveGerarUmNumeroDePedidoQuandoEleForConfirmado()
        {
            Order order = MontarUmPedidoSimples();

            order.Place();
            order.Number.Should().NotBeNullOrEmpty();
        }

        

        [TestMethod]
        public void AoPagarUmPedidoEsteDeveTerOStatusPaid()
        {
            var order = MontarUmPedidoSimples();
            order.Place();
            order.Pay();
            order.Status.Should().BeEquivalentTo(EOrderStatus.Paid, ExtractNotifications(order));
            
        }

        [TestMethod]
        public void OPagamentoNaoPodeSerEfetuaSeNaoForGeradoUmNumeroDePedido()
        {
            var order = MontarUmPedidoSimples();
            
            order.Pay();
            order.Invalid.Should().BeTrue(ExtractNotifications(order));

        }


        [TestMethod]
        public void Dados10ProdutoDeveHaverDuasEntregas()
        {
            var order = MontarPedidoBasico()
               .AddProduct(UmProdutoComEstoque(10), 1)
               .AddProduct(UmProdutoComEstoque(10), 1)
               .AddProduct(UmProdutoComEstoque(10), 1)
               .AddProduct(UmProdutoComEstoque(10), 1)
               .AddProduct(UmProdutoComEstoque(10), 1)
               .AddProduct(UmProdutoComEstoque(10), 1)
               .AddProduct(UmProdutoComEstoque(10), 1)
               .AddProduct(UmProdutoComEstoque(10), 1)
               .AddProduct(UmProdutoComEstoque(10), 1)
               .AddProduct(UmProdutoComEstoque(10), 1)
               .Build();

            order.Place();
            order.Pay();
            order.Ship();
            order.Deliveries.Count.Should().Be(2);
        }

        [TestMethod]
        public void AoCancelarOPedidoOStatusDeveSerCancelado()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void AoCancelarOPedidoOStatusDesteDeveSerCancelado()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void AoCancelarOPedidoEsteDeveCancelarAsEntregas()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void QuantidadeDeProdutosEmEstoqueDeveSerDevolvidaQuandoUmPedidoForCancelado()
        {
            var produto = UmProdutoComEstoque(10);
            var order = MontarPedidoBasico()
               .AddProduct(produto, 5)
               .Build();

            order.Cancel();

            produto.QuantityOnHand.Should().Be(10, "Tenho um estoque com 10 produto. comprei 5 itens, porem cancelei o pedido. devo ter 10 produtos em estoque novamente");            

        }



    }
}
