﻿using System.Globalization;
using System.Linq;
using JudoPayDotNet;
using JudoPayDotNet.Models;
using JudoPayDotNetDotNet;
using NUnit.Framework;

namespace JudoPayDotNetIntegrationTests
{
    [TestFixture]
    public class ConsumersTests
    {
        private JudoPayApi _judo;

        [TestFixtureSetUp]
        public void SetupOnce()
        {
            _judo = JudoPaymentsFactory.Create(Configuration.Token,
                Configuration.Secret,
                Configuration.Baseaddress);
        }

        [Test]
        public void GetTransaction()
        {
            var paymentWithCard = new CardPaymentModel
            {
                JudoId = Configuration.Judoid,
                YourPaymentReference = "578543",
                YourConsumerReference = "432438862",
                Amount = 25,
                CardNumber = "4976000000003436",
                CV2 = "452",
                ExpiryDate = "12/15",
                CardAddress = new CardAddressModel
                {
                    Line1 = "Test Street",
                    PostCode = "W40 9AU",
                    Town = "Town"
                }
            };

            var response = _judo.Payments.Create(paymentWithCard).Result;

            Assert.IsNotNull(response);
            Assert.IsFalse(response.HasError);
            Assert.AreEqual("Success", response.Response.Result);

            var paymentReceipt = response.Response as PaymentReceiptModel;

            Assert.IsNotNull(paymentReceipt);

            var transactions = _judo.Consumers.GetTransactions(paymentReceipt.Consumer.ConsumerToken).Result;

            Assert.IsNotNull(transactions);
            Assert.IsFalse(transactions.HasError);
            Assert.IsNotEmpty(transactions.Response.Results);
// ReSharper disable once PossibleNullReferenceException
            Assert.AreEqual(Configuration.Judoid, transactions.Response.Results.FirstOrDefault().JudoId.ToString(CultureInfo.InvariantCulture));
// ReSharper disable once PossibleNullReferenceException
            Assert.AreEqual(response.Response.ReceiptId, transactions.Response.Results.FirstOrDefault().ReceiptId);
        }

        [Test]
        public void GetPaymentTransactions()
        {
            var paymentWithCard = new CardPaymentModel
            {
                JudoId = Configuration.Judoid,
                YourPaymentReference = "578543",
                YourConsumerReference = "432438862",
                Amount = 25,
                CardNumber = "4976000000003436",
                CV2 = "452",
                ExpiryDate = "12/15",
                CardAddress = new CardAddressModel
                {
                    Line1 = "Test Street",
                    PostCode = "W40 9AU",
                    Town = "Town"
                }
            };

            var response = _judo.Payments.Create(paymentWithCard).Result;

            Assert.IsNotNull(response);
            Assert.IsFalse(response.HasError);
            Assert.AreEqual("Success", response.Response.Result);

            var paymentReceipt = response.Response as PaymentReceiptModel;

            Assert.IsNotNull(paymentReceipt);

            var transactions = _judo.Consumers.GetPayments(paymentReceipt.Consumer.ConsumerToken).Result;

            Assert.IsNotNull(transactions);
            Assert.IsFalse(transactions.HasError);
            Assert.IsNotEmpty(transactions.Response.Results);
// ReSharper disable once PossibleNullReferenceException
            Assert.AreEqual(Configuration.Judoid, transactions.Response.Results.FirstOrDefault().JudoId.ToString(CultureInfo.InvariantCulture));
// ReSharper disable once PossibleNullReferenceException
            Assert.AreEqual(response.Response.ReceiptId, transactions.Response.Results.FirstOrDefault().ReceiptId);
        }

        [Test]
        public void GetPreAuthTransactions()
        {
            var paymentWithCard = new CardPaymentModel
            {
                JudoId = Configuration.Judoid,
                YourPaymentReference = "578543",
                YourConsumerReference = "432438862",
                Amount = 25,
                CardNumber = "4976000000003436",
                CV2 = "452",
                ExpiryDate = "12/15",
                CardAddress = new CardAddressModel
                {
                    Line1 = "Test Street",
                    PostCode = "W40 9AU",
                    Town = "Town"
                }
            };

            var response = _judo.PreAuths.Create(paymentWithCard).Result;

            Assert.IsNotNull(response);
            Assert.IsFalse(response.HasError);
            Assert.AreEqual("Success", response.Response.Result);

            var paymentReceipt = response.Response as PaymentReceiptModel;

            Assert.IsNotNull(paymentReceipt);

            var transactions = _judo.Consumers.GetPreAuths(paymentReceipt.Consumer.ConsumerToken).Result;

            Assert.IsNotNull(transactions);
            Assert.IsFalse(transactions.HasError);
            Assert.IsNotEmpty(transactions.Response.Results);
// ReSharper disable once PossibleNullReferenceException
            Assert.AreEqual(Configuration.Judoid, transactions.Response.Results.FirstOrDefault().JudoId.ToString(CultureInfo.InvariantCulture));
// ReSharper disable once PossibleNullReferenceException
            Assert.AreEqual(response.Response.ReceiptId, transactions.Response.Results.FirstOrDefault().ReceiptId);
        }

