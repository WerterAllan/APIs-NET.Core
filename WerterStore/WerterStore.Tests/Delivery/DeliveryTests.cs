﻿using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WerterStore.Domain.FluentBuilder;
using WerterStore.Domain.StoreContext.Entities;
using Bogus.Extensions.Brazil;

namespace WerterStore.Tests.Delivery
{
    [TestClass]
    public class DeliveryTests : TestBase
    {

        private OrderBuilder MontarPedidoBasico()
        {
            return new OrderBuilder()
               .Name( Fake.Person.FirstName , Fake.Person.LastName)               
               .Document(Fake.Person.Cpf())
               .Email(Fake.Person.Email)
               .Phone(Fake.Person.Phone);
        }

        private Product UmProdutoComEstoque(int quantidadeEmEstoque)
        {
            return new Product(Fake.Commerce.ProductName(), Fake.Lorem.Paragraph(1) , "asdf", Fake.Random.Decimal(10, 4000), quantidadeEmEstoque);
        }

        /// <summary>
        /// Deve retornar esta notificação: 'Este pedido não possui itens'
        /// </summary>
        [TestMethod]
        public void PedidoSemItens_DeveRetornarUmaNotificacao()
        {
            var order = MontarPedidoBasico()
                .Build();
            order.Place();
            order.Invalid.Should().BeTrue(ExtractNotifications(order.Notifications));
        }

        /// <summary>
        /// Um pedido com 3 produtos, com um item de cada produto,
        /// cada produto tem 1 item em estoque. deve realizar o pedido
        /// com sucesso
        /// </summary>
        [TestMethod]
        public void RealizarUmPedido()
        {
            var order = MontarPedidoBasico()
                .AddProduct("Gigabyte GA-H97N-WIFI", "placa-mãe da Gigabyte", "image.png", 652.9M, 1, 1)
                .AddProduct("Intel Core i7-7700", "Processador Intel Core i7-7700 Kaby Lake 7a Geração, Cache 8MB, 3.6GHz (4.2GHz Max Turbo), LGA 1151 Intel HD Graphics BX80677I77700", "image.png", 1359.9M, 1, 1)
                .AddProduct("Memória Kingston HyperX Predator ", "Memória Kingston HyperX Predator 16GB (2x8GB) 3000Mhz DDR4 CL15 - HX430C15PB3K2/16", "image.png", 1199.9M, 1, 1)
                .Build();

            // Realiza o pedido
            order.Place();

            order.Valid.Should().BeTrue(ExtractNotifications(order.Notifications));


        }



        [TestMethod]
        public void PedidoComMaisItensQueOEstoque()
        {

            var pedido = MontarPedidoBasico()
                .AddProduct(UmProdutoComEstoque(10), 20)
                .Build();

            pedido.Invalid.Should().BeTrue(ExtractNotifications(pedido.Notifications));
            
        }

        [TestMethod]
        public void PedidoEfetuadoComSucesso()
        {
            var pedido = MontarPedidoBasico()
                .AddProduct(UmProdutoComEstoque(20), 10)
                .Build();

            // Realiza o pedido
            pedido.Place();            
            

            pedido.Valid.Should().BeTrue(ExtractNotifications(pedido.Notifications));

        }
    }
}
