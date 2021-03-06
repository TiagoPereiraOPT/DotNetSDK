﻿using System;
using System.Threading.Tasks;
using JudoPayDotNet.Models;
using NUnit.Framework;

namespace JudoPayDotNetIntegrationTests
{
    [TestFixture]
    public class RegisterCardTest : IntegrationTestsBase
    {

        [Test]
        public async Task RegisterCard()
        {

            var registerCardModel = GetCardPaymentModel("432438862");

            var response = await JudoPayApi.RegisterCards.Create(registerCardModel);

            Assert.IsNotNull(response);
            Assert.IsFalse(response.HasError);
            Assert.AreEqual("Success", response.Response.Result);
        }

        [Test]
        public async Task RegisterCardAndATokenPayment()
        {
            var consumerReference = Guid.NewGuid().ToString();

            var registerCard = GetCardPaymentModel(consumerReference);

            var response = await JudoPayApi.RegisterCards.Create(registerCard);

            Assert.IsNotNull(response);
            Assert.IsFalse(response.HasError);

            var receipt = response.Response as PaymentReceiptModel;

            Assert.IsNotNull(receipt);

            Assert.AreEqual("Success", receipt.Result);

            // Fetch the card token
            var cardToken = receipt.CardDetails.CardToken;

            var paymentWithToken = GetTokenPaymentModel(cardToken, consumerReference, 27);

            response = await JudoPayApi.Payments.Create(paymentWithToken);

            Assert.IsNotNull(response);
            Assert.IsFalse(response.HasError);
            Assert.AreEqual("Success", response.Response.Result);
        }

        [Test]
        public void ADeclinedCardPayment()
        {
            var registerCard = GetCardPaymentModel("432438862", "4221690000004963", "125");

            var response = JudoPayApi.RegisterCards.Create(registerCard).Result;

            Assert.IsNotNull(response);
            Assert.IsFalse(response.HasError);
            Assert.AreEqual("Declined", response.Response.Result);
        }
    }
}