        [Test]
        public void GetCollectionsTransactions()
        {
            var paymentWithCard = new CardPaymentModel
            {
                JudoId = Configuration.Judoid,
                YourPaymentReference = "578543",
                YourConsumerReference = "432438862",
                Amount = 25,
                CardNumber = "4976000000003436",
                CV2 = "452",
                ExpiryDate = "12/15",
                CardAddress = new CardAddressModel
                {
                    Line1 = "Test Street",
                    PostCode = "W40 9AU",
                    Town = "Town"
                }
            };

            var response = _judo.PreAuths.Create(paymentWithCard).Result;

            Assert.IsNotNull(response);
            Assert.IsFalse(response.HasError);
            Assert.AreEqual("Success", response.Response.Result);

            var collection = new CollectionModel
            {
                Amount = 25,
                ReceiptId = int.Parse(response.Response.ReceiptId),
                YourPaymentReference = "578543"
            };

            response = _judo.Collections.Create(collection).Result;

            Assert.IsNotNull(response);
            Assert.IsFalse(response.HasError);
            Assert.AreEqual("Success", response.Response.Result);

            var paymentReceipt = response.Response as PaymentReceiptModel;

            Assert.IsNotNull(paymentReceipt);

            var transactions = _judo.Consumers.GetCollections(paymentReceipt.Consumer.ConsumerToken).Result;

            Assert.IsNotNull(transactions);
            Assert.IsFalse(transactions.HasError);
            Assert.IsNotEmpty(transactions.Response.Results);
// ReSharper disable once PossibleNullReferenceException
            Assert.AreEqual(Configuration.Judoid, transactions.Response.Results.FirstOrDefault().JudoId.ToString(CultureInfo.InvariantCulture));
// ReSharper disable once PossibleNullReferenceException
            Assert.AreEqual(response.Response.ReceiptId, transactions.Response.Results.FirstOrDefault().ReceiptId);
        }

        [Test]
        public void GetRefundsTransactions()
        {
            var paymentWithCard = new CardPaymentModel
            {
                JudoId = Configuration.Judoid,
                YourPaymentReference = "578543",
                YourConsumerReference = "432438862",
                Amount = 25,
                CardNumber = "4976000000003436",
                CV2 = "452",
                ExpiryDate = "12/15",
                CardAddress = new CardAddressModel
                {
                    Line1 = "Test Street",
                    PostCode = "W40 9AU",
                    Town = "Town"
                }
            };

            var paymentResponse = _judo.Payments.Create(paymentWithCard).Result;

            Assert.IsNotNull(paymentResponse);
            Assert.IsFalse(paymentResponse.HasError);
            Assert.AreEqual("Success", paymentResponse.Response.Result);

            var refund = new RefundModel
            {
                Amount = 25,
                ReceiptId = int.Parse(paymentResponse.Response.ReceiptId),
                YourPaymentReference = "578543"
            };

            var response = _judo.Refunds.Create(refund).Result;

            Assert.IsNotNull(response);
            Assert.IsFalse(response.HasError);
            Assert.AreEqual("Success", response.Response.Result);

            var paymentReceipt = response.Response as PaymentReceiptModel;

            Assert.IsNotNull(paymentReceipt);

            var transactions = _judo.Consumers.GetRefunds(paymentReceipt.Consumer.ConsumerToken).Result;

            Assert.IsNotNull(transactions);
            Assert.IsFalse(transactions.HasError);
            Assert.IsNotEmpty(transactions.Response.Results);
// ReSharper disable once PossibleNullReferenceException
            Assert.AreEqual(Configuration.Judoid, transactions.Response.Results.FirstOrDefault().JudoId.ToString(CultureInfo.InvariantCulture));
// ReSharper disable once PossibleNullReferenceException
            Assert.AreEqual(paymentReceipt.ReceiptId, transactions.Response.Results.FirstOrDefault().ReceiptId);
        }
    }
}